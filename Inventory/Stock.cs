using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GigaBoomLib;

namespace Inventory
{
    public class Stock
    {
        public int StockID { get; set; }
        public Guid StockGuid { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }

    }
}
