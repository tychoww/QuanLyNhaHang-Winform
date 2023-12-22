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
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.roleID); }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

            LoadTable();
        }

        #region Methods
        void ChangeAccount(string roleID)
        {
            quảnLýToolStripMenuItem.Enabled = roleID == "admin";
            thôngTinCáNhânToolStripMenuItem.Text += " (" + loginAccount.employeeName + ")";
        }

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Tag = item; // Lưu dữ liệu vào table

                switch (item.status)
                {
                    case "reserved":
                        btn.BackColor = Color.LightPink;
                        btn.Text = item.tableName + Environment.NewLine + "Có người";
                        break;
                    case "available":
                        btn.BackColor = Color.LightBlue;
                        btn.Text = item.tableName + Environment.NewLine + "Trống";
                        break;
                    case "occupied":
                        btn.BackColor = Color.LightYellow;
                        btn.Text = item.tableName + Environment.NewLine + "Đã đặt";
                        break;
                    default:
                        btn.BackColor = Color.LightBlue;
                        btn.Text = item.tableName + Environment.NewLine + "Trống";
                        break;

                }
                flpTable.Controls.Add(btn);
            }
        }
        #endregion

        #region Events
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.ShowDialog();
        }
        #endregion
    }
}
