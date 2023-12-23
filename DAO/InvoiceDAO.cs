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
    public class InvoiceDAO
    {

        private static InvoiceDAO instance;

        public static InvoiceDAO Instance
        {
            get { return instance ?? (instance = new InvoiceDAO()); }
            private set { instance = value; }
        }
        private InvoiceDAO() { }

        // Thành công: Bill ID
        // Thất bại: -1
        public int getUncheckInvoiceByTableID(int tableID)
        {

            string query = "SELECT * FROM [Invoice] WHERE TableID = @TableID AND Status = @Status";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", SqlDbType.Int) { Value = tableID },
                new SqlParameter("@Status", SqlDbType.Int) { Value = 0 }
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                Invoice invoice = new Invoice(data.Rows[0]);
                return invoice.invoiceID;
            }
            return -1;
        }

        public void InsertInvoice(int tableID)
        {
            string query = "INSERT INTO [Invoice] (CustomerID, EmployeeID, TableID, DateCheckin, DateCheckout, Status)" +
                "VALUES (null, null, @TableID, GETDATE(), null, 0);";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", SqlDbType.Int) { Value = tableID }
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public int GetMaxInvoiceID()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(InvoiceID) FROM [Invoice]");
            }
            catch
            {
                return 1;
            }
        }
    }
}
