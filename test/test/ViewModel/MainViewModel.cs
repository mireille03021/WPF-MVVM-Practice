using BindingLibrary;
using StockPriceRank.Model;
using StockPriceRank.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace StockPriceRank.ViewModel
{
    public class MainViewModel : NotifyPropertyBase
    {
        // UI 顯示資料
        private ObservableCollection<StockViewModel> _stockListView;
        public ObservableCollection<StockViewModel> StockListView
        {
            get { return _stockListView; }
            set { SetProperty(ref _stockListView, value); }
        }

        // 背景運行資料
        private ObservableCollection<StockViewModel> StockList { get; set; }

        // Constructor
        public MainViewModel()
        {
            //設定UI及背景資料
            this.StockListView = Stocks.GetItem();
            this.StockList = Stocks.GetItem();

            //設定ThreadTimer
            //timeBeginPeriod(1);
            //SetBgTimer();
            //SetUITimer();
        }

        //測試按鈕在stockList生成/更新資料
        private ICommand _generateStock;
        public ICommand GenerateStock
        {
            get
            {
                if(this._generateStock == null)
                {
                    this._generateStock = new RelayCommand(x =>
                    {
                        var newStock = new StockViewModel()
                        {
                            StockId = "6205",
                            Name = "富邦上証",
                            Volume = 258705,
                            FinalPrice = 8757225,
                            OpeningPrice = 34.01M,
                            QuoteChange = -0.24F,
                            dateTime = DateTime.Now
                        };
                        StockList.Add(newStock);
                    });
                }
                return this._generateStock;
            }
        }

        
        [DllImport("winmm.dll")]
        private static extern uint timeBeginPeriod(uint period);

        [DllImport("winmm.dll")]
        private static extern uint timeEndPeriod(uint period);

        //建立刷新UI用 thread timer
        private System.Threading.Timer BgTimer { get; set; }

        // 資料更新秒數(毫秒)
        private const int _milliSecond = 1;

        private void SetBgTimer()
        {
            BgTimer = new System.Threading.Timer(
                e => UpdateStockList(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMilliseconds(_milliSecond));
        }

        private void UpdateStockList()
        {
            var stockService = new StockService();
            var newStockList = new ObservableCollection<StockViewModel>();
            foreach (var item in StockList)
            {
                newStockList.Add(stockService.GenerateData(item));
            }
            StockList = newStockList;
        }

        //建立刷新UI用 thread timer--------------------
        private System.Threading.Timer UItimer { get; set; }

        // UI 刷新秒數(毫秒)---------------------------
        private int _refreshMilliSecond = 3000;
        public int RefreshMilliSecond
        {
            get { return _refreshMilliSecond; }
            set
            {
                SetProperty(ref _refreshMilliSecond, value);
            }
        }

        //查看畫面更新頻率------------------------------
        private long _checkFrequency;
        public long CheckFrequency
        {
            get { return _checkFrequency; }
            set { SetProperty(ref _checkFrequency, value); }
        }

        public Stopwatch watch = new Stopwatch();

        private void SetUITimer()
        {
            UItimer = new System.Threading.Timer(
                e => updatedStockListView(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMilliseconds(RefreshMilliSecond));
        }

        private void updatedStockListView()
        {
            CheckFrequency = watch.ElapsedMilliseconds;
            watch.Reset();
            StockListView = new ObservableCollection<StockViewModel>(StockList);
            watch.Start();
        }

        //停止timer-------------------------------------
        private ICommand _timerDispose;
        public ICommand TimerDispose
        {
            get {
                if (this._timerDispose == null)
                {
                    this._timerDispose = new RelayCommand(x =>
                    {
                        TimerDisposeCommand();
                    });
                }
                return this._timerDispose;
            }
        }

        public void TimerDisposeCommand()
        {
            BgTimer.Dispose();
            UItimer.Dispose();
            timeEndPeriod(1);
        }

        //開始timer Command-----------------------------
        public ICommand _timerStart;
        public ICommand TimerStart
        {
            get
            {
                if (this._timerStart == null)
                {
                    this._timerStart = new RelayCommand(x =>
                    {
                        TimerStartCommand();
                    });
                }
                return this._timerStart;
            }
        }

        public void TimerStartCommand()
        {
            timeBeginPeriod(1);
            SetBgTimer();
            SetUITimer();
        }

        //更新畫面刷新時間
        private ICommand _changeUItimerInterval;
        public ICommand ChangeUItimerInterval
        {
            get
            {
                if (this._changeUItimerInterval == null)
                {
                    this._changeUItimerInterval = new RelayCommand(x =>
                    {
                        UItimer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(RefreshMilliSecond));
                    });
                }
                return this._changeUItimerInterval;
            }
        }
    }
}
