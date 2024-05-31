using Binance.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    class BinanceClient : IClient
    {
        BinanceRestClient client;
        public decimal Price { get; private set; }
        
        public BinanceClient()
        {
            client = new BinanceRestClient();
        }
        public async void CheckPrice(string ticker)
        {
            var res = await client.SpotApi.ExchangeData.GetTickerAsync(
                NormalizeTicker(ticker)
                );
            this.Price = res.Data.LastPrice;
        }

        public string NormalizeTicker(string ticker)
        {
            return ticker.ToUpper().Replace(".", "");

        }

        ~BinanceClient()
        {
            client.Dispose();
        }
    }
}
