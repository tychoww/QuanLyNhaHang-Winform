using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhaHang_Winform.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { return instance ?? (instance = new EmployeeDAO()); }
            private set { instance = value; }
        }

        private EmployeeDAO() { }

        public bool Login(string phoneNumber, string passWord)
        {
            string query = "SELECT * FROM [Employee] WHERE PhoneNumber = @PhoneNumber AND Password = @Password";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = phoneNumber },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = passWord }
            };

            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);

            return result.Rows.Count > 0;
        }

        public Employee GetEmployeeByPhoneNumber(string phoneNumber)
        {
            string query = "SELECT * FROM [Employee] WHERE PhoneNumber = @PhoneNumber;";

            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = phoneNumber }
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);


            foreach (DataRow item in data.Rows)
            {
                return new Employee(item);
            }

            return null;
        }
    }
}
