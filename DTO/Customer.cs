using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DTO
{
    public class Customer
    {
        public Customer(int customerID, string customerName, string address, string phoneNumber)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public Customer(DataRow row)
        {
            this.CustomerID = (int)row["CustomerID"];
            this.CustomerName = row["CustomerName"].ToString();
            this.Address = row["Address"].ToString();
            this.PhoneNumber = row["PhoneNumber"].ToString();
        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
