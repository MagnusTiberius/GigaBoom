using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Microsoft.Azure;

namespace GigaBoomLib
{
    public class Connection : IDisposable
    {
        SqlConnection sqlConnection;
        string connectionString;
        string encrypted;
        SecureString secureString;

        public SqlConnection SqlConnection { get; set; }

        public Connection()
        {
            sqlConnection = new SqlConnection();
            encrypted = Microsoft.Azure.CloudConfigurationManager.GetSetting("DatabaseConnectionString");
            secureString = Crypto.DecryptString(encrypted);
            connectionString = Crypto.ConvertToUnsecureString(secureString);

            //strConn = ConfigurationManager.AppSettings["DatabaseConnectionString"];
            sqlConnection.ConnectionString = connectionString;
            SqlConnection = sqlConnection;
            sqlConnection.Open();
        }

        ~Connection()
        {
            sqlConnection.Close();
        }


        public void Dispose()
        {
            sqlConnection.Close();
        }


    }
}
