using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { return instance ?? (instance = new CustomerDAO()); }
            private set { instance = value; }
        }

        private CustomerDAO() { }

        public bool isExistingPhoneNumber(string phoneNumber)
        {
            string query = "SELECT * FROM [Customer] WHERE PhoneNumber = @PhoneNumber";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = phoneNumber }
            };

            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);

            return result.Rows.Count > 0;
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            string query = "SELECT * FROM [Customer] WHERE PhoneNumber = @PhoneNumber;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = phoneNumber },
            };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);


            foreach (DataRow item in data.Rows)
            {
                return new Customer(item);
            }

            return null;
        }

        public void InsertCustomer(string customerName, string customerAdress, string CustomerPhoneNumber)
        {
            string query = "INSERT INTO [Customer] (CustomerName, Address, PhoneNumber)" +
                "VALUES (@CustomerName, @Address, @PhoneNumber);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerName", SqlDbType.NVarChar) { Value = customerName },
                new SqlParameter("@Address", SqlDbType.NVarChar) { Value = customerAdress },
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = CustomerPhoneNumber }
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public int GetMaxCustomerID()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(CustomerID) FROM [Customer]");
            }
            catch
            {
                return 1;
            }
        }
    }
}
