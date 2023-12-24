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
    public partial class fAdmin : Form
    {
        BindingSource dishList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            Load();
            AddFoodBinding();
        }

        void Load()
        {
            grdDish.DataSource = dishList; // Fix this line
            LoadListDish();
            LoadCategoryIntoCombobox(cboDishCategory);
        }

        void AddFoodBinding()
        {
            grdDish.DataSource = dishList; // Add this line
            txtDishID.DataBindings.Add(new Binding("Text", dishList, "DishID"));
            txtDishName.DataBindings.Add(new Binding("Text", dishList, "DishName"));
            nudDishPrice.DataBindings.Add(new Binding("Value", dishList, "Price"));
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

        #region Events
        private void btnShowDish_Click(object sender, EventArgs e)
        {
            LoadListDish();
        }
        #endregion

        private void txtDishID_TextChanged(object sender, EventArgs e)
        {
            if (grdDish.SelectedCells.Count > 0)
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
    }
}
