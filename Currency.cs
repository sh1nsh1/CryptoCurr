using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    public class Currency
    {
        public decimal BinancePrice { get; private set; }
        public decimal BitgetPrice { get; private set; }
        public decimal BybitPrice { get; private set; }
        public decimal KucoinPrice { get; private set; }
    }
}
