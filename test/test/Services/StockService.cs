using StockPriceRank.Model;
using StockPriceRank.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace StockPriceRank.Services
{
    //Service
    public class StockService
    {
        //取得參考資料列表
        private ObservableCollection<StockViewModel> initDataList { get; set; } = Stocks.GetItem();

        //產生StockViewModel資料
        public StockViewModel GenerateData(StockViewModel Data)
        {
            var newStock = new StockViewModel();
            var initData = new StockViewModel();
            var check = SearchStock(Data.StockId, ref initData);
            if (check)
            {
                newStock.StockId = Data.StockId;
                newStock.Name = Data.Name;

                //成交量每次新增一筆
                newStock.Volume = Data.Volume + 1;

                //每次隨機價格上漲
                var random = new Random();
                var openingPrice = Data.OpeningPrice + (decimal)(random.NextDouble() * random.Next(3));
                newStock.OpeningPrice = Math.Round(openingPrice, 2);

                //固定交易一千股
                var finalPrice = Data.FinalPrice + newStock.OpeningPrice * 1000;
                newStock.FinalPrice = Math.Round(finalPrice, 2);

                //漲跌幅 = (新價格-參考價)/參考價*100%
                var quoteChange = (newStock.OpeningPrice - initData.OpeningPrice) / initData.OpeningPrice * 100;
                newStock.QuoteChange = Convert.ToSingle(Math.Round(quoteChange,2));

                //新增資料時間
                newStock.dateTime = DateTime.Now;
            }          
            return newStock;
        }

        //查詢參考資料
        private bool SearchStock(string Id, ref StockViewModel stockViewModel)
        {
            foreach(var item in initDataList)
            {
                if(item.StockId == Id)
                {
                    stockViewModel = item;
                    return true;
                }
            }
            return false;
        }

        public void updatedStock(ObservableCollection<StockViewModel> stockViewModel,StockViewModel stock)
        {

        }
    }
}
