using Bitget.Net.Clients;
using CryptoExchange.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    class BitgetClient : IClient
    {
        BitgetRestClient client;
        public decimal Price { get; private set; }
        public BitgetClient()
        {
            client = new BitgetRestClient();
        }
        public async void CheckPrice(string ticker)
        {
            var res = await client.SpotApi.ExchangeData.GetTickerAsync(
                NormalizeTicker(ticker)
                );
            this.Price = Math.Round((decimal)res.Data.ClosePrice, 2);
        }
        public string NormalizeTicker(string ticker)
        {
            return ticker.ToUpper().Replace(".", "") + "_SPBL";

        }
        ~BitgetClient()
        {
            client.Dispose();
        }
    }
}
