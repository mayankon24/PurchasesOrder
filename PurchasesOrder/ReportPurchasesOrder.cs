using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PurchasesOrder.DataLayer;
using PurchasesOrder.Entity;
using GlobleLibrary;
using System.Data.SqlClient;


namespace PurchasesOrder
{
    public partial class ReportPurchasesOrder : Form
    {      
        #region Constructor
        public ReportPurchasesOrder()
        {
            InitializeComponent();
            Common objCommon = new Common();
            objCommon.SetStyle(this);

            datePickerFromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            datePickerToDate.Value = new DateTime(DateTime.Now.Year, 12, 31);

            CompanyComboBox();
            ItemComboBox();
        }
        #endregion
        
        #region Grid operation
        void ItemGridBind()
        {
            try
            {
                ItemNameDL objItemNameDL = new ItemNameDL();
                int? companyId = null;
                int? itemId = null;

                if ((int)cmbCompany.SelectedValue > 0)
                {
                    companyId = (int)cmbCompany.SelectedValue;
                }

                if ((int)cmbItem.SelectedValue > 0)
                {
                    itemId = (int)cmbItem.SelectedValue;
                }

                DataTable dt = objItemNameDL.GetpurchaseReport(datePickerFromDate.Value, datePickerToDate.Value, companyId, itemId);

                grdItem.DataSource = dt;
                grdItem.Columns["Company_id"].Visible = false;
            }
            catch
            {
            }
        }    
        
        #endregion        

        #region Private Function

        private void CompanyComboBox()
        {
            CompanyDL objCompanyDL = new CompanyDL();
            List<CompanyEL> CompanyList = objCompanyDL.GetCompanyList();
            CompanyList.Insert(0, new CompanyEL {Company_id =0, company_name ="All" });

            cmbCompany.SelectedIndexChanged -= cmbCompany_SelectedIndexChanged;
            cmbCompany.DataSource = CompanyList;
            cmbCompany.DisplayMember = "company_name";
            cmbCompany.ValueMember = "Company_id";
            cmbCompany.SelectedIndexChanged += cmbCompany_SelectedIndexChanged;
        }
        private void ItemComboBox()
        {            
            ItemNameDL objItemNameDL = new ItemNameDL();
            List<ItemNameEL> itemList = objItemNameDL.GetItemNameAll();
            itemList.Insert(0, new ItemNameEL { Item_id = 0, Item_name = "All" });

            cmbItem.SelectedIndexChanged -= cmbItem_SelectedIndexChanged;
            cmbItem.DataSource = itemList;
            cmbItem.DisplayMember = "Item_Name";
            cmbItem.ValueMember = "Item_Id";
            cmbItem.SelectedIndexChanged += cmbItem_SelectedIndexChanged;
        }
        #endregion

        #region Event
              
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.ExcelExport(grdItem, saveFileDialog1, cmbCompany.SelectedText, "Period :-  "+ datePickerFromDate.Value.ToString("dd/MM/yyyy") + "-" + datePickerToDate.Value.ToString("dd/MM/yyyy"));
        }
        private void datePickerFromDate_ValueChanged(object sender, EventArgs e)
        {
            ItemGridBind();
        }
        private void datePickerToDate_ValueChanged(object sender, EventArgs e)
        {
            ItemGridBind();
        }
        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemGridBind();
        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemGridBind();
        }
        
        #endregion        
    }
}
