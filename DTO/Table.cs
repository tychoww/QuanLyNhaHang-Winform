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
        public Table(int tableID, string tableName, string status)
        {
            this.TableID = tableID;
            this.TableName = tableName;
            this.Status = status;
        }

        public int TableID { get; set; }
        public string TableName { get; set; }
        public string Status { get; set; }

        public Table(DataRow row)
        {
            this.TableID = (int)row["TableID"];
            this.TableName = row["TableName"].ToString();
            this.Status = row["Status"].ToString();
        }
    }

}
