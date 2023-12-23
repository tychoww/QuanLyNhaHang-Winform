using QuanLyNhaHang_Winform.DAO;
using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhaHang_Winform
{
    public partial class fAddNewCustomer : Form
    {
        private Customer _customerTemp;

        public fAddNewCustomer(Customer customerTemp)
        {
            InitializeComponent();
            _customerTemp = customerTemp;
        }

        private void fillCustomerInforByPhone(string phoneNumber)
        {
            Customer customerInfor = CustomerDAO.Instance.GetCustomerByPhoneNumber(phoneNumber);

            txtName.Text = customerInfor.CustomerName.ToString();
            txtAddress.Text = customerInfor.Address.ToString();
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            bool isExistingPhoneNumber = CustomerDAO.Instance.isExistingPhoneNumber(phoneNumber);

            if (isExistingPhoneNumber)
            {
                MessageBox.Show("Thông tin khách hàng được tìm thấy");
                fillCustomerInforByPhone(phoneNumber);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            bool isExistingPhoneNumber = CustomerDAO.Instance.isExistingPhoneNumber(phoneNumber);
            if (isExistingPhoneNumber)
            {
                _customerTemp = CustomerDAO.Instance.GetCustomerByPhoneNumber(phoneNumber);
            }
            else
            {
                _customerTemp.CustomerName = txtName.Text;
                _customerTemp.PhoneNumber = txtPhoneNumber.Text;
                _customerTemp.Address = txtAddress.Text;
            }
            DialogResult = DialogResult.OK; // Đặt giá trị DialogResult để phía TableManager có thể biết được là Form này đang đóng
            Close();
        }

        // Phương thức để lấy giá trị Customer từ form con
        public Customer GetCustomerData()
        {
            return _customerTemp;
        }
    }
}
