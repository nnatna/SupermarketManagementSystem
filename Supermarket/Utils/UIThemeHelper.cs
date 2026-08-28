using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Supermarket.Utils
{
    public static class UIThemeHelper
    {
        // Minimal Modern LightGray Theme
        public static readonly Color PrimaryBlue = Color.LightGray; // LightGray Theme
        public static readonly Color PrimaryHover = Color.FromArgb(200, 205, 212);
        public static readonly Color HeaderText = Color.FromArgb(33, 37, 41); // Sharp dark text for LightGray headers
        public static readonly Color RowAltBackground = Color.FromArgb(248, 250, 252);
        public static readonly Color RowBackground = Color.White;
        public static readonly Color CellTextColor = Color.FromArgb(33, 37, 41);
        public static readonly Color SelectionBackground = Color.FromArgb(225, 238, 255); // Soft blue-gray selection
        public static readonly Color SelectionTextColor = Color.FromArgb(15, 23, 42);
        public static readonly Color GridLineColor = Color.FromArgb(230, 235, 242);

        // Standardized Uniform Fonts
        public static readonly Font HeaderFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        public static readonly Font RowFont = new Font("Segoe UI", 10.5F, FontStyle.Regular);

        /// <summary>
        /// Applies the standardized modern table styling & strictly enforces uniform fonts across all rows, columns, and headers.
        /// </summary>
        public static void ApplyModernGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = GridLineColor;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Column Header Style
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = HeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryBlue;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = HeaderText;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Default Row Style
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.BackColor = RowBackground;
            dgv.DefaultCellStyle.ForeColor = CellTextColor;
            dgv.DefaultCellStyle.Font = RowFont;
            dgv.DefaultCellStyle.SelectionBackColor = SelectionBackground;
            dgv.DefaultCellStyle.SelectionForeColor = SelectionTextColor;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // RowTemplate Style
            dgv.RowTemplate.DefaultCellStyle.BackColor = RowBackground;
            dgv.RowTemplate.DefaultCellStyle.ForeColor = CellTextColor;
            dgv.RowTemplate.DefaultCellStyle.Font = RowFont;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = SelectionBackground;
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = SelectionTextColor;

            // RowsDefaultCellStyle
            dgv.RowsDefaultCellStyle.BackColor = RowBackground;
            dgv.RowsDefaultCellStyle.ForeColor = CellTextColor;
            dgv.RowsDefaultCellStyle.Font = RowFont;
            dgv.RowsDefaultCellStyle.SelectionBackColor = SelectionBackground;
            dgv.RowsDefaultCellStyle.SelectionForeColor = SelectionTextColor;

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = RowAltBackground;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = CellTextColor;
            dgv.AlternatingRowsDefaultCellStyle.Font = RowFont;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = SelectionBackground;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = SelectionTextColor;

            // Reset each column's font to ensure no column has mismatched font
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.DefaultCellStyle != null)
                {
                    col.DefaultCellStyle.Font = RowFont;
                }
                if (col.HeaderCell != null && col.HeaderCell.Style != null)
                {
                    col.HeaderCell.Style.Font = HeaderFont;
                }
            }

            if (dgv is Guna2DataGridView gunaDgv)
            {
                gunaDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
                gunaDgv.ThemeStyle.HeaderStyle.BackColor = PrimaryBlue;
                gunaDgv.ThemeStyle.HeaderStyle.ForeColor = HeaderText;
                gunaDgv.ThemeStyle.HeaderStyle.Font = HeaderFont;
                gunaDgv.ThemeStyle.HeaderStyle.Height = 42;
                gunaDgv.ThemeStyle.AlternatingRowsStyle.BackColor = RowAltBackground;
                gunaDgv.ThemeStyle.AlternatingRowsStyle.ForeColor = CellTextColor;
                gunaDgv.ThemeStyle.AlternatingRowsStyle.Font = RowFont;
                gunaDgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = SelectionBackground;
                gunaDgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = SelectionTextColor;
                gunaDgv.ThemeStyle.RowsStyle.BackColor = RowBackground;
                gunaDgv.ThemeStyle.RowsStyle.ForeColor = CellTextColor;
                gunaDgv.ThemeStyle.RowsStyle.Font = RowFont;
                gunaDgv.ThemeStyle.RowsStyle.Height = 40;
                gunaDgv.ThemeStyle.RowsStyle.SelectionBackColor = SelectionBackground;
                gunaDgv.ThemeStyle.RowsStyle.SelectionForeColor = SelectionTextColor;
                gunaDgv.ThemeStyle.GridColor = GridLineColor;
            }

            // Hook DataBindingComplete to re-enforce exact font after data loads
            dgv.DataBindingComplete -= Dgv_DataBindingComplete;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
        }

        private static void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                dgv.DefaultCellStyle.Font = RowFont;
                dgv.RowsDefaultCellStyle.Font = RowFont;
                dgv.AlternatingRowsDefaultCellStyle.Font = RowFont;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.DefaultCellStyle != null)
                    {
                        col.DefaultCellStyle.Font = RowFont;
                    }
                }
            }
        }
    }
}
