using Supermarket.Model;
using System;
using System.Drawing;

namespace Supermarket.Utils
{
    public static class UserSession
    {
        public static Users CurrentUser { get; set; }
        public static DateTime? LoginTime { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static long UserId => CurrentUser?.Id ?? 0;
        public static string Username => CurrentUser?.Username ?? "Guest";
        public static string RoleName => CurrentUser?.Roles?.Name ?? "Guest";
        public static string EmployeeFullName => CurrentUser?.Employees?.FullName ?? CurrentUser?.Username ?? "Guest";
        public static Image UserImage => CurrentUser?.UserImage;

        public static void Login(Users user)
        {
            CurrentUser = user;
            LoginTime = DateTime.Now;
        }

        public static void Logout()
        {
            CurrentUser = null;
            LoginTime = null;
        }

        public static bool HasRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName) || CurrentUser?.Roles == null)
                return false;

            return string.Equals(CurrentUser.Roles.Name, roleName, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsAdmin => HasRole("Admin") || HasRole("Administrator");
        public static bool IsManager => HasRole("Manager");
        public static bool IsCashier => HasRole("Cashier");
        public static bool IsStaff => HasRole("Staff");

        // Permission Helpers
        public static bool CanAccessStoreInfo => IsAdmin || IsManager;
        public static bool CanAccessUnits => IsAdmin || IsManager;
        public static bool CanAccessSystemSettings => IsAdmin;
        public static bool CanAccessUsers => IsAdmin;
        public static bool CanAccessEmployees => IsAdmin || IsManager;
        public static bool CanAccessPromotions => IsAdmin || IsManager;
        public static bool CanAccessReports => IsAdmin || IsManager;
        public static bool CanAccessPurchasing => IsAdmin || IsManager || IsStaff;
        public static bool CanAccessInventory => IsAdmin || IsManager || IsStaff;
    }
}
