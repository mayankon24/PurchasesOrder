namespace PurchasesOrder
{
    partial class ReportPurchasesOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPurchasesOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.datePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.datePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdItem = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleName = "";
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbItem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Controls.Add(this.datePickerToDate);
            this.panel1.Controls.Add(this.datePickerFromDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 1036);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 96;
            this.label4.Text = "Item Name";
            // 
            // cmbItem
            // 
            this.cmbItem.AccessibleName = "SetStyle1";
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.ItemHeight = 25;
            this.cmbItem.Location = new System.Drawing.Point(191, 55);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(814, 33);
            this.cmbItem.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AccessibleName = "WhiteColor";
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(508, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 95;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(30, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 93;
            this.label2.Text = "Company Name";
            // 
            // cmbCompany
            // 
            this.cmbCompany.AccessibleName = "SetStyle1";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.ItemHeight = 25;
            this.cmbCompany.Location = new System.Drawing.Point(191, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(814, 33);
            this.cmbCompany.TabIndex = 94;
            // 
            // datePickerToDate
            // 
            this.datePickerToDate.Location = new System.Drawing.Point(638, 103);
            this.datePickerToDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datePickerToDate.Name = "datePickerToDate";
            this.datePickerToDate.Size = new System.Drawing.Size(298, 26);
            this.datePickerToDate.TabIndex = 85;
            this.datePickerToDate.ValueChanged += new System.EventHandler(this.datePickerToDate_ValueChanged);
            // 
            // datePickerFromDate
            // 
            this.datePickerFromDate.Location = new System.Drawing.Point(191, 105);
            this.datePickerFromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datePickerFromDate.Name = "datePickerFromDate";
            this.datePickerFromDate.Size = new System.Drawing.Size(298, 26);
            this.datePickerFromDate.TabIndex = 84;
            this.datePickerFromDate.ValueChanged += new System.EventHandler(this.datePickerFromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AccessibleName = "WhiteColor";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 83;
            this.label1.Text = "Start Date";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.BackgroundImage")));
            this.btnExcel.Location = new System.Drawing.Point(1081, 106);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(34, 30);
            this.btnExcel.TabIndex = 82;
            this.btnExcel.Text = "button12";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1012, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleName = "StyleTransparent";
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.grdItem);
            this.groupBox3.Location = new System.Drawing.Point(18, 146);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1107, 885);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item Detail";
            // 
            // grdItem
            // 
            this.grdItem.AccessibleName = "rowSelection3";
            this.grdItem.AllowUserToAddRows = false;
            this.grdItem.AllowUserToDeleteRows = false;
            this.grdItem.AllowUserToOrderColumns = true;
            this.grdItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdItem.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grdItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItem.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdItem.GridColor = System.Drawing.Color.Black;
            this.grdItem.Location = new System.Drawing.Point(20, 29);
            this.grdItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdItem.MultiSelect = false;
            this.grdItem.Name = "grdItem";
            this.grdItem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdItem.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MediumOrchid;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.grdItem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdItem.RowTemplate.ReadOnly = true;
            this.grdItem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItem.Size = new System.Drawing.Size(1077, 846);
            this.grdItem.TabIndex = 74;
            // 
            // ReportPurchasesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 1036);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportPurchasesOrder";
            this.Text = "Create Bill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DateTimePicker datePickerFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbItem;
    }
}