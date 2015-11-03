using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GigaBoomLib;

namespace Inventory
{
    public class StockDAO : IStockDAO
    {
        public Stock Insert(string sku, string description)
        {
            Stock s = null;
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
                        s = FindBySku(sku);
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

        public Stock FindBySku(string sku)
        {
            Stock s = null;

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
                                s = new Stock();
                                s.StockID = (int)reader["StockID"];
                                s.StockGuid = (Guid)reader["StockGuid"];
                                s.SKU = reader["SKU"].ToString();
                                s.Description = reader["Description"].ToString();
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
    }
}
