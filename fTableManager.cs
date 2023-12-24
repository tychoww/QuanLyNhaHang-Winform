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
        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; ChangeAccount(currentEmployee.Role); }
        }

        public fTableManager(Employee emp)
        {
            InitializeComponent();
            this.CurrentEmployee = emp;

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
        void ChangeAccount(string role)
        {
            quảnTrịToolStripMenuItem.Enabled = role == "admin";
            thôngTinCáNhânToolStripMenuItem.Text += " (" + currentEmployee.EmployeeName + ")";
            txtInvoicingEmployee.Text = currentEmployee.EmployeeName + " (" + currentEmployee.PhoneNumber + ")";
        }

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Click += btn_Click;
                btn.Tag = item; // Lưu dữ liệu của table vào object Tag, để lưu dữ liệu của các component

                switch (item.Status)
                {
                    case "occupied":
                        btn.BackColor = Color.LightPink;
                        btn.Text = item.TableName + Environment.NewLine + "Có người";
                        break;
                    case "available":
                        btn.BackColor = Color.LightBlue;
                        btn.Text = item.TableName + Environment.NewLine + "Trống";
                        break;
                    default:
                        btn.BackColor = Color.LightBlue;
                        btn.Text = item.TableName + Environment.NewLine + "Trống";
                        break;

                }
                flpTable.Controls.Add(btn);
            }
        }

        void showInvoice(int tableID)
        {
            lstvInvoiceInfor.Items.Clear();

            List<InvoiceListView> listInvoiceListView = InvoiceListViewDAO.Instance.getListInvoiceListViewByTable(tableID);
            double totalPrice = 0;

            if (listInvoiceListView.Count > 0)
            {
                foreach (InvoiceListView item in listInvoiceListView)
                {
                    ListViewItem lsvItem = new ListViewItem(item.DishName.ToString());
                    lsvItem.SubItems.Add(item.Quantity.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());
                    totalPrice += item.TotalPrice;
                    lstvInvoiceInfor.Items.Add(lsvItem);
                }
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;

            txtTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        void ChangeTableStatus(int tableID)
        {
            Button btn = flpTable.Controls.OfType<Button>().FirstOrDefault(b => (b.Tag as Table).TableID == tableID);

            if (btn != null)
            {
                if (InvoiceDAO.Instance.CheckPaidInvoiceByTableID(tableID))
                {
                    TableDAO.Instance.ChangeStatusTable(tableID, "occupied");
                    btn.BackColor = Color.LightPink;
                    btn.Text = (btn.Tag as Table).TableName + Environment.NewLine + "Có người";
                }
                else
                {
                    TableDAO.Instance.ChangeStatusTable(tableID, "available");
                    btn.BackColor = Color.LightBlue;
                    btn.Text = (btn.Tag as Table).TableName + Environment.NewLine + "Trống";
                }
            }
        }


        private void btn_Click(object sender, EventArgs e)
        {
            Table table = (sender as Button).Tag as Table;
            int tableId = table.TableID;
            lblTableSelected.Text = table.TableName;
            lstvInvoiceInfor.Tag = (sender as Button).Tag;
            showInvoice(tableId);
        }
        #endregion

        #region Events
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (fEmployeeProfile f = new fEmployeeProfile(CurrentEmployee))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {   // Update lại currentEmployee
                    this.Close();
                }
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;

            Category selected = cb.SelectedItem as Category;
            id = selected.CategoryID;

            loadDishListByCategoryID(id);
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            Table table = lstvInvoiceInfor.Tag as Table; // Lấy ra Table hiện tại

            int invoiceID = InvoiceDAO.Instance.getUncheckInvoiceByTableID(table.TableID);
            int dishID = (cboDish.SelectedItem as Dish).DishID;
            int quanity = (int)nudDishQuantity.Value;

            if (invoiceID == -1) // Table chưa có Invoice
            {
                // Tạo Invoice mới dựa vào Table
                InvoiceDAO.Instance.InsertInvoice(table.TableID);
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
            showInvoice(table.TableID);
            ChangeTableStatus(table.TableID);
        }
        #endregion

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Table table = lstvInvoiceInfor.Tag as Table;
            Customer customer = txtPayingCustomer.Tag as Customer;

            int invoiceID = InvoiceDAO.Instance.getUncheckInvoiceByTableID(table.TableID);
            int employeeID = currentEmployee.EmployeeID;
            int? customerID;

            if (customer == null) // Nhân viên chưa nhập thông tin khách hàng
            {
                customerID = null;
            }
            else // Đã nhập thông tin khác hàng
            {
                if (customer.CustomerID == 0) // Nếu khách hàng chưa tồn tại trong hệ thống => Tạo mới khách hàng
                {
                    CustomerDAO.Instance.InsertCustomer(customer.CustomerName, customer.Address, customer.PhoneNumber);
                    customerID = CustomerDAO.Instance.GetMaxCustomerID();
                }
                else // Khách hàng đã tồn tại trong hệ thống => lấy luôn id khách hàng
                {
                    customerID = customer.CustomerID;
                }
            }

            if (invoiceID != -1)
            {
                if (MessageBox.Show("Thực hiện thanh toán cho: " + table.TableName, "Xác nhận thanh toán", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    InvoiceDAO.Instance.CheckOut(invoiceID, customerID, employeeID);
                    showInvoice(table.TableID);
                    txtPayingCustomer.Clear();
                    txtPayingCustomer.Tag = null;
                    ChangeTableStatus(table.TableID);
                    LoadTable();
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

        private void quảnTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
            this.Show();
        }
    }
}