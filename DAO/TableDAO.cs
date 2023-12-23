using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhaHang_Winform.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance { 
            get { return instance ?? (instance = new TableDAO()); }
            private set { instance = value; }
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;

        private TableDAO() { }


        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            string query = "SELECT * FROM [Table];";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
