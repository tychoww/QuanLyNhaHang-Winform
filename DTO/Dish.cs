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
        public Dish(int dishID, string dishName, double price, int categoryID)
        {
            this.DishID = dishID;
            this.DishName = dishName;
            this.Price = price;
            this.CategoryID = categoryID;
        }

        public Dish(DataRow row)
        {
            this.DishID = (int)row["DishID"];
            this.DishName = row["DishName"].ToString();
            this.Price = Convert.ToDouble(row["Price"].ToString());
            this.CategoryID = (int)row["CategoryID"];
        }

        public int DishID { get; set; }
        public string DishName { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
    }
}
