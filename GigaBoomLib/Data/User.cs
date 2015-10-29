using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GigaBoomLib.Data
{
    public class User
    {
        public int UserID {get; set; }
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

        private string loginName;
        private UserEmail userEmail;

        public List<UserEmail> EmailList;

        public User()
        {
            EmailList = new List<UserEmail>();
            userEmail = new UserEmail();
        }

        public bool Insert(string loginName)
        {
            if (FindLoginName(loginName))
                return false;

            string sql = string.Format("INSERT INTO Users(LoginName) VALUES ('{0}') ", loginName);
            using (Connection cn = new Connection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = cn.SqlConnection;
                        cmd.CommandText = sql;
                        int recordsAffected = cmd.ExecuteNonQuery();
                            return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }
        
        public bool Find(int id)
        {
            string sql = string.Format("SELECT * FROM Users WHERE UserID = '{0}' ", id);
            using(Connection cn = new Connection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = cn.SqlConnection;
                        cmd.CommandText = sql;
                        int recordsAffected = cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                loginName = reader["LoginName"].ToString();
                            }
                            EmailList = userEmail.GetEmailList(id);
                            return true;
                        }
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool FindLoginName(string LoginName)
        {
            string sql = string.Format("SELECT * FROM Users WHERE LoginName = '{0}' ", LoginName);
            using (Connection cn = new Connection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = cn.SqlConnection;
                        cmd.CommandText = sql;
                        int recordsAffected = cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                loginName = reader["LoginName"].ToString();
                            }
                            EmailList = userEmail.GetEmailList(UserID);
                            return true;
                        }
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public void AddEmail(string email, string pwd)
        {
            UserEmail ue = new UserEmail();
            ue.UserID = UserID;

            UserEmail x = new UserEmail();
            x.UserID = UserID;
            x.Email = email;
            x.Password = pwd;

            ue.Insert(x);

        }
    }
}
