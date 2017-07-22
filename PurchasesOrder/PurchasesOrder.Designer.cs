namespace PurchasesOrder
{
    partial class PurchasesOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasesOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textPuchasesOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerPurchasesOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkItem = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Purchase_Order_Detail_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Item_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListPurchaseOrder = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.ListPurchaseOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1422, 1036);
            this.panel1.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.Location = new System.Drawing.Point(1101, 22);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(34, 30);
            this.btnExcel.TabIndex = 83;
            this.btnExcel.Text = "button12";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(59, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 78;
            this.label1.Text = "Company Name";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AccessibleName = "SetStyle1";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.ItemHeight = 25;
            this.cmbCompany.Location = new System.Drawing.Point(223, 22);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(860, 33);
            this.cmbCompany.TabIndex = 92;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textPuchasesOrderNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerPurchasesOrderDate);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(21, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1071, 108);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchases Order";
            // 
            // textPuchasesOrderNo
            // 
            this.textPuchasesOrderNo.BackColor = System.Drawing.Color.Turquoise;
            this.textPuchasesOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPuchasesOrderNo.ForeColor = System.Drawing.Color.Black;
            this.textPuchasesOrderNo.Location = new System.Drawing.Point(634, 46);
            this.textPuchasesOrderNo.Name = "textPuchasesOrderNo";
            this.textPuchasesOrderNo.Size = new System.Drawing.Size(204, 30);
            this.textPuchasesOrderNo.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(358, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 74;
            this.label2.Text = "Purchases Order No ";
            // 
            // dateTimePickerPurchasesOrderDate
            // 
            this.dateTimePickerPurchasesOrderDate.CustomFormat = "dd-MMM -yyyy";
            this.dateTimePickerPurchasesOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerPurchasesOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPurchasesOrderDate.Location = new System.Drawing.Point(144, 45);
            this.dateTimePickerPurchasesOrderDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerPurchasesOrderDate.Name = "dateTimePickerPurchasesOrderDate";
            this.dateTimePickerPurchasesOrderDate.Size = new System.Drawing.Size(180, 27);
            this.dateTimePickerPurchasesOrderDate.TabIndex = 77;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(39, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 25);
            this.label18.TabIndex = 63;
            this.label18.Text = "Date";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "SetStyle1";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(619, 956);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 43);
            this.btnDelete.TabIndex = 89;
            this.btnDelete.Text = "Delete This Order";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "SetStyle1";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(256, 956);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 43);
            this.btnCancel.TabIndex = 91;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleName = "SetStyle1";
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(424, 956);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(166, 43);
            this.btnUpdate.TabIndex = 90;
            this.btnUpdate.Text = "Update This Order";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleName = "SetStyle1";
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(64, 956);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 43);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Add New Order";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lnkItem);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(21, 182);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1071, 731);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchases Order Detail";
            // 
            // lnkItem
            // 
            this.lnkItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkItem.AutoSize = true;
            this.lnkItem.LinkColor = System.Drawing.Color.DarkGoldenrod;
            this.lnkItem.Location = new System.Drawing.Point(899, 24);
            this.lnkItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkItem.Name = "lnkItem";
            this.lnkItem.Size = new System.Drawing.Size(142, 20);
            this.lnkItem.TabIndex = 1;
            this.lnkItem.TabStop = true;
            this.lnkItem.Text = "Item Managemant";
            this.lnkItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkItem_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleName = "";
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Purchase_Order_Detail_Id,
            this.ItemName,
            this.Item_Quantity,
            this.Item_Rate,
            this.Total_Amount});
            this.dataGridView1.Location = new System.Drawing.Point(14, 65);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Purple;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1044, 654);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // Purchase_Order_Detail_Id
            // 
            this.Purchase_Order_Detail_Id.HeaderText = "Purchase_Order_Detail_Id";
            this.Purchase_Order_Detail_Id.Name = "Purchase_Order_Detail_Id";
            this.Purchase_Order_Detail_Id.ReadOnly = true;
            this.Purchase_Order_Detail_Id.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 300;
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 300;
            // 
            // Item_Quantity
            // 
            this.Item_Quantity.HeaderText = "Item Quantity";
            this.Item_Quantity.MinimumWidth = 100;
            this.Item_Quantity.Name = "Item_Quantity";
            // 
            // Item_Rate
            // 
            this.Item_Rate.HeaderText = "Item Rate";
            this.Item_Rate.MinimumWidth = 100;
            this.Item_Rate.Name = "Item_Rate";
            // 
            // Total_Amount
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Purple;
            this.Total_Amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.Total_Amount.HeaderText = "Total Amount";
            this.Total_Amount.MinimumWidth = 150;
            this.Total_Amount.Name = "Total_Amount";
            this.Total_Amount.ReadOnly = true;
            this.Total_Amount.Width = 150;
            // 
            // ListPurchaseOrder
            // 
            this.ListPurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPurchaseOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPurchaseOrder.FormattingEnabled = true;
            this.ListPurchaseOrder.ItemHeight = 29;
            this.ListPurchaseOrder.Location = new System.Drawing.Point(1101, 65);
            this.ListPurchaseOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListPurchaseOrder.Name = "ListPurchaseOrder";
            this.ListPurchaseOrder.Size = new System.Drawing.Size(314, 932);
            this.ListPurchaseOrder.TabIndex = 79;
            // 
            // PurchasesOrder
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 1036);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PurchasesOrder";
            this.Text = "Purchases Order";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListPurchaseOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textPuchasesOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchasesOrderDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel lnkItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purchase_Order_Detail_Id;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Amount;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}