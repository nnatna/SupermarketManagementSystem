using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class UsersDAL
    {
        // READ - Get all users with eager loaded relations
        public List<Users> GetAllUsers()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Users
                             .Include(u => u.Employees)
                             .Include(u => u.Roles)
                             .AsNoTracking()
                             .OrderByDescending(u => u.Id)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                string msg = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: " + msg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Users>();
            }
        }

        // READ - Get single user by ID
        public Users GetUserById(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Users
                             .Include(u => u.Employees)
                             .Include(u => u.Roles)
                             .FirstOrDefault(u => u.Id == id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // AUTHENTICATE - Verify username & password for login
        public Users Authenticate(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Please enter both username and password.";
                return null;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    // If database has 0 users, automatically seed default roles and admin user
                    if (!db.Users.Any())
                    {
                        var adminRole = db.Roles.FirstOrDefault(r => r.Name == "Admin");
                        if (adminRole == null)
                        {
                            adminRole = new Roles
                            {
                                Name = "Admin",
                                Description = "Full system administration access",
                                CreatedAt = DateTime.Now
                            };
                            db.Roles.Add(adminRole);
                            db.SaveChanges();
                        }

                        var defaultAdmin = new Users
                        {
                            Username = "admin",
                            Password = HashPassword("admin123"),
                            RoleId = adminRole.Id,
                            Status = "active",
                            CreatedAt = DateTime.Now
                        };
                        db.Users.Add(defaultAdmin);
                        db.SaveChanges();
                    }

                    string normUser = username.Trim().ToLower();
                    var user = db.Users
                                 .Include(u => u.Employees)
                                 .Include(u => u.Roles)
                                 .FirstOrDefault(u => u.Username.ToLower() == normUser);

                    if (user == null)
                    {
                        errorMessage = "Invalid username or password.";
                        return null;
                    }

                    if (!string.Equals(user.Status, "active", StringComparison.OrdinalIgnoreCase))
                    {
                        errorMessage = "Your account is deactivated. Please contact an administrator.";
                        return null;
                    }

                    string hashedPassword = HashPassword(password.Trim());
                    bool passwordValid = string.Equals(user.Password, hashedPassword, StringComparison.OrdinalIgnoreCase)
                                      || string.Equals(user.Password, password.Trim()); // Fallback for legacy plain text

                    if (!passwordValid)
                    {
                        errorMessage = "Invalid username or password.";
                        return null;
                    }

                    // If password was stored in plain text, upgrade it to hash
                    if (string.Equals(user.Password, password.Trim()) && !string.Equals(user.Password, hashedPassword))
                    {
                        var userToUpdate = db.Users.FirstOrDefault(u => u.Id == user.Id);
                        if (userToUpdate != null)
                        {
                            userToUpdate.Password = hashedPassword;
                            db.SaveChanges();
                        }
                    }

                    return user;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Database connection error: " + GetFullErrorMessage(ex);
                return null;
            }
        }

        // HASH PASSWORD - SHA-256
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return "";
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // CREATE - Add a new user with hashed password (Entity Framework ORM)
        public bool AddUser(Users user, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    // Check username uniqueness
                    string normalizedUsername = user.Username.Trim().ToLower();
                    bool exists = db.Users.Any(u => u.Username.ToLower() == normalizedUsername);
                    if (exists)
                    {
                        errorMessage = $"Username '{user.Username}' is already in use. Please enter a different username.";
                        return false;
                    }

                    // Hash password using SHA-256
                    if (!string.IsNullOrWhiteSpace(user.Password))
                    {
                        user.Password = HashPassword(user.Password);
                    }

                    if (user.Status == null) user.Status = "active";
                    if (user.CreatedAt == default(DateTime)) user.CreatedAt = DateTime.Now;

                    db.Users.Add(user);
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

        // UPDATE - Update an existing user with hashed password (Entity Framework ORM)
        public bool UpdateUser(Users user, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Users.FirstOrDefault(u => u.Id == user.Id);
                    if (existing == null)
                    {
                        errorMessage = "User not found.";
                        return false;
                    }

                    // Check username uniqueness if changed
                    string normalizedUsername = user.Username.Trim().ToLower();
                    bool duplicate = db.Users.Any(u => u.Id != user.Id && u.Username.ToLower() == normalizedUsername);
                    if (duplicate)
                    {
                        errorMessage = $"Username '{user.Username}' is already taken by another account.";
                        return false;
                    }

                    existing.Username = user.Username.Trim();
                    existing.RoleId = user.RoleId;
                    existing.EmployeeId = user.EmployeeId;
                    existing.Status = user.Status ?? "active";

                    // Update and hash password only if a new password is provided
                    if (!string.IsNullOrWhiteSpace(user.Password))
                    {
                        existing.Password = HashPassword(user.Password);
                    }

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

        // DELETE - Delete a user
        public bool DeleteUser(long id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Users.FirstOrDefault(u => u.Id == id);
                    if (existing == null)
                    {
                        errorMessage = "User not found.";
                        return false;
                    }

                    // Check if user is linked to sales transactions
                    bool hasSales = db.Sales.Any(s => s.User_id == id);
                    if (hasSales)
                    {
                        errorMessage = "Cannot delete this user because they have recorded sales transactions.";
                        return false;
                    }

                    db.Users.Remove(existing);
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

        // READ - Get all roles (ensures default roles exist if table is empty)
        public List<Roles> GetAllRoles()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var roles = db.Roles.AsNoTracking().OrderBy(r => r.Id).ToList();
                    if (roles.Count == 0)
                    {
                        // Seed standard supermarket roles
                        var defaultRoles = new List<Roles>
                        {
                            new Roles { Name = "Admin", Description = "Full system administration access", CreatedAt = DateTime.Now },
                            new Roles { Name = "Manager", Description = "Store and inventory management", CreatedAt = DateTime.Now },
                            new Roles { Name = "Cashier", Description = "Point of Sale operations", CreatedAt = DateTime.Now },
                            new Roles { Name = "Inventory Clerk", Description = "Stock adjustments and goods receive", CreatedAt = DateTime.Now }
                        };

                        db.Roles.AddRange(defaultRoles);
                        db.SaveChanges();

                        roles = db.Roles.AsNoTracking().OrderBy(r => r.Id).ToList();
                    }
                    return roles;
                }
            }
            catch
            {
                return new List<Roles>();
            }
        }

        // READ - Get single role by ID
        public Roles GetRoleById(int id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    return db.Roles.AsNoTracking().FirstOrDefault(r => r.Id == id);
                }
            }
            catch
            {
                return null;
            }
        }

        // CREATE - Add a new role
        public bool AddRole(Roles role, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                if (role == null || string.IsNullOrWhiteSpace(role.Name))
                {
                    errorMessage = "Role name cannot be empty.";
                    return false;
                }

                using (var db = new SupermarketContext())
                {
                    // Check duplicate role name
                    bool exists = db.Roles.Any(r => r.Name.ToLower() == role.Name.Trim().ToLower());
                    if (exists)
                    {
                        errorMessage = $"Role with name '{role.Name.Trim()}' already exists.";
                        return false;
                    }

                    role.Name = role.Name.Trim();
                    role.Description = role.Description ?? "";
                    role.CreatedAt = DateTime.Now;

                    db.Roles.Add(role);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // UPDATE - Update an existing role
        public bool UpdateRole(Roles role, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                if (role == null || string.IsNullOrWhiteSpace(role.Name))
                {
                    errorMessage = "Role name cannot be empty.";
                    return false;
                }

                using (var db = new SupermarketContext())
                {
                    var existing = db.Roles.FirstOrDefault(r => r.Id == role.Id);
                    if (existing == null)
                    {
                        errorMessage = "Role not found.";
                        return false;
                    }

                    // Check duplicate name on another role
                    bool duplicate = db.Roles.Any(r => r.Id != role.Id && r.Name.ToLower() == role.Name.Trim().ToLower());
                    if (duplicate)
                    {
                        errorMessage = $"Another role with name '{role.Name.Trim()}' already exists.";
                        return false;
                    }

                    existing.Name = role.Name.Trim();
                    existing.Description = role.Description ?? "";

                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // DELETE - Delete a role
        public bool DeleteRole(int id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Roles.FirstOrDefault(r => r.Id == id);
                    if (existing == null)
                    {
                        errorMessage = "Role not found.";
                        return false;
                    }

                    if (string.Equals(existing.Name, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        errorMessage = "The default 'Admin' role cannot be deleted.";
                        return false;
                    }

                    // Check if role is assigned to users
                    bool hasUsers = db.Users.Any(u => u.RoleId == id);
                    if (hasUsers)
                    {
                        errorMessage = "Cannot delete this role because it is currently assigned to one or more user accounts.";
                        return false;
                    }

                    db.Roles.Remove(existing);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // READ - Get all employees for user dropdown binding
        public List<Employees> GetAllEmployees()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    return db.Employees.AsNoTracking().OrderBy(e => e.FullName).ToList();
                }
            }
            catch
            {
                return new List<Employees>();
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
