using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GigaBoomLib;

namespace UserLib
{
    public class UserDAO : IUserDAO
    {
        public UserDAO()
        {
        }

        static public User Insert(string loginName)
        {
            if (FindLoginName(loginName) != null)
                return null;

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
                        return FindLoginName(loginName);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
        
        static public User FindById(int id)
        {
            User s = null;
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
                                s = new User();
                                s.UserID = (int)reader["UserID"];
                                s.LoginName = reader["LoginName"].ToString();
                                s.EmailList = UserEmailDAO.GetEmailList(s.UserID);
                            }
                            return s;
                        }
                        else
                            return s;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return s;
                    }
                }
            }
        }

        static public User FindLoginName(string LoginName)
        {
            User s = null;
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
                                s = new User();
                                s.UserID = (int)reader["UserID"];
                                s.LoginName = reader["LoginName"].ToString();
                                s.EmailList = UserEmailDAO.GetEmailList(s.UserID);
                            }
                            return s;
                        }
                        else
                            return s;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return s;
                    }
                }
            }
        }

        static public void AddEmail(User s, string email, string pwd)
        {
            UserEmail ue = new UserEmail();
            ue.UserID = s.UserID;
            ue.Email = email;
            ue.Password = pwd;
        }
    }
}
