using Kucoin.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    class KucoinClient : IClient
    {
        KucoinRestClient client;
        public decimal Price { get; private set; }
        public KucoinClient()
        {
            client = new KucoinRestClient();
        }
        public async void CheckPrice(string ticker)
        {
            var res = await client.SpotApi.ExchangeData.GetTickerAsync(
                NormalizeTicker(ticker)
                );
            this.Price = (decimal)res.Data.LastPrice;
        }
        public string NormalizeTicker(string ticker)
        {
            return ticker.ToUpper().Replace(".", "-");

        }
        ~KucoinClient()
        {
            client.Dispose();
        }
    }
}
