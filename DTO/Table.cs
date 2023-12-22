using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Table
    {
        public Table(
            int tableID,
            string tableName,
            string status)
        {
            this.tableID = tableID;
            this.tableName = tableName;
            this.status = status;
        }

        public int tableID { get; set; }
        public string tableName { get; set; }
        public string status { get; set; }

        public Table(DataRow row)
        {
            this.tableID = (int)row["tableID"];
            this.tableName = row["tableName"].ToString();
            this.status = row["status"].ToString();
        }
    }
}
