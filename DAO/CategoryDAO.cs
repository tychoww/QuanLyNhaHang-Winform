using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { return instance ?? (instance = new CategoryDAO()); }
            private set { instance = value; }
        }
        public CategoryDAO() { }

        public List<Category> getListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category Category = new Category(item);
                list.Add(Category);
            }

            return list;
        }
    }
}
