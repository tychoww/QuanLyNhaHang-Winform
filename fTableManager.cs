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
            txtInvoicingEmployee.Text = loginAccount.employeeName + " (" + loginAccount.phoneNumber + ")";
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

            List<InvoiceListView> listInvoiceListView = InvoiceListViewDAO.Instance.getListInvoiceListViewByTable(tableId);
            double totalPrice = 0;

            if (listInvoiceListView.Count > 0)
            {
                foreach (InvoiceListView item in listInvoiceListView)
                {
                    ListViewItem lsvItem = new ListViewItem(item.dishName.ToString());
                    lsvItem.SubItems.Add(item.quantity.ToString());
                    lsvItem.SubItems.Add(item.price.ToString());
                    lsvItem.SubItems.Add(item.totalPrice.ToString());
                    totalPrice += item.totalPrice;
                    lstvInvoiceInfor.Items.Add(lsvItem);
                }
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
            Table table = (sender as Button).Tag as Table;
            int tableId = table.tableID;
            lblTableSelected.Text = table.tableName;
            lstvInvoiceInfor.Tag = (sender as Button).Tag;
            showInvoice(tableId);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;

            Category selected = cb.SelectedItem as Category;
            id = selected.categoryID;

            loadDishListByCategoryID(id);
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            Table table = lstvInvoiceInfor.Tag as Table; // Lấy ra Table hiện tại

            int invoiceID = InvoiceDAO.Instance.getUncheckInvoiceByTableID(table.tableID);
            int dishID = (cboDish.SelectedItem as Dish).dishID;
            int quanity = (int)nudDishQuantity.Value;

            if (invoiceID == -1) // Table chưa có Invoice
            {
                // Tạo Invoice mới dựa vào Table
                InvoiceDAO.Instance.InsertInvoice(table.tableID);
                // Insert InvoiceDetail
                InvoiceDetailDAO.Instance.InsertInvoiceDetail(InvoiceDAO.Instance.GetMaxInvoiceID(), dishID, quanity);
            }
            else // Nếu Table đã có Invoice
            {
                // Nếu Invoice Detail đã tồn tại Dish thì update số lượng (Quantity)
                if (InvoiceDetailDAO.Instance.isExistingDishInInvoicedetail(invoiceID, dishID))
                {
                    InvoiceDetailDAO.Instance.UpdateInvoiceDetail(invoiceID, dishID, quanity);
                }
                // Nếu Invoice Detail chưa tồn tại Dish thì insert theo số lượng (Quantity)
                else
                {
                    InvoiceDetailDAO.Instance.InsertInvoiceDetail(invoiceID, dishID, quanity);
                }
            }

            showInvoice(table.tableID);
        }
        #endregion

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Table table = lstvInvoiceInfor.Tag as Table;
            Customer customer = txtPayingCustomer.Tag as Customer;

            int invoiceID = InvoiceDAO.Instance.getUncheckInvoiceByTableID(table.tableID);
            int employeeID = loginAccount.employeeID;
            int? customerID;

            if(customer == null) // Nhân viên chưa nhập thông tin khách hàng
            {
                customerID = null;
            }
            else // Đã nhập thông tin khác hàng
            {
                if(customer.customerID == 0) // Nếu khách hàng chưa tồn tại trong hệ thống => Tạo mới khách hàng
                {
                    CustomerDAO.Instance.InsertCustomer(customer.CustomerName, customer.Address, customer.PhoneNumber);
                    customerID = CustomerDAO.Instance.GetMaxCustomerID();
                }
                else
                {
                    customerID = customer.customerID;
                }
            }

            if (invoiceID != -1)
            {
                if (MessageBox.Show("Thực hiện thanh toán cho: " + table.tableName, "Xác nhận thanh toán", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    InvoiceDAO.Instance.CheckOut(invoiceID, customerID, employeeID);
                    showInvoice(table.tableID);
                    txtPayingCustomer.Clear();
                }
            }
        }

        private void txtPayingCustomer_Click(object sender, EventArgs e)
        {
            Customer customerTemp = new Customer(0, "0", "0", "0"); // Khởi tạo giá trị mặc định tránh gây lỗi định dạng

            using (fAddNewCustomer f = new fAddNewCustomer(customerTemp))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {   // Lấy giá trị từ form con sau khi nó đóng
                    Customer updatedCustomer = f.GetCustomerData();

                    txtPayingCustomer.Text = $"{updatedCustomer.CustomerName}, {updatedCustomer.PhoneNumber}, {updatedCustomer.Address}";
                    txtPayingCustomer.Tag = updatedCustomer;
                }
            }
        }
    }
}
