using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Model;

namespace Supermarket.DAL
{
    internal class ProductsDAL
    {
        DBConnection db = new DBConnection();

        //Read
        public List<Products> GetAllProducts()
        {
            List<Products> list = new List<Products>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM vw_Products";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products
                    {
                        ProductId = reader["ProductId"] != DBNull.Value ? Convert.ToInt32(reader["ProductId"]) : 0,
                        Barcode = reader["Barcode"] != DBNull.Value ? reader["Barcode"].ToString() : string.Empty,
                        Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                        
                        Categories = new Categories
                        {
                            //CategoryId = reader["CategoryId"] != DBNull.Value ? Convert.ToInt32(reader["CategoryId"]) : 0,
                            CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : string.Empty
                        },

                        Units = new Units
                        {
                            //UnitId = reader["UnitId"] != DBNull.Value ? Convert.ToInt32(reader["UnitId"]) : 0,
                            UnitName = reader["UnitName"] != DBNull.Value ? reader["UnitName"].ToString() : string.Empty
                        },

                        Cost_price = HasColumn(reader, "Cost_price") && reader["Cost_price"] != DBNull.Value 
                                     ? Convert.ToDecimal(reader["Cost_price"]) 
                                     : (HasColumn(reader, "CostPrice") && reader["CostPrice"] != DBNull.Value 
                                         ? Convert.ToDecimal(reader["CostPrice"]) 
                                         : 0m),
                        Selling_price = reader["Selling_price"] != DBNull.Value ? Convert.ToDecimal(reader["Selling_price"]) : 0m,
                        Stock_quantity = reader["Stock_quantity"] != DBNull.Value ? Convert.ToInt32(reader["Stock_quantity"]) : 0,
                        Stock_alert_level = reader["Stock_alert_level"] != DBNull.Value ? Convert.ToInt32(reader["Stock_alert_level"]) : 0,
                        Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : string.Empty
                    };
                    list.Add(product);
                }
            }
            return list;
        }

        private bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
