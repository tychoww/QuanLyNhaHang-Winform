using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DAO
{
    public class InvoiceDetailDAO
    {
        private static InvoiceDetailDAO instance;

        public static InvoiceDetailDAO Instance
        {
            get { return instance ?? (instance = new InvoiceDetailDAO()); }
            private set { instance = value; }
        }

        public InvoiceDetailDAO() { }

        public List<InvoiceDetail> GetListInvoiceDetail(int inVoiceID)
        {
            List<InvoiceDetail> listInvoiceDetail = new List<InvoiceDetail>();

            string query = "SELECT * FROM [Invoice_Detail] WHERE InvoiceID = @InvoiceID";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = inVoiceID },
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow item in data.Rows)
            {
                InvoiceDetail info = new InvoiceDetail(item);
                listInvoiceDetail.Add(info);
            }

            return listInvoiceDetail;
        }


        public void InsertInvoiceDetail(int invoiceID, int dishID, int quantity)
        {
            string query = "INSERT INTO [Invoice_Detail] (InvoiceID, DishID, Quantity) VALUES (@InvoiceID, @DishID, @Quantity);";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@DishID", SqlDbType.Int) { Value = dishID },
                new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdateInvoiceDetail(int invoiceID, int dishID, int quantity)
        {
            string query = "UPDATE [Invoice_Detail] SET Quantity += @Quantity" +
                " WHERE InvoiceID = @InvoiceID AND DishID = @DishID";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@DishID", SqlDbType.Int) { Value = dishID },
                new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public bool isExistingDishInInvoicedetail(int invoiceID, int dishID)
        {
            string query = "SELECT COUNT(*) FROM Invoice_Detail WHERE InvoiceID = @InvoiceID AND DishID = @DishID;";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceID },
                new SqlParameter("@DishID", SqlDbType.Int) { Value = dishID }
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);

            // Kiểm tra xem giá trị trả về có phải là null hay không
            return result != null && (int)result != 0;
        }

    }
}
