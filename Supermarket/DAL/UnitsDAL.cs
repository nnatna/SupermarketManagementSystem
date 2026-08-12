using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class UnitsDAL
    {
        // READ - Get all units
        public List<Units> GetAllUnits()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Units.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Units>();
            }
        }

        // READ - Get unit by ID
        public Units GetUnitById(int unitId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Units.FirstOrDefault(u => u.UnitId == unitId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // CREATE - Add a new unit
        public bool AddUnit(Units unit)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Units.Add(unit);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Add Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Update existing unit
        public bool UpdateUnit(Units unit)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Units.FirstOrDefault(u => u.UnitId == unit.UnitId);
                    if (existing != null)
                    {
                        existing.UnitName = unit.UnitName;
                        existing.ShortName = unit.ShortName;
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Update Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        // DELETE - Delete unit by ID
        public bool DeleteUnit(int unitId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var unit = db.Units.FirstOrDefault(u => u.UnitId == unitId);
                    if (unit != null)
                    {
                        db.Units.Remove(unit);
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Delete Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
