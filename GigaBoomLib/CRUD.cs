using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaBoomLib
{
    public interface CRUD
    {
        void Insert(object sender, EventArgs ea);
        void Update(object sender, EventArgs ea);
        void Delete(object sender, EventArgs ea);
        void Find(object sender, EventArgs ea);
    }
}
