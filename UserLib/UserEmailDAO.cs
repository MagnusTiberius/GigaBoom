using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GigaBoomLib;

namespace UserLib
{
    public class UserEmailDAO : IDisposable
    {
        private UserDAO userDAO = null;

        public UserEmailDAO()
        {
            userDAO = new UserDAO();
        }

        ~UserEmailDAO()
        {
            userDAO = null;
        }

        public void Dispose()
        {
            userDAO = null;
        }

        public bool Insert(UserEmail userEmail)
        {

            string sql = string.Format("INSERT INTO UserEmails(UserID, Email, Password) VALUES ('{0}', '{1}', '{2}') ", userEmail.UserID, userEmail.Email, userEmail.Password);
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

        public User FindUserEmailID(int userEmailID)
        {
            User user = null;
            string sql = string.Format("SELECT * FROM UserEmails WHERE UserEmailID = '{0}' ", userEmailID);
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
                                user.UserID = (int)reader["UserID"];
                                user = userDAO.FindById(user.UserID);
                            }
                            return user;
                        }
                        else
                            return user;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return user;
                    }
                }
            }
        }

        public User FindEmail(string email)
        {
            User user = null;
            string sql = string.Format("SELECT * FROM UserEmails WHERE Email = '{0}' ", email);
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
                                user.UserID = (int)reader["UserID"];
                                user = userDAO.FindById(user.UserID);
                            }
                            return user;
                        }
                        else
                            return user;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return user;
                    }
                }
            }
        }

        public User Login(string email, string pwd)
        {
            User user = null;

            string sql = string.Format("SELECT * FROM UserEmails WHERE Email = '{0}' and Password = '{1}' ", email, pwd);
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
                                user = new User();
                                user.UserID = (int)reader["UserID"];
                                user = userDAO.FindById(user.UserID);
                            }
                            return user;
                        }
                        else
                            return user;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return user;
                    }
                }
            }
        }


        public List<UserEmail> GetEmailList(int userID)
        {
            List<UserEmail> list = new List<UserEmail>();

            string sql = string.Format("SELECT * FROM UserEmails WHERE UserID = '{0}' ", userID);
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
                                UserEmail ue = new UserEmail();
                                ue.UserID = (int)reader["UserID"];
                                ue.UserEmailID = (int)reader["UserEmailID"];
                                ue.Email = reader["Email"].ToString();
                                ue.Password = reader["Password"].ToString();
                                list.Add(ue);
                            }
                            return list;
                        }
                        else
                            return list;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        return list;
                    }
                }
            }
        }
    
    }
}
