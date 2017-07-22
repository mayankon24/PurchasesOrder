namespace PurchasesOrder
{
    partial class MDI_Admin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem CompanyToolStripMenuItem;
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PurchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packageFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IdleTime = new System.Windows.Forms.Timer(this.components);
            CompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompanyToolStripMenuItem
            // 
            CompanyToolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            CompanyToolStripMenuItem.Name = "CompanyToolStripMenuItem";
            CompanyToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            CompanyToolStripMenuItem.Text = "Company";
            CompanyToolStripMenuItem.Click += new System.EventHandler(this.CompanyToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            CompanyToolStripMenuItem,
            this.ItemToolStripMenuItem,
            this.PurchaseOrderToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1791, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // ItemToolStripMenuItem
            // 
            this.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem";
            this.ItemToolStripMenuItem.Size = new System.Drawing.Size(60, 29);
            this.ItemToolStripMenuItem.Text = "Item";
            this.ItemToolStripMenuItem.Click += new System.EventHandler(this.ItemToolStripMenuItem_Click);
            // 
            // PurchaseOrderToolStripMenuItem
            // 
            this.PurchaseOrderToolStripMenuItem.Name = "PurchaseOrderToolStripMenuItem";
            this.PurchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(140, 29);
            this.PurchaseOrderToolStripMenuItem.Text = "PurchaseOrder";
            this.PurchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.PurchaseOrderToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 1006);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1791, 30);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(455, 25);
            this.toolStripStatusLabel.Text = "Create and Develop by Mayank Aggarwal (9990983193)";
            // 
            // addPackageToolStripMenuItem
            // 
            this.addPackageToolStripMenuItem.Name = "addPackageToolStripMenuItem";
            this.addPackageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addPackageToolStripMenuItem.Text = "Add Package";
            // 
            // packageFilterToolStripMenuItem
            // 
            this.packageFilterToolStripMenuItem.Name = "packageFilterToolStripMenuItem";
            this.packageFilterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.packageFilterToolStripMenuItem.Text = "Package Filter";
            // 
            // MDI_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1791, 1036);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDI_Admin";
            this.Text = "R.P. Printers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDI_Admin_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem addPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packageFilterToolStripMenuItem;
        private System.Windows.Forms.Timer IdleTime;
        private System.Windows.Forms.ToolStripMenuItem PurchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
    }
}



