using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Account
    {
        public Account(
            string userName, 
            string passWord, 
            int employeeID, 
            string employeeName, 
            string address, 
            int phoneNumber, 
            string email, 
            string roleID, 
            string shiftID)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.roleID = roleID;
            this.shiftID = shiftID;
        }

        public Account(DataRow row) {
            this.userName = row["userName"].ToString();
            this.passWord = row["passWord"].ToString();
            this.employeeID = Convert.ToInt32(row["employeeID"]);
            this.employeeName = row["employeeName"].ToString();
            this.address = row["address"].ToString();
            this.phoneNumber = Convert.ToInt32(row["phoneNumber"]);
            this.email = row["email"].ToString();
            this.roleID = row["roleID"].ToString();
            this.shiftID = row["shiftID"].ToString();
        }

        public string userName { get; set; }
        public string passWord { get; set; }
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string address { get; set; }
        public int phoneNumber { get; set; }
        public string email { get; set; }
        public string roleID { get; set; }
        public string shiftID { get; set;}
    }
}
