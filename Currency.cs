using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    public class Currency
    {
        public string Ticker {  get; set; }
        public decimal BinancePrice { get; private set; }
        public decimal BitgetPrice { get; private set; }
        public decimal BybitPrice { get; private set; }
        public decimal KucoinPrice { get; private set; }

        public Currency(decimal binancePrice, decimal bitgetPrice, decimal bybitPrice, decimal kucoinPrice, string ticker)
        {
            this.BinancePrice = binancePrice;
            this.BitgetPrice = bitgetPrice;
            this.BybitPrice = bybitPrice;
            this.KucoinPrice = kucoinPrice;
            Ticker = ticker;

        }
    }
}
