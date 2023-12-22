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
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { return instance ?? (instance = new AccountDAO()); }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE Username = @Username AND Password = @Password";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = userName },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = passWord }
            };

            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);

            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string username)
        {
            string query = "SELECT * FROM Employee INNER JOIN Account ON Employee.EmployeeID = Account.EmployeeID WHERE Account.Username = @Username;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);


            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
    }
}
