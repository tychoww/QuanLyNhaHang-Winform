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

        public List<Dish> getListDish()
        {
            List<Dish> listDish = new List<Dish>();

            string query = "SELECT * FROM [Dish]";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Dish dish = new Dish(item);
                listDish.Add(dish);
            }

            return listDish;
        }

        public List<Dish> searchDishByName(string dishName)
        {
            List<Dish> listDish = new List<Dish>();

            string query = "SELECT * FROM [Dish] WHERE DishName LIKE '%' + @DishName + '%';";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DishName", SqlDbType.NVarChar) { Value = dishName },
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow item in data.Rows)
            {
                Dish dish = new Dish(item);
                listDish.Add(dish);
            }

            return listDish;
        }

        public bool InsertDish(string dishName, double price, int categoryID)
        {
            string query = "INSERT INTO [Dish] (DishName, Price, CategoryID) VALUES (@DishName, @Price, @CategoryID);";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@DishName", SqlDbType.NVarChar) { Value = dishName },
            new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
            new SqlParameter("@CategoryID", SqlDbType.Int) { Value = categoryID }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public bool DeleteDishByID(int dishID)
        {
            string query = "DELETE FROM [Dish] WHERE DishID = @DishID;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DishID", SqlDbType.Int) { Value = dishID },
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public bool UpdateDish(int dishID, string dishName, double price, int categoryID)
        {
            string query = "UPDATE [Dish] SET DishName = @DishName, Price = @Price, CategoryID=@CategoryID"+
                            " WHERE DishID = @DishID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DishID", SqlDbType.Int) { Value = dishID },
                new SqlParameter("@DishName", SqlDbType.NVarChar) { Value = dishName },
                new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
                new SqlParameter("@CategoryID", SqlDbType.Int) { Value = categoryID }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }
    }
}
