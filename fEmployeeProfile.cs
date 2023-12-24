using QuanLyNhaHang_Winform.DAO;
using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang_Winform
{
    public partial class fEmployeeProfile : Form
    {
        private Employee currentEmployee;
        private List<KeyValuePair<string, string>> RoleData;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value;}
        }

        public fEmployeeProfile(Employee emp)
        {
            InitializeComponent();
            this.currentEmployee = emp;

            RoleData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("employee", "Nhân viên"),
                new KeyValuePair<string, string>("admin", "Quản lý"),
            };

            // Thiết lập ComboBox
            cboRole.DisplayMember = "Value";    // Thuộc tính hiển thị
            cboRole.ValueMember = "Key";        // Thuộc tính giá trị
            cboRole.DataSource = RoleData;

            fillCurrentEmployeeData();
            ChangeAccount(currentEmployee.Role);
        }

        void ChangeAccount(string role)
        {
            txtEmployeeName.ReadOnly = role != "admin";
            txtPhoneNumber.ReadOnly = role != "admin";
            cboRole.Enabled = role == "admin";
        }

        void fillCurrentEmployeeData()
        {
            txtEmployeeName.Text = currentEmployee.EmployeeName;
            txtPhoneNumber.Text = currentEmployee.PhoneNumber;
            txtPassWord.Text = currentEmployee.PassWord;
            txtNewPassWord.Text = currentEmployee.PassWord;
            txtReEnteredPassword.Text = currentEmployee.PassWord;
            if (currentEmployee.Role == "admin")
            {
                cboRole.SelectedItem = RoleData.FirstOrDefault(x => x.Key == "admin");
            }
            else
            {
                cboRole.SelectedItem = RoleData.FirstOrDefault(x => x.Key == "employee");
            }
        }

        private bool IsPasswordMatching(string newPassword, string reEnteredPassword)
        {
            return newPassword == reEnteredPassword;
        }

        static bool IsValidInput(string input)
        {
            // Kiểm tra chuỗi không rỗng
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            // Kiểm tra không có dấu cách
            if (input.Contains(" "))
            {
                return false;
            }

            // Kiểm tra không có ký tự đặc biệt
            if (Regex.IsMatch(input, "[^a-zA-Z0-9]"))
            {
                return false;
            }

            return true;
        }

        void UpdateAccount()
        {
            int employeeID = currentEmployee.EmployeeID;
            string employeeName = txtEmployeeName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string role = cboRole.SelectedValue.ToString();
            string newPassWord = txtNewPassWord.Text;
            string reEnteredPassword = txtReEnteredPassword.Text;

            // Kiểm tra xem mật khẩu nhập lại có khớp không
            if (IsPasswordMatching(newPassWord, reEnteredPassword) && IsValidInput(newPassWord))
            {
                // Tiến hành cập nhật thông tin
                EmployeeDAO.Instance.UpdateEmployee(employeeName, phoneNumber, newPassWord, role, employeeID);

                DialogResult = DialogResult.OK; // Đặt giá trị DialogResult để phía TableManager có thể biết được là Form này đang đóng
                // Hiển thị thông báo cập nhật thành công hoặc thất bại
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Hãy nhập đủ thông tin, và không có ký tự đặc biệt!");
            }
        }

        #region Events
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

