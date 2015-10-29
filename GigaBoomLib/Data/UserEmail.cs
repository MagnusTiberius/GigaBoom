using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GigaBoomLib.Data
{
    public class UserEmail
    {
        public int UserID { get; set; }
        public int UserEmailID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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

        public bool FindUserEmailID(int userEmailID)
        {
            string sql = string.Format("SELECT * FROM UserEmails WHERE UserEmailID = '{0}' ", userEmailID);
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
                                //UserID = (int)reader["UserID"];
                                //loginName = reader["LoginName"].ToString();
                            }
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
            //return true;
        }

        public bool FindEmail(string email)
        {
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
                                //UserID = (int)reader["UserID"];
                                //loginName = reader["LoginName"].ToString();
                            }
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

        public User Login(string email, string pwd)
        {
            User user = new User();

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
                                UserID = (int)reader["UserID"];
                                string loginName = reader["LoginName"].ToString();
                                user.UserID = UserID;
                                user.LoginName = loginName;
                                user.FindLoginName(loginName);
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
