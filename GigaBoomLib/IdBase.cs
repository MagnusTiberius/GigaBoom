using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaBoomLib
{
    public class IdBase
    {
        public int ID { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
