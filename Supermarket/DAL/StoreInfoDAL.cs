using Supermarket.Model;
using System;
using System.Data.SqlClient;

namespace Supermarket.DAL
{
    public class StoreInfoDAL
    {
        private readonly DBConnection _dbConnection = new DBConnection();

        public StoreInfo GetStoreInfo()
        {
            var info = new StoreInfo();
            try
            {
                using (var conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT TOP 1 
                                        store_name, 
                                        branch, 
                                        phone, 
                                        email, 
                                        address, 
                                        tax_rate, 
                                        currency, 
                                        exchange_rate, 
                                        receipt_header, 
                                        receipt_footer 
                                     FROM store_info 
                                     ORDER BY id ASC";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            info.StoreName = reader["store_name"] != DBNull.Value ? reader["store_name"].ToString() : info.StoreName;
                            info.BranchName = reader["branch"] != DBNull.Value ? reader["branch"].ToString() : info.BranchName;
                            info.PhoneNumber = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : info.PhoneNumber;
                            info.Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : info.Email;
                            info.Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : info.Address;

                            if (reader["tax_rate"] != DBNull.Value && decimal.TryParse(reader["tax_rate"].ToString(), out decimal tr))
                                info.TaxRate = tr;

                            info.CurrencySymbol = reader["currency"] != DBNull.Value ? reader["currency"].ToString() : info.CurrencySymbol;

                            if (reader["exchange_rate"] != DBNull.Value && decimal.TryParse(reader["exchange_rate"].ToString(), out decimal er))
                                info.ExchangeRate = er;

                            info.ReceiptHeader = reader["receipt_header"] != DBNull.Value ? reader["receipt_header"].ToString() : info.ReceiptHeader;
                            info.ReceiptFooter = reader["receipt_footer"] != DBNull.Value ? reader["receipt_footer"].ToString() : info.ReceiptFooter;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading StoreInfo from DB: " + ex.Message);
            }

            return info;
        }

        public bool SaveStoreInfo(StoreInfo info, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    // Check if a row exists
                    string checkQuery = "SELECT COUNT(*) FROM store_info";
                    using (var checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            string updateQuery = @"UPDATE store_info SET
                                                    store_name = @store_name,
                                                    branch = @branch,
                                                    phone = @phone,
                                                    email = @email,
                                                    address = @address,
                                                    tax_rate = @tax_rate,
                                                    currency = @currency,
                                                    exchange_rate = @exchange_rate,
                                                    receipt_header = @receipt_header,
                                                    receipt_footer = @receipt_footer,
                                                    updated_at = GETDATE()
                                                   WHERE id = (SELECT TOP 1 id FROM store_info ORDER BY id ASC)";

                            using (var cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@store_name", (object)info.StoreName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@branch", (object)info.BranchName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@phone", (object)info.PhoneNumber ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@email", (object)info.Email ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@address", (object)info.Address ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@tax_rate", info.TaxRate.ToString("F2"));
                                cmd.Parameters.AddWithValue("@currency", (object)info.CurrencySymbol ?? "$");
                                cmd.Parameters.AddWithValue("@exchange_rate", info.ExchangeRate.ToString("F2"));
                                cmd.Parameters.AddWithValue("@receipt_header", (object)info.ReceiptHeader ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@receipt_footer", (object)info.ReceiptFooter ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertQuery = @"INSERT INTO store_info 
                                                    (store_name, branch, phone, email, address, tax_rate, currency, exchange_rate, receipt_header, receipt_footer, updated_at)
                                                   VALUES
                                                    (@store_name, @branch, @phone, @email, @address, @tax_rate, @currency, @exchange_rate, @receipt_header, @receipt_footer, GETDATE())";

                            using (var cmd = new SqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@store_name", (object)info.StoreName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@branch", (object)info.BranchName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@phone", (object)info.PhoneNumber ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@email", (object)info.Email ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@address", (object)info.Address ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@tax_rate", info.TaxRate.ToString("F2"));
                                cmd.Parameters.AddWithValue("@currency", (object)info.CurrencySymbol ?? "$");
                                cmd.Parameters.AddWithValue("@exchange_rate", info.ExchangeRate.ToString("F2"));
                                cmd.Parameters.AddWithValue("@receipt_header", (object)info.ReceiptHeader ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@receipt_footer", (object)info.ReceiptFooter ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
