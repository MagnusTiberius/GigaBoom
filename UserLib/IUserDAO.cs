using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLib
{
    interface IUserDAO
    {
        User Insert(string loginName);
        User FindById(int id);
        User FindLoginName(string LoginName);
        void AddEmail(User s, string email, string pwd);
    }
}
