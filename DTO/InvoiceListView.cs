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
        public InvoiceListView(string dishName, int quantity, double price = 0, double totalPrice = 0)
        {
            this.DishName = dishName;
            this.Quantity = quantity;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public string DishName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public InvoiceListView(DataRow row)
        {
            this.DishName = row["DishName"].ToString();
            this.Quantity = (int)row["Quantity"];
            this.Price = Convert.ToDouble(row["Price"].ToString());
            this.TotalPrice = Convert.ToDouble(row["TotalPrice"].ToString());
        }
    }

}
