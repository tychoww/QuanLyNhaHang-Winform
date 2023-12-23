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
        public Customer(
            int customerID,
            string customerName,
            string address,
            string phoneNumber)
        {
            this.customerID = customerID;
            this.CustomerName = customerName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public Customer(DataRow row)
        {
            this.customerID = (int)row["customerID"];
            this.CustomerName = row["customerName"].ToString();
            this.Address = row["address"].ToString();
            this.PhoneNumber = row["phoneNumber"].ToString();
        }

        public int customerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
