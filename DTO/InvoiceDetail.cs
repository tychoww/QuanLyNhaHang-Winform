using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class InvoiceDetail
    {
        public InvoiceDetail(int invoiceID, int dishID, int quantity)
        {
            this.InvoiceID = invoiceID;
            this.DishID = dishID;
            this.Quantity = quantity;
        }

        public int InvoiceID { get; set; }
        public int DishID { get; set; }
        public int Quantity { get; set; }

        public InvoiceDetail(DataRow row)
        {
            this.InvoiceID = (int)row["InvoiceID"];
            this.DishID = (int)row["DishID"];
            this.Quantity = (int)row["Quantity"];
        }
    }
}
