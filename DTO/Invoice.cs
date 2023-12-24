using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Invoice
    {
        public Invoice(int invoiceID, int customerID, int employeeID, int tableID, DateTime dateCheckin, DateTime dateCheckout, int status)
        {
            this.InvoiceID = invoiceID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.TableID = tableID;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = dateCheckout;
            this.Status = status;
        }

        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int TableID { get; set; }
        public DateTime DateCheckin { get; set; }
        public DateTime? DateCheckout { get; set; } // Sử dụng DateTime? để cho phép giá trị null
        public int Status { get; set; }

        public Invoice(DataRow row)
        {
            this.InvoiceID = (int)row["InvoiceID"];
            this.CustomerID = Convert.IsDBNull(row["CustomerID"]) ? 0 : (int)row["CustomerID"];
            this.EmployeeID = Convert.IsDBNull(row["EmployeeID"]) ? 0 : (int)row["EmployeeID"];
            this.TableID = (int)row["TableID"];
            this.DateCheckin = (DateTime)row["DateCheckin"];

            var dateCheckoutTemp = row["DateCheckout"];
            this.DateCheckout = dateCheckoutTemp != DBNull.Value ? (DateTime?)dateCheckoutTemp : null;

            this.Status = (int)row["Status"];
        }
    }

}
