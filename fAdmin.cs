using QuanLyNhaHang_Winform.DAO;
using QuanLyNhaHang_Winform.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyNhaHang_Winform
{
    public partial class fAdmin : Form
    {
        BindingSource dishList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            Load();
            AddFoodBinding();
            LoadDateTimePickerBill();
            LoadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        void Load()
        {
            grdDish.DataSource = dishList; // Fix this line
            LoadListDish();
            LoadCategoryIntoCombobox(cboDishCategory);
        }

        #region Statistics Methods
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListInvoiceByDate(DateTime dateCheckin, DateTime dateCheckout)
        {
            grdStatistics.DataSource = InvoiceDAO.Instance.GetOverallStatisticsByDate(dateCheckin, dateCheckout);
        }

        #endregion

        #region Dish Methods
        void AddFoodBinding()
        {
            grdDish.DataSource = dishList; // Add this line

            // true chấp nhận ép kiểu hay không
            // DataSourceUpdateMode.Never chỉ có chiều csdl qua và không có ngược lại
            txtDishID.DataBindings.Add(new Binding("Text", dishList, "DishID", true, DataSourceUpdateMode.Never));
            txtDishName.DataBindings.Add(new Binding("Text", dishList, "DishName", true, DataSourceUpdateMode.Never));
            nudDishPrice.DataBindings.Add(new Binding("Value", dishList, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.getListCategory();
            cb.DisplayMember = "CategoryName";
        }

        void LoadListDish()
        {
            dishList.DataSource = DishDAO.Instance.getListDish();
        }

        List<Dish> SeachDishByName(string dishName)
        {
            List<Dish> listDish = DishDAO.Instance.searchDishByName(dishName);

            return listDish;
        }
        #endregion

        #region Events
        private void btnShowDish_Click(object sender, EventArgs e)
        {
            LoadListDish();
        }
        private void txtDishID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdDish.SelectedCells.Count > 0 && grdDish.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
                {
                    int id = (int)grdDish.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cboDishCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cboDishCategory.Items)
                    {
                        if (item.CategoryID == category.CategoryID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cboDishCategory.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it for further investigation
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            string dishName = txtDishName.Text;
            double price = (double)nudDishPrice.Value;
            int categoryID = (cboDishCategory.SelectedItem as Category).CategoryID;

            if (DishDAO.Instance.InsertDish(dishName, price, categoryID))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListDish();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món ăn");
            }
        }

        private void btnUpdateDish_Click(object sender, EventArgs e)
        {
            int dishID = Convert.ToInt32(txtDishID.Text);
            string dishName = txtDishName.Text;
            double price = (double)nudDishPrice.Value;
            int categoryID = (cboDishCategory.SelectedItem as Category).CategoryID;

            if (DishDAO.Instance.UpdateDish(dishID, dishName, price, categoryID))
            {
                MessageBox.Show("Cập nhật món thành công");
                LoadListDish();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật thêm món ăn");
            }
        }

        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            int dishID = Convert.ToInt32(txtDishID.Text);

            if (DishDAO.Instance.DeleteDishByID(dishID))
            {
                MessageBox.Show("Xoá món thành công");
                LoadListDish();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật xoá món ăn");
            }
        }

        private void btnSearchDish_Click(object sender, EventArgs e)
        {
            dishList.DataSource = SeachDishByName(txtDishNameSearch.Text);
        }

        #endregion

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            LoadListInvoiceByDate(dtpkFromDate.Value.Date, dtpkToDate.Value.Date);
        }
    }
   
}
