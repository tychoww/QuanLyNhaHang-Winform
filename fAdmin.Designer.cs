﻿namespace QuanLyNhaHang_Winform
{
    partial class fAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpDish = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDishID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDishName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboDishCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nudDishPrice = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.btnDeleteDish = new System.Windows.Forms.Button();
            this.btnUpdateDish = new System.Windows.Forms.Button();
            this.btnShowDish = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grdDish = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDishNameSearch = new System.Windows.Forms.TextBox();
            this.btnSearchDish = new System.Windows.Forms.Button();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grdStatistics = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.tpDish.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDishPrice)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDish)).BeginInit();
            this.panel3.SuspendLayout();
            this.tcAdmin.SuspendLayout();
            this.tpStatistics.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistics)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpDish
            // 
            this.tpDish.Controls.Add(this.flowLayoutPanel2);
            this.tpDish.Controls.Add(this.flowLayoutPanel1);
            this.tpDish.Controls.Add(this.panel5);
            this.tpDish.Controls.Add(this.panel3);
            this.tpDish.Location = new System.Drawing.Point(4, 22);
            this.tpDish.Name = "tpDish";
            this.tpDish.Padding = new System.Windows.Forms.Padding(3);
            this.tpDish.Size = new System.Drawing.Size(809, 450);
            this.tpDish.TabIndex = 0;
            this.tpDish.Text = "Món ăn";
            this.tpDish.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(461, 76);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(342, 366);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtDishID);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(337, 37);
            this.panel6.TabIndex = 24;
            // 
            // txtDishID
            // 
            this.txtDishID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDishID.Location = new System.Drawing.Point(88, 5);
            this.txtDishID.Name = "txtDishID";
            this.txtDishID.ReadOnly = true;
            this.txtDishID.Size = new System.Drawing.Size(246, 24);
            this.txtDishID.TabIndex = 7;
            this.txtDishID.TextChanged += new System.EventHandler(this.txtDishID_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "ID:  ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDishName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 37);
            this.panel1.TabIndex = 25;
            // 
            // txtDishName
            // 
            this.txtDishName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDishName.Location = new System.Drawing.Point(88, 5);
            this.txtDishName.Name = "txtDishName";
            this.txtDishName.Size = new System.Drawing.Size(246, 24);
            this.txtDishName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên món: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboDishCategory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 37);
            this.panel2.TabIndex = 26;
            // 
            // cboDishCategory
            // 
            this.cboDishCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDishCategory.FormattingEnabled = true;
            this.cboDishCategory.Location = new System.Drawing.Point(88, 3);
            this.cboDishCategory.Name = "cboDishCategory";
            this.cboDishCategory.Size = new System.Drawing.Size(246, 26);
            this.cboDishCategory.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Danh mục: ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nudDishPrice);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 132);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(337, 37);
            this.panel4.TabIndex = 27;
            // 
            // nudDishPrice
            // 
            this.nudDishPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDishPrice.Location = new System.Drawing.Point(88, 5);
            this.nudDishPrice.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nudDishPrice.Name = "nudDishPrice";
            this.nudDishPrice.Size = new System.Drawing.Size(246, 24);
            this.nudDishPrice.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Giá:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddDish);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteDish);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateDish);
            this.flowLayoutPanel1.Controls.Add(this.btnShowDish);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 61);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(3, 3);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(106, 58);
            this.btnAddDish.TabIndex = 0;
            this.btnAddDish.Text = "Thêm";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Location = new System.Drawing.Point(115, 3);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Size = new System.Drawing.Size(106, 58);
            this.btnDeleteDish.TabIndex = 1;
            this.btnDeleteDish.Text = "Xoá";
            this.btnDeleteDish.UseVisualStyleBackColor = true;
            this.btnDeleteDish.Click += new System.EventHandler(this.btnDeleteDish_Click);
            // 
            // btnUpdateDish
            // 
            this.btnUpdateDish.Location = new System.Drawing.Point(227, 3);
            this.btnUpdateDish.Name = "btnUpdateDish";
            this.btnUpdateDish.Size = new System.Drawing.Size(106, 58);
            this.btnUpdateDish.TabIndex = 2;
            this.btnUpdateDish.Text = "Sửa";
            this.btnUpdateDish.UseVisualStyleBackColor = true;
            this.btnUpdateDish.Click += new System.EventHandler(this.btnUpdateDish_Click);
            // 
            // btnShowDish
            // 
            this.btnShowDish.Location = new System.Drawing.Point(339, 3);
            this.btnShowDish.Name = "btnShowDish";
            this.btnShowDish.Size = new System.Drawing.Size(106, 58);
            this.btnShowDish.TabIndex = 3;
            this.btnShowDish.Text = "Xem";
            this.btnShowDish.UseVisualStyleBackColor = true;
            this.btnShowDish.Click += new System.EventHandler(this.btnShowDish_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grdDish);
            this.panel5.Location = new System.Drawing.Point(6, 73);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(449, 369);
            this.panel5.TabIndex = 3;
            // 
            // grdDish
            // 
            this.grdDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDish.Location = new System.Drawing.Point(3, 3);
            this.grdDish.Name = "grdDish";
            this.grdDish.Size = new System.Drawing.Size(443, 363);
            this.grdDish.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtDishNameSearch);
            this.panel3.Controls.Add(this.btnSearchDish);
            this.panel3.Location = new System.Drawing.Point(461, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 61);
            this.panel3.TabIndex = 1;
            // 
            // txtDishNameSearch
            // 
            this.txtDishNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDishNameSearch.Location = new System.Drawing.Point(13, 18);
            this.txtDishNameSearch.Name = "txtDishNameSearch";
            this.txtDishNameSearch.Size = new System.Drawing.Size(217, 26);
            this.txtDishNameSearch.TabIndex = 0;
            // 
            // btnSearchDish
            // 
            this.btnSearchDish.Location = new System.Drawing.Point(236, 3);
            this.btnSearchDish.Name = "btnSearchDish";
            this.btnSearchDish.Size = new System.Drawing.Size(106, 58);
            this.btnSearchDish.TabIndex = 4;
            this.btnSearchDish.Text = "Tìm";
            this.btnSearchDish.UseVisualStyleBackColor = true;
            this.btnSearchDish.Click += new System.EventHandler(this.btnSearchDish_Click);
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpDish);
            this.tcAdmin.Controls.Add(this.tpStatistics);
            this.tcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAdmin.Location = new System.Drawing.Point(0, 0);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(817, 476);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Controls.Add(this.panel8);
            this.tpStatistics.Controls.Add(this.panel7);
            this.tpStatistics.Location = new System.Drawing.Point(4, 22);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(809, 450);
            this.tpStatistics.TabIndex = 1;
            this.tpStatistics.Text = "Thống kê";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.grdStatistics);
            this.panel8.Location = new System.Drawing.Point(8, 44);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(793, 398);
            this.panel8.TabIndex = 1;
            // 
            // grdStatistics
            // 
            this.grdStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStatistics.Location = new System.Drawing.Point(0, 0);
            this.grdStatistics.Name = "grdStatistics";
            this.grdStatistics.Size = new System.Drawing.Size(793, 398);
            this.grdStatistics.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnShowStatistics);
            this.panel7.Controls.Add(this.dtpkToDate);
            this.panel7.Controls.Add(this.dtpkFromDate);
            this.panel7.Location = new System.Drawing.Point(6, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(797, 32);
            this.panel7.TabIndex = 0;
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.Location = new System.Drawing.Point(354, 3);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(84, 26);
            this.btnShowStatistics.TabIndex = 2;
            this.btnShowStatistics.Text = "Thống kê";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            this.btnShowStatistics.Click += new System.EventHandler(this.btnShowStatistics_Click);
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Location = new System.Drawing.Point(594, 9);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkToDate.TabIndex = 1;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Location = new System.Drawing.Point(3, 9);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkFromDate.TabIndex = 0;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 476);
            this.Controls.Add(this.tcAdmin);
            this.Name = "fAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.tpDish.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDishPrice)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDish)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tcAdmin.ResumeLayout(false);
            this.tpStatistics.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistics)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpDish;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtDishID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboDishCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nudDishPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Button btnDeleteDish;
        private System.Windows.Forms.Button btnUpdateDish;
        private System.Windows.Forms.Button btnShowDish;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView grdDish;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDishNameSearch;
        private System.Windows.Forms.Button btnSearchDish;
        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpStatistics;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView grdStatistics;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.Button btnShowStatistics;
    }
}