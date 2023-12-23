using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class InvoiceListView
    {
        public InvoiceListView(
            string dishName,
            int quantity,
            double price = 0,
            double totalPrice = 0)
        {
            this.dishName = dishName;
            this.quantity = quantity;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public string dishName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double totalPrice { get; set; }

        public InvoiceListView(DataRow row)
        {
            this.dishName = (string)row["dishName"];
            this.quantity = (int)row["quantity"];
            this.price = Convert.ToDouble(row["price"].ToString());
            this.totalPrice = Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}
