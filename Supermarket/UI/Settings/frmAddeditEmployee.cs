using Supermarket.DAL;
using Supermarket.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Supermarket.UI.Settings
{
    public partial class frmAddeditEmployee : Form
    {
        private readonly EmployeesDAL _employeesDAL = new EmployeesDAL();
        private readonly long _employeeId = 0;

        public frmAddeditEmployee(long employeeId = 0)
        {
            InitializeComponent();
            _employeeId = employeeId;

            this.Load += frmAddeditEmployee_Load;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnPath.Click += btnPath_Click;
        }

        private void frmAddeditEmployee_Load(object sender, EventArgs e)
        {
            PopulateGenders();
            PopulatePositions();

            if (_employeeId > 0)
            {
                guna2HtmlLabel1.Text = "Edit Employee";
                LoadEmployeeData(_employeeId);
            }
            else
            {
                guna2HtmlLabel1.Text = "Add Employee";
                dtpHireDay.Value = DateTime.Today;
            }
        }

        private void PopulateGenders()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Other");
            cmbGender.SelectedIndex = 0;
        }

        private void PopulatePositions()
        {
            cmbPosition.Items.Clear();
            cmbPosition.Items.Add("Manager");
            cmbPosition.Items.Add("Supervisor");
            cmbPosition.Items.Add("Cashier");
            cmbPosition.Items.Add("Stock Clerk");
            cmbPosition.Items.Add("Sales Associate");
            cmbPosition.Items.Add("Accountant");
            cmbPosition.Items.Add("Store Keeper");
            cmbPosition.Items.Add("Security");
            cmbPosition.Items.Add("Cleaner");
            cmbPosition.SelectedIndex = 0;
        }

        private void LoadEmployeeData(long id)
        {
            var employee = _employeesDAL.GetEmployeeById(id);
            if (employee != null)
            {
                txtName.Text = employee.FullName ?? "";
                txtPhone.Text = employee.Phone ?? "";
                txtEmail.Text = employee.Email ?? "";
                txtSalary.Text = employee.Salary.HasValue ? employee.Salary.Value.ToString("F2") : "";
                txtPhotoPath.Text = employee.Photo_path ?? "";

                if (employee.HireDate.HasValue)
                {
                    dtpHireDay.Value = employee.HireDate.Value;
                }

                if (!string.IsNullOrEmpty(employee.Gender))
                {
                    int genderIdx = cmbGender.FindStringExact(employee.Gender);
                    if (genderIdx >= 0)
                        cmbGender.SelectedIndex = genderIdx;
                    else
                    {
                        cmbGender.Items.Add(employee.Gender);
                        cmbGender.SelectedItem = employee.Gender;
                    }
                }

                if (!string.IsNullOrEmpty(employee.Position))
                {
                    int posIdx = cmbPosition.FindStringExact(employee.Position);
                    if (posIdx >= 0)
                        cmbPosition.SelectedIndex = posIdx;
                    else
                    {
                        cmbPosition.Items.Add(employee.Position);
                        cmbPosition.SelectedItem = employee.Position;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string gender = cmbGender.SelectedItem != null ? cmbGender.SelectedItem.ToString() : cmbGender.Text.Trim();
            string position = cmbPosition.SelectedItem != null ? cmbPosition.SelectedItem.ToString() : cmbPosition.Text.Trim();
            string salaryText = txtSalary.Text.Trim();
            string rawPhotoPath = txtPhotoPath.Text.Trim();
            DateTime hireDate = dtpHireDay.Value.Date;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter the employee full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            decimal? salary = null;
            if (!string.IsNullOrWhiteSpace(salaryText))
            {
                if (decimal.TryParse(salaryText, out decimal parsedSalary) && parsedSalary >= 0)
                {
                    salary = parsedSalary;
                }
                else
                {
                    MessageBox.Show("Please enter a valid salary amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalary.Focus();
                    return;
                }
            }

            string savedPhotoPath = SaveImageFile(rawPhotoPath);

            Model.Employees employee = new Model.Employees
            {
                Id = _employeeId,
                FullName = fullName,
                Gender = gender,
                Phone = phone,
                Email = email,
                Position = position,
                Salary = salary,
                HireDate = hireDate,
                Photo_path = savedPhotoPath
            };

            bool success;
            string errorMessage = "";

            if (_employeeId > 0)
            {
                success = _employeesDAL.UpdateEmployee(employee, out errorMessage);
            }
            else
            {
                employee.CreatedAt = DateTime.Now;
                success = _employeesDAL.AddEmployee(employee, out errorMessage);
            }

            if (success)
            {
                MessageBox.Show(_employeeId > 0 ? "Employee updated successfully!" : "Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private Bitmap CropAndResizeTo1x1(Image sourceImg, int targetSize = 500)
        {
            int minDim = Math.Min(sourceImg.Width, sourceImg.Height);
            int srcX = (sourceImg.Width - minDim) / 2;
            int srcY = (sourceImg.Height - minDim) / 2;

            int outputSize = targetSize > 0 ? targetSize : minDim;
            Bitmap squareBmp = new Bitmap(outputSize, outputSize);
            using (Graphics g = Graphics.FromImage(squareBmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(sourceImg,
                    new Rectangle(0, 0, outputSize, outputSize),
                    new Rectangle(srcX, srcY, minDim, minDim),
                    GraphicsUnit.Pixel);
            }
            return squareBmp;
        }

        private string SaveImageFile(string selectedPath)
        {
            if (string.IsNullOrWhiteSpace(selectedPath)) return "";

            try
            {
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Employees");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                // If path is already a relative path to an existing image
                if (!Path.IsPathRooted(selectedPath))
                {
                    string combined = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectedPath);
                    if (File.Exists(combined))
                    {
                        return selectedPath;
                    }
                }

                string fullSourcePath = Path.GetFullPath(selectedPath);
                if (!File.Exists(fullSourcePath))
                {
                    return selectedPath;
                }

                if (fullSourcePath.StartsWith(imagesDir, StringComparison.OrdinalIgnoreCase))
                {
                    return Path.Combine("Images", "Employees", Path.GetFileName(fullSourcePath));
                }

                string newFileName = $"emp_{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid().ToString("N").Substring(0, 6)}.png";
                string destPath = Path.Combine(imagesDir, newFileName);

                // Load image safely using stream, convert to 1:1 square image and save as PNG
                using (var fs = new FileStream(fullSourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var originalImg = Image.FromStream(fs))
                using (var squareImg = CropAndResizeTo1x1(originalImg, 500))
                {
                    squareImg.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }

                return Path.Combine("Images", "Employees", newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Process Error: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return selectedPath;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Employee Photo";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPhotoPath.Text = ofd.FileName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
