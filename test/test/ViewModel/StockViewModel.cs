using BindingLibrary;
using System;

namespace StockPriceRank.ViewModel
{
    public class StockViewModel : NotifyPropertyBase
    {
        //證券代號
        private string _stockId;
        public string StockId 
        {
            get { return _stockId; }
            set { SetProperty(ref _stockId, value); } 
        }

        //股票名稱
        private string _name;
        public string Name 
        {
            get { return _name; }
            set { SetProperty(ref _name, value); } 
        }

        //成交價
        private decimal _finalPrice;
        public decimal FinalPrice 
        {
            get { return _finalPrice; }
            set { SetProperty(ref _finalPrice, value); }
        }

        //漲跌幅
        private float _quoteChange;
        public float QuoteChange 
        { 
            get { return _quoteChange; }
            set { SetProperty(ref _quoteChange, value); }
        }

        //成交量
        private int _volume;
        public int Volume 
        {
            get { return _volume; }
            set { SetProperty(ref _volume, value); }
        }

        //開盤價
        private decimal _openingPrice;
        public decimal OpeningPrice 
        {
            get { return _openingPrice; }
            set { SetProperty(ref _openingPrice, value); }
        }

        //日期
        private DateTime _dateTime;
        public DateTime dateTime 
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }
    }
}
