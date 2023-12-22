using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang_Winform.DAO
{
    public class InvoiceCheckoutDAO
    {
        private static InvoiceCheckoutDAO instance;

        public static InvoiceCheckoutDAO Instance
        {
            get { return instance ?? (instance = new InvoiceCheckoutDAO()); }
            private set { instance = value; }
        }

        private InvoiceCheckoutDAO() { }


        public List<InvoiceCheckout> getListInvoiceCheckoutByTable(int tableID)
        {
            List<InvoiceCheckout> listInvoiceCheckoutByTable = new List<InvoiceCheckout>();

            string query = "SELECT [Dish].DishName, [Invoice_Detail].Quantity, [Dish].Price, [Dish].Price*[Invoice_Detail].Quantity as 'TotalPrice' " +
                "FROM [Dish], [Invoice_Detail], [Invoice]\r\n" +
                "WHERE [Invoice_Detail].InvoiceID = [Invoice].InvoiceID AND [Invoice].Status = 0 AND [Invoice].TableID = @TableID;";

            // Sử dụng parameters để ngăn chặn SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", SqlDbType.Int) { Value = tableID },
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow item in data.Rows) {
                InvoiceCheckout invoicecheckout = new InvoiceCheckout(item);
                listInvoiceCheckoutByTable.Add(invoicecheckout);
            }


            return listInvoiceCheckoutByTable;
        }
    }
}
