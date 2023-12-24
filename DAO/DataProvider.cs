using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { return instance ?? (instance = new DataProvider()); }
            private set { instance = value; }
        }

        private string connectionString = "server =(local); database = QuanLyNhaHang2; integrated security = true; ";

        private DataProvider() { }

        // Thực hiện truy vấn SQL và trả về một DataTable chứa kết quả của truy vấn.
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm parameters nếu có
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }


        // Thực hiện các truy vấn không trả về dữ liệu (ví dụ: INSERT, UPDATE, DELETE) và trả về số dòng ảnh hưởng.
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm parameters nếu có
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    data = command.ExecuteNonQuery();
                }
            }

            return data;
        }

        // Trả về giá trị của ô đầu tiên trong kết quả truy vấn.
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object data = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm parameters nếu có
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    data = command.ExecuteScalar();
                }
            }

            return data;
        }
    }
}
