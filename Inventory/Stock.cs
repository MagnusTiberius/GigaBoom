using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GigaBoomLib;

namespace Inventory
{
    public class Stock : IStock
    {
        public int StockID { get; set; }
        public Guid StockGuid { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }

        public bool Insert(string sku, string description)
        {

            string sql = string.Format("INSERT INTO Stock(SKU, Description) VALUES ('{0}', '{1}') ", sku, description);
            using (Connection cn = new Connection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = cn.SqlConnection;
                        cmd.CommandText = sql;
                        int recordsAffected = cmd.ExecuteNonQuery();
                        FindBySku(sku);
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

        public bool FindBySku(string sku)
        {
            string sql = string.Format("SELECT * FROM Stock WHERE SKU = '{0}' ", sku);
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
                                StockID = (int)reader["StockID"];
                                StockGuid = (Guid)reader["StockGuid"];
                                SKU = reader["SKU"].ToString();
                                Description = reader["Description"].ToString();
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
    }
}
