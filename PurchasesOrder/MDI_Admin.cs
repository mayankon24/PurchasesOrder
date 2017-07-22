using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;
using GlobleLibrary;


namespace PurchasesOrder
{
    public partial class MDI_Admin : Form
    {
       
       public MDI_Admin()
        {
            InitializeComponent();                        
        }

       #region MenuItem Click

       private void CompanyToolStripMenuItem_Click(object sender, EventArgs e)
       {
           closeChildForms();
           company newCompany = new company();
           showControl(newCompany);
       }
       private void ItemToolStripMenuItem_Click(object sender, EventArgs e)
       {
           closeChildForms();
           Item newItemName = new Item();
           showControl(newItemName);
       }
       private void PurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
       {
           closeChildForms();
           PurchasesOrder newPurchasesOrderName = new PurchasesOrder();
           showControl(newPurchasesOrderName);
       }
       private void reportToolStripMenuItem_Click(object sender, EventArgs e)
       {
           closeChildForms();
           ReportPurchasesOrder newReportPurchasesOrder = new ReportPurchasesOrder();
           showControl(newReportPurchasesOrder);
       }

       #endregion

       #region Private function
       private void closeChildForms()
       {
           foreach (Form frm in this.MdiChildren)
           {
               frm.Close();
           }

       }
       private void showControl(Form frm)
       {
           if (this.MdiChildren.Contains(frm))
           {
               frm.ShowDialog();//.BringToFront();
           }
           else
           {
               frm.MdiParent = this;
               //frm.Size = new Size(this.Width - 5, this.Height - 50);
               frm.WindowState = FormWindowState.Maximized;
               frm.Show();
               frm.Location = new Point(0, 0);
           }
       }
       private void MDI_Admin_FormClosed(object sender, FormClosedEventArgs e)
       {
           Application.Exit();
       }

       #endregion        

       
       
       
      
    }
}
