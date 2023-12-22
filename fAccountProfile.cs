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
    public partial class fAccountProfile : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txtUserName.Text = LoginAccount.userName;  
        }

        void UpdateAccount()
        {
            string currentTabName = tcUserInfor.SelectedTab.Name;
            if (currentTabName == tpUserLogin.Name)
            {
                MessageBox.Show("Thông tin cá nhân");
                string userName = txtUserName.Text;
                string passWord = txtPassWord.Text;
                string newPassWord = txtNewPassWord.Text;
                string reNewPassWord = txtReNewPassWord.Text;
            }
            else if (currentTabName == tpUserResume.Name)
            {
                MessageBox.Show("Hồ sơ lý lịch");
                string phoneNumber = txtPhoneNumber.Text;
                string email = txtEmail.Text;
                string employeeName = txtEmployeeName.Text;
                string address = txtAddress.Text;

                object shiftSelected = cboShift.SelectedValue;
                int shiftID = Convert.ToInt32(shiftSelected);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
