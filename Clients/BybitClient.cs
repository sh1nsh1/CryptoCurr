using Bybit.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    class BybitClient : IClient
    {
        BybitRestClient client;
        public decimal Price { get; private set; }
        public BybitClient()
        {
            client = new BybitRestClient();
        }
        public async void CheckPrice(string ticker)
        {
            var res = await client.V5Api.ExchangeData.GetSpotTickersAsync(
                NormalizeTicker(ticker)
            );
            this.Price = Math.Round(res.Data.List.First().LastPrice, 2);

        }
        public string NormalizeTicker(string ticker)
        {
            return ticker.ToUpper().Replace(".", "");

        }
        ~BybitClient()
        {
            client.Dispose();
        }
    }
}
