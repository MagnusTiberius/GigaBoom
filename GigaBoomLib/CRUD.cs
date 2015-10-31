using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaBoomLib
{
    public interface CRUD
    {
        T Insert<T>(T obj);
        T Update<T>(T obj);
        W Delete<T, W>(T obj);
        W Find<T, W>(T obj);
    }
}
