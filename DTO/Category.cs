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
        public Category(
            int categoryID,
            string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public Category(DataRow row)
        {
            this.categoryID = (int)row["categoryID"];
            this.categoryName = row["categoryName"].ToString();
        }

        public int categoryID { get; set; }
        public string categoryName { get; set; }
    }
}