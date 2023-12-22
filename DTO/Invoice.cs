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
        public Invoice(
            int invoiceID,
            int customerID,
            int employeeID,
            int tableID,
            DateTime dateCheckin,
            DateTime dateCheckout,
            int status)
        {
            this.invoiceID = invoiceID;
            this.customerID = customerID;
            this.employeeID = employeeID;
            this.tableID = tableID;
            this.dateCheckin = dateCheckin;
            this.dateCheckout = dateCheckout;
            this.status = status;
        }

        public int invoiceID { get; set; }
        public int customerID { get; set; }
        public int employeeID { get; set; }
        public int tableID { get; set; }
        public DateTime dateCheckin { get; set; }
        public DateTime dateCheckout { get; set; }
        public int status { get; set; }

        public Invoice(DataRow row)
        {
            this.invoiceID = (int)row["invoiceID"];
            this.customerID = (int)row["customerID"];
            this.employeeID = (int)row["employeeID"];
            this.tableID = (int)row["tableID"];
            this.dateCheckin = (DateTime)row["dateCheckin"];

            var dateCheckoutTemp = row["dateCheckout"];
            if(dateCheckoutTemp.ToString() != "")
            {
                this.dateCheckout = (DateTime)dateCheckoutTemp;
            }
            this.status = (int)row["status"];
        }
    }
}
