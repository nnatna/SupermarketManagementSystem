using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class EmployeesDAL
    {
        // READ - Get all employees
        public List<Employees> GetAllEmployees()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Employees
                             .AsNoTracking()
                             .OrderByDescending(e => e.Id)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                {
                    msg += "\nInner Exception: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        msg += "\n" + ex.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("EF Query Error: " + msg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Employees>();
            }
        }

        // READ - Get single employee by ID
        public Employees GetEmployeeById(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Employees
                             .AsNoTracking()
                             .FirstOrDefault(e => e.Id == id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // CREATE - Add a new employee
        public bool AddEmployee(Employees employee, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                if (employee.Photo_path == null) employee.Photo_path = "";

                using (var db = new SupermarketContext())
                {
                    db.Employees.Add(employee);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Add Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Update an existing employee
        public bool UpdateEmployee(Employees employee, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Employees.FirstOrDefault(e => e.Id == employee.Id);
                    if (existing == null)
                    {
                        errorMessage = "Employee not found.";
                        return false;
                    }

                    existing.FullName = employee.FullName;
                    existing.Gender = employee.Gender;
                    existing.Phone = employee.Phone;
                    existing.Email = employee.Email;
                    existing.Position = employee.Position;
                    existing.Salary = employee.Salary;
                    existing.HireDate = employee.HireDate;
                    existing.Photo_path = employee.Photo_path ?? "";

                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Update Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE PHOTO - Update only employee photo path
        public bool UpdateEmployeePhoto(long employeeId, string newPhotoPath, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Employees.FirstOrDefault(e => e.Id == employeeId);
                    if (existing == null)
                    {
                        errorMessage = "Employee record not found.";
                        return false;
                    }

                    existing.Photo_path = newPhotoPath ?? "";
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Update Photo Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // DELETE - Delete an employee
        public bool DeleteEmployee(long id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Employees.FirstOrDefault(e => e.Id == id);
                    if (existing == null)
                    {
                        errorMessage = "Employee not found.";
                        return false;
                    }

                    // Check if employee is used in users table
                    var hasUser = db.Database.SqlQuery<int>(
                        "SELECT COUNT(1) FROM users WHERE employee_id = @p0", id).FirstOrDefault();
                    if (hasUser > 0)
                    {
                        errorMessage = "Cannot delete this employee because they are linked to a user account.";
                        return false;
                    }

                    db.Employees.Remove(existing);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Delete Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GetFullErrorMessage(Exception ex)
        {
            if (ex == null) return "";
            string msg = ex.Message;
            Exception inner = ex.InnerException;
            while (inner != null)
            {
                if (!string.IsNullOrWhiteSpace(inner.Message))
                {
                    msg += "\n-> " + inner.Message;
                }
                inner = inner.InnerException;
            }
            return msg;
        }
    }
}
