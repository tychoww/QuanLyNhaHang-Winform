using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Category
    {
        public Category(int categoryID, string categoryName)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
        }

        public Category(DataRow row)
        {
            this.CategoryID = (int)row["CategoryID"];
            this.CategoryName = row["CategoryName"].ToString();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}