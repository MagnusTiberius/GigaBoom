using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GigaBoomLib
{
    public class DBSession : Connection
    {
        public DBSession()
        {

        }

        //public void Insert(string sql)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        try 
        //        {
        //            cmd.Connection = SqlConnection;
        //            cmd.CommandText = sql;
        //            int recordsAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {

        //        }
        //    }
        //}


        public bool Insert(string sql)
        {

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

        public void Query(out SqlDataReader reader, string sql)
        {
            reader = null;
            using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
            {
                reader = cmd.ExecuteReader();
            }
        }

    }
}
