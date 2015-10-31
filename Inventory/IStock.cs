using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IStock
    {
        int StockID { get; set; }
        Guid StockGuid { get; set; }
        string SKU { get; set; }
        string Description { get; set; }
    }
}
