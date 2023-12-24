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

namespace QuanLyNhaHang_Winform
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        bool Login (string phoneNumber, string passWord)
        {
            return EmployeeDAO.Instance.Login(phoneNumber, passWord);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            string passWord = txtPassWord.Text;
            if (Login(phoneNumber, passWord))
            {
                Employee currentEmployee = EmployeeDAO.Instance.GetEmployeeByPhoneNumber(phoneNumber);
                fTableManager f = new fTableManager(currentEmployee);

                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
