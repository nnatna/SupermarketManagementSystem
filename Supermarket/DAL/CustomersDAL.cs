using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class CustomersDAL
    {
        // READ - Get all customers
        public List<Customers> GetAllCustomers()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Customers
                             .AsNoTracking()
                             .OrderByDescending(c => c.Id)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Customers>();
            }
        }

        // READ - Get single customer by ID
        public Customers GetCustomerById(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Customers
                             .AsNoTracking()
                             .FirstOrDefault(c => c.Id == id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // CREATE - Add a new customer
        public bool AddCustomer(Customers customer, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("Failed to add customer: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Update an existing customer
        public bool UpdateCustomer(Customers customer, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
                    if (existing == null)
                    {
                        errorMessage = "Customer not found.";
                        return false;
                    }

                    existing.Name = customer.Name;
                    existing.Phone = customer.Phone;
                    existing.Email = customer.Email;
                    existing.Address = customer.Address;
                    existing.Points = customer.Points;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("Failed to update customer: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // DELETE - Delete a customer
        public bool DeleteCustomer(long id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Customers.FirstOrDefault(c => c.Id == id);
                    if (existing == null)
                    {
                        errorMessage = "Customer not found.";
                        return false;
                    }

                    // Check if customer is used in sales
                    bool hasSales = db.Sales.Any(s => s.Customer_id == id);
                    if (hasSales)
                    {
                        errorMessage = "Cannot delete this customer because they have existing sales transaction records.";
                        return false;
                    }

                    db.Customers.Remove(existing);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("Failed to delete customer: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GetFullErrorMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception current = ex;
            while (current != null)
            {
                sb.AppendLine(current.Message);
                current = current.InnerException;
            }
            return sb.ToString();
        }
    }
}
