using QuanLyNhaHang_Winform.DAO;
using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            LoadCategory();
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.getListCategory();
            cboCategory.DataSource = listCategory;
            cboCategory.DisplayMember = "categoryName";
        }

        void loadDishListByCategoryID(int categoryID)
        {
            List<Dish> listDish = DishDAO.Instance.getDishBytCategoryID(categoryID);
            cboDish.DataSource = listDish;
            cboDish.DisplayMember = "dishName";
        } 

        #region Methods
        void ChangeAccount(string roleID)
        {
            quảnTrịToolStripMenuItem.Enabled = roleID == "admin";
            thôngTinCáNhânToolStripMenuItem.Text += " (" + loginAccount.employeeName + ")";
        }

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Click += btn_Click;
                btn.Tag = item; // Lưu dữ liệu của table vào object Tag, để lưu dữ liệu của các component

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

        void showInvoice(int tableId)
        {
            lstvInvoiceInfor.Items.Clear();

            List<InvoiceCheckout> listInvoiceCheckout = InvoiceCheckoutDAO.Instance.getListInvoiceCheckoutByTable(tableId);
            double totalPrice = 0;

            foreach (InvoiceCheckout item in listInvoiceCheckout)
            {
                ListViewItem lsvItem = new ListViewItem(item.dishName.ToString());
                lsvItem.SubItems.Add(item.quantity.ToString());
                lsvItem.SubItems.Add(item.price.ToString());
                lsvItem.SubItems.Add(item.totalPrice.ToString());
                totalPrice += item.totalPrice;
                lstvInvoiceInfor.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;

            txtTotalPrice.Text = totalPrice.ToString("c", culture);
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

        private void btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).tableID;
            showInvoice(tableId);
        }
        #endregion

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;

            Category selected = cb.SelectedItem as Category;
            id = selected.categoryID;

            loadDishListByCategoryID(id);
        }
    }
}
