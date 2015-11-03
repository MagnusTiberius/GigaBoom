using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLib
{
    public class User
    {
        public int UserID { get; set; }

        private string loginName;
        public string LoginName
        {
            get
            {
                return loginName;
            }

            set
            {
                loginName = value;
            }
        }

        public List<UserEmail> EmailList;
        //private UserEmail userEmail;

        public User()
        {
            EmailList = new List<UserEmail>();
            //userEmail = new UserEmail();
        }


    }
}
