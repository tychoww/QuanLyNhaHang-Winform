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
    public class InvoiceListViewDAO
    {
        private static InvoiceListViewDAO instance;

        public static InvoiceListViewDAO Instance
        {
            get { return instance ?? (instance = new InvoiceListViewDAO()); }
            private set { instance = value; }
        }

        private InvoiceListViewDAO() { }


        public List<InvoiceListView> getListInvoiceListViewByTable(int tableID)
        {
            List<InvoiceListView> listInvoiceListViewByTable = new List<InvoiceListView>();

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
                InvoiceListView invoicelistview = new InvoiceListView(item);
                listInvoiceListViewByTable.Add(invoicelistview);
            }


            return listInvoiceListViewByTable;
        }
    }
}
