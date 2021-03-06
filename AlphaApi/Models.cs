using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaApi
{
    public class QuoteModel
    {
        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }
        
        [JsonProperty("02. open")]
        public string Open { get; set; }
        
        [JsonProperty("03. high")]
        public string High { get; set; }
        
        [JsonProperty("04. low")]
        public string Low { get; set; }
        
        [JsonProperty("05. price")]
        public string Price { get; set; }

        [JsonProperty("06. volume")]
        public string Volume { get; set; }
        
        [JsonProperty("07. latest trading day")]
        public string LatestTradingDay { get; set; }
        
        [JsonProperty("08. previous close")]
        public string PreviousClose { get; set; }
        
        [JsonProperty("09. change")]
        public string Change { get; set; }
        
        [JsonProperty("10. change percent")]
        public string ChangePercent { get; set; }
    }

    public class GlobalQuoteConverted
    {
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public DateTime LatestTradinDay { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }

        public GlobalQuoteConverted(string symbol, decimal open, decimal high, decimal low, decimal price, decimal volume, DateTime latest, decimal previous, decimal change, decimal percent)
        {
            Symbol = symbol;
            Open = open;
            High = high;
            Low = low;
            Price = price;

            Volume = volume;
            LatestTradinDay = latest;
            PreviousClose = previous;
            Change = change;
            ChangePercent = percent;

        }

    }


    public class RootQuote
    {
        [JsonProperty("Global Quote")]
        public QuoteModel GlobalQuote { get; set; }
    }
}
