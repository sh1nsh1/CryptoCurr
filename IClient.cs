using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr
{
    internal interface IClient
    {
        void CheckPrice(string ticker);
        decimal Price { get; }
        
        string NormalizeTicker(string ticker);
    }
}
