using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.DAL
{
    internal class DBConnection
    {
        private string connectionString = "Server=.\\SQLEXPRESS; Database=SupermarketManagement; User Id=sa; Password=123;";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
