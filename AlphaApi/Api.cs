using System;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AlphaApi
{
    public class Api
    {
        public static RestClient Client { get; set; }
        public static string Key { get; set; }

        public static void SetKey(string key=null)
        {
            Key = key;
        }

        private static dynamic Conversor(int cod, string dado)
        {
            //0: String => Decimal // 1 String Date//2 String Percentual
            switch (cod)
            {
                case 0: var valor = Convert.ToDecimal(dado)/10000;
                    return valor;
                    
                case 1: var date = Convert.ToDateTime(dado);
                    return date;
                    
                case 2:
                    dado = dado.Replace("%", "");
                    var valor2 = Convert.ToDecimal(dado) / 1000000;
                    return valor2;
                default:
                    return ("ERROR");
                    
            }
        }

        private static async Task<string> Response(string url)
        {
            var request = new RestRequest(Method.GET);
            Client = new(url);
            Client.Timeout = 10000;
            IRestResponse response = await Client.ExecuteAsync(request);
            Console.WriteLine($"{response.StatusCode}  {response.Content}");

            return response.Content;
        }


        //Retorna uma classe Global Quote pronta com todos os valores ja convertidos, se não quiser retornar somente um valor, QuoteEndpoint."valor escolhido"
        public static GlobalQuoteConverted QuoteEndpoint(string stock, string suffix=(""))
        {
            stock = stock.ToUpper();
            suffix = suffix.ToUpper();
            string url = ($@"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol="+ $"{stock}{suffix}&apikey={Key}");
            string response = Response(url).Result;
            Console.WriteLine(response);
            var Deserialized = JsonConvert.DeserializeObject<RootQuote>(response);
            //converte todas as strings erradas para decimal, data e porcentagem
            decimal open = Conversor(0, Deserialized.GlobalQuote.open);
            decimal high = Conversor(0, Deserialized.GlobalQuote.High);
            decimal low = Conversor(0, Deserialized.GlobalQuote.Low);
            decimal price = Conversor(0, Deserialized.GlobalQuote.Price);
            decimal Volume = Conversor(0, Deserialized.GlobalQuote.Volume);
            DateTime LatestTradinDay = Conversor(1, Deserialized.GlobalQuote.LatestTradingDay);
            decimal PreviousClose = Conversor(0, Deserialized.GlobalQuote.PreviousClose);
            decimal Change = Conversor(0, Deserialized.GlobalQuote.Change);
            decimal ChangePercent = Conversor(2, Deserialized.GlobalQuote.ChangePercent);

            var quoteEndpoint = new GlobalQuoteConverted(Deserialized.GlobalQuote.Symbol, open, high, low, price, Volume, LatestTradinDay, PreviousClose, Change, ChangePercent);
            return  quoteEndpoint;

        }
    }
}
