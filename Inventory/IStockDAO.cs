using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IStockDAO
    {
        Stock Insert(string sku, string description);
        Stock FindBySku(string sku);
    }
}
