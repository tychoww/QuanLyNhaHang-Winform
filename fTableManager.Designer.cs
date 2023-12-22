namespace QuanLyNhaHang_Winform
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudDishQuantity = new System.Windows.Forms.NumericUpDown();
            this.cboDish = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.lstvInvoiceInfor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDishQuantity)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnTrịToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnTrịToolStripMenuItem
            // 
            this.quảnTrịToolStripMenuItem.Name = "quảnTrịToolStripMenuItem";
            this.quảnTrịToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.quảnTrịToolStripMenuItem.Text = "Quản trị";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            // 
            // cậpNhậtToolStripMenuItem
            // 
            this.cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            this.cậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cậpNhậtToolStripMenuItem.Text = "Cập nhật";
            this.cậpNhậtToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudDishQuantity);
            this.panel2.Controls.Add(this.cboDish);
            this.panel2.Controls.Add(this.cboCategory);
            this.panel2.Controls.Add(this.btnAddDish);
            this.panel2.Location = new System.Drawing.Point(418, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 58);
            this.panel2.TabIndex = 2;
            // 
            // nudDishQuantity
            // 
            this.nudDishQuantity.Location = new System.Drawing.Point(223, 21);
            this.nudDishQuantity.Name = "nudDishQuantity";
            this.nudDishQuantity.Size = new System.Drawing.Size(44, 20);
            this.nudDishQuantity.TabIndex = 4;
            // 
            // cboDish
            // 
            this.cboDish.FormattingEnabled = true;
            this.cboDish.Location = new System.Drawing.Point(3, 34);
            this.cboDish.Name = "cboDish";
            this.cboDish.Size = new System.Drawing.Size(214, 21);
            this.cboDish.TabIndex = 3;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(3, 7);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(214, 21);
            this.cboCategory.TabIndex = 2;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(273, 3);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(94, 52);
            this.btnAddDish.TabIndex = 1;
            this.btnAddDish.Text = "Thêm món";
            this.btnAddDish.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTotalPrice);
            this.panel4.Controls.Add(this.btnPay);
            this.panel4.Location = new System.Drawing.Point(418, 380);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(370, 58);
            this.panel4.TabIndex = 4;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.Color.White;
            this.txtTotalPrice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Firebrick;
            this.txtTotalPrice.Location = new System.Drawing.Point(157, 17);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 25);
            this.txtTotalPrice.TabIndex = 1;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(263, 3);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(104, 52);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(12, 27);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(400, 411);
            this.flpTable.TabIndex = 5;
            // 
            // lstvInvoiceInfor
            // 
            this.lstvInvoiceInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstvInvoiceInfor.GridLines = true;
            this.lstvInvoiceInfor.HideSelection = false;
            this.lstvInvoiceInfor.Location = new System.Drawing.Point(418, 95);
            this.lstvInvoiceInfor.Name = "lstvInvoiceInfor";
            this.lstvInvoiceInfor.Size = new System.Drawing.Size(370, 279);
            this.lstvInvoiceInfor.TabIndex = 6;
            this.lstvInvoiceInfor.UseCompatibleStateImageBehavior = false;
            this.lstvInvoiceInfor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 144;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 77;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstvInvoiceInfor);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn ăn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDishQuantity)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnTrịToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ListView lstvInvoiceInfor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.NumericUpDown nudDishQuantity;
        private System.Windows.Forms.ComboBox cboDish;
        private System.Windows.Forms.ComboBox cboCategory;
    }
}