using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            string query = "SELECT D.DishName, INVD.Quantity, D.Price, D.Price * INVD.Quantity as 'TotalPrice'" +
                " FROM [Dish] AS D, [Invoice_Detail] AS INVD, [Invoice] AS INV" +
                " WHERE INVD.InvoiceID = INV.InvoiceID AND D.DishID = INVD.DishID AND INV.Status = 0 AND INV.TableID = @TableID;";

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
