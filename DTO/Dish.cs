using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Dish
    {
        public Dish(
            int dishID,
            string dishName,
            double price,
            int categoryID)
        {
            this.dishID = dishID;
            this.dishName = dishName;
            this.price = price;
            this.categoryID = categoryID;
        }

        public Dish(DataRow row)
        {
            this.dishID = (int)row["dishID"];
            this.dishName = row["dishName"].ToString();
            this.price = Convert.ToDouble(row["price"].ToString());
            this.categoryID = (int)row["categoryID"];
        }

        public int dishID { get; set; }
        public string dishName { get; set; }
        public double price { get; set; }
        public int categoryID { get; set; }
    }

}
