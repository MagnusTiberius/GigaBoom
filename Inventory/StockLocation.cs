using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationLib;
using GigaBoomLib;

namespace Inventory
{
    public class StockLocation : IdBase
    {
        public int StockLocationID { get; set; }
        public Stock Stock { get; set; }
        public LocationLib.Address Address { get; set; }
    }
}
