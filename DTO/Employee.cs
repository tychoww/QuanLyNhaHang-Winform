using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Employee
    {
        public Employee(int employeeID, string employeeName, string phoneNumber, string passWord, string role)
        {
            this.EmployeeID = employeeID;
            this.EmployeeName = employeeName;
            this.PhoneNumber = phoneNumber;
            this.PassWord = passWord;
            this.Role = role;
        }

        public Employee(DataRow row)
        {
            this.EmployeeID = Convert.ToInt32(row["EmployeeID"]);
            this.EmployeeName = row["EmployeeName"].ToString();
            this.PhoneNumber = row["PhoneNumber"].ToString();
            this.PassWord = row["Password"].ToString();
            this.Role = row["Role"].ToString();
        }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    }
}
