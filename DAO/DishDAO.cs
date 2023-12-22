using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhaHang_Winform.DAO
{
    public class DishDAO
    {
        private static DishDAO instance;

        public static DishDAO Instance
        {
            get { return instance ?? (instance = new DishDAO()); }
            private set { instance = value; }
        }
        public DishDAO() { }

        public List<Dish> getDishBytCategoryID(int categoryID)
        {
            List<Dish> listDishByCategoryID = new List<Dish>();

            string query = "SELECT * FROM [Dish] WHERE CategoryID = @CategoryID";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", SqlDbType.Int) { Value = categoryID }
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow item in data.Rows)
            {
                Dish dish = new Dish(item);
                listDishByCategoryID.Add(dish);
            }

            return listDishByCategoryID;
        }
    }
}
