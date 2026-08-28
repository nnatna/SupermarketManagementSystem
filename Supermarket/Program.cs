using Supermarket.UI;
using System;
using System.Windows.Forms;

namespace Supermarket
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        // User cancelled or closed the login window -> exit application
                        break;
                    }
                }

                using (var mainForm = new FramMain())
                {
                    var result = mainForm.ShowDialog();
                    if (result != DialogResult.Retry)
                    {
                        // User exited main window directly -> exit application
                        break;
                    }
                    // If result is DialogResult.Retry, user logged out -> loops back to login form
                }
            }
        }
    }
}
