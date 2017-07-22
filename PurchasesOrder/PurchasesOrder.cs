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
    public partial class PurchasesOrder : Form
    {
        #region variable
        List<PurchasesOrderDetailEL> lstDeletingPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();      
        List<ItemNameEL> LstItemNameEL = null;
        #endregion

        #region property
        PurchaseOrderEL SelectedPurchasesOrder
        {
            get
            {
                return ((PurchaseOrderEL)ListPurchaseOrder.SelectedItem);
            }
        }

        CompanyEL SelectedCompany
        {
            get
            {
                return ((CompanyEL)cmbCompany.SelectedItem);
            }
        }

        #endregion

        #region constractor
        public PurchasesOrder()
        {
            InitializeComponent();
            Common objCommon = new Common();
            objCommon.SetStyle(this);

            CompanyComboBox();
            FillListBox();
            bindGridComboBox();
        }

        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textPuchasesOrderNo.Text.Trim() == "")
            {
                Common.MessageAlert("First enter Purchases Order No");
                return;
            }
            if (dataGridView1.Rows.Count - 1 <= 0)
            {
                Common.MessageAlert("First Enter Item Detail");
                return;
            }

            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();
            try
            {
                PurchaseOrderEL objPurchaseOrderEL = new PurchaseOrderEL();
                PurchaseOrderDL objPurchasesOrderDL = new PurchaseOrderDL();
                PurchasesOrderDetailEL objPurchasesOrderDetailEL;
                List<PurchasesOrderDetailEL> lstPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();
                PurchasesOrderDetailDL objPurchasesOrderDetailDL = new PurchasesOrderDetailDL();

                objPurchaseOrderEL.Company_id = SelectedCompany.Company_id;
                objPurchaseOrderEL.Date = dateTimePickerPurchasesOrderDate.Value;
                objPurchaseOrderEL.Purchases_Order_No = textPuchasesOrderNo.Text.Trim();
                int PurchaseOrderId = objPurchasesOrderDL.Insert(objSqlTransaction, objPurchaseOrderEL);


                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    objPurchasesOrderDetailEL = new PurchasesOrderDetailEL();
                    //objPurchasesOrderDetailEL.Item_Name = dataGridView1.Rows[i].Cells["Item_Name"].Value.ToString().Trim();
                    objPurchasesOrderDetailEL.Item_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["ItemName"].Value);
                    objPurchasesOrderDetailEL.Item_Quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells["Item_Quantity"].Value);
                    objPurchasesOrderDetailEL.Item_Rate = Convert.ToDouble(dataGridView1.Rows[i].Cells["Item_Rate"].Value);
                    objPurchasesOrderDetailEL.Purchases_Order_Id = PurchaseOrderId;
                    lstPurchasesOrderDetailEL.Add(objPurchasesOrderDetailEL);
                }

                lstPurchasesOrderDetailEL.ForEach(r => objPurchasesOrderDetailDL.Insert(objSqlTransaction, r));

                objSqlTransaction.Commit();
                Common.MessageSave();
                FillListBox();
                ControlClear();
            }
            catch
            {
                objSqlTransaction.Rollback();
                Common.MessageAlert("First enter data in correct format");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPuchasesOrderNo.Text.Trim()))
            {
                Common.MessageAlert("First enter Purchases Order No");
                return;
            }
            if (dataGridView1.Rows.Count - 1 < 0)
            {
                Common.MessageAlert("First Enter Item Detail");
                return;
            }

            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                PurchaseOrderEL objPurchaseOrderEL = new PurchaseOrderEL();
                PurchaseOrderDL objPurchasesOrderDL = new PurchaseOrderDL();
                PurchasesOrderDetailEL objPurchasesOrderDetailEL;
                PurchasesOrderDetailDL objPurchasesOrderDetailDL = new PurchasesOrderDetailDL();

                objPurchaseOrderEL.Company_id = SelectedCompany.Company_id;
                objPurchaseOrderEL.Purchases_Order_Id = SelectedPurchasesOrder.Purchases_Order_Id;
                objPurchaseOrderEL.Purchases_Order_No = textPuchasesOrderNo.Text.Trim();
                objPurchaseOrderEL.Date = dateTimePickerPurchasesOrderDate.Value;
                objPurchasesOrderDL.Update(objSqlTransaction, objPurchaseOrderEL);

                List<PurchasesOrderDetailEL> lstUpdatigPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();
                List<PurchasesOrderDetailEL> lstAddingPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    objPurchasesOrderDetailEL = new PurchasesOrderDetailEL();
                    //objPurchasesOrderDetailEL.Item_Name = dataGridView1.Rows[i].Cells["Item_Name"].Value.ToString().Trim();
                    objPurchasesOrderDetailEL.Item_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["ItemName"].Value);
                    objPurchasesOrderDetailEL.Item_Quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells["Item_Quantity"].Value);
                    objPurchasesOrderDetailEL.Item_Rate = Convert.ToDouble(dataGridView1.Rows[i].Cells["Item_Rate"].Value);

                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["Purchase_Order_Detail_Id"].Value) == 0)
                    {
                        objPurchasesOrderDetailEL.Purchases_Order_Id = SelectedPurchasesOrder.Purchases_Order_Id;
                        lstAddingPurchasesOrderDetailEL.Add(objPurchasesOrderDetailEL);
                    }
                    else
                    {
                        objPurchasesOrderDetailEL.Purchase_Order_Detail_Id = Convert.ToInt32(dataGridView1.Rows[i].Cells["Purchase_Order_Detail_Id"].Value);
                        lstUpdatigPurchasesOrderDetailEL.Add(objPurchasesOrderDetailEL);
                    }
                }
                lstAddingPurchasesOrderDetailEL.ForEach(r => objPurchasesOrderDetailDL.Insert(objSqlTransaction, r));
                lstUpdatigPurchasesOrderDetailEL.ForEach(r => objPurchasesOrderDetailDL.Update(objSqlTransaction, r));
                lstDeletingPurchasesOrderDetailEL.ForEach(r => objPurchasesOrderDetailDL.Delete(objSqlTransaction, r));

                objSqlTransaction.Commit();
                Common.MessageSave();
                FillListBox();
                ControlClear();
            }
            catch
            {
                objSqlTransaction.Rollback();
                Common.MessageAlert("First enter data in correct format");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = MessageBox.Show("Are you want to delete this Company", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
            if (str.Equals("Yes"))
            {
                SQLHelper objSQLHelper = new SQLHelper();
                SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();
                try
                {
                    PurchaseOrderDL objPurchasesOrderDL = new PurchaseOrderDL();
                    List<PurchasesOrderDetailEL> lstPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();
                    PurchasesOrderDetailDL objPurchasesOrderDetailDL = new PurchasesOrderDetailDL();

                    int PurchasesOrderId = SelectedPurchasesOrder.Purchases_Order_Id;
                    lstPurchasesOrderDetailEL = objPurchasesOrderDetailDL.GetPurchasesOrderDetailByOrderId(PurchasesOrderId);
                    lstPurchasesOrderDetailEL.ForEach(r => objPurchasesOrderDetailDL.Delete(objSqlTransaction, r));
                    objPurchasesOrderDL.Delete(objSqlTransaction, SelectedPurchasesOrder);

                    objSqlTransaction.Commit();
                    Common.MessageDelete();
                    FillListBox();
                    ControlClear();
                }
                catch
                {
                    objSqlTransaction.Rollback();
                }
            }
        }

        #endregion

        #region Method
        void ControlClear()
        {
            Common objCommon = new Common();
            objCommon.ClearControl(this);
            dataGridView1.Rows.Clear();

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
        void BindControl()
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }
        void bindGridComboBox()
        {
            DataGridViewComboBoxColumn ItemName = (DataGridViewComboBoxColumn)dataGridView1.Columns["ItemName"];

            ItemNameDL objItemNameDL = new ItemNameDL();
            LstItemNameEL = objItemNameDL.GetItemNameAll();
         
            ItemName.DataSource = LstItemNameEL;
            ItemName.DisplayMember = "Item_Name";
            ItemName.ValueMember = "Item_Id";
        }

        void CompanyComboBox()
        {
            CompanyDL objCompanyDL = new CompanyDL();
            List<CompanyEL> CompanyList = objCompanyDL.GetCompanyList();

            cmbCompany.SelectedIndexChanged -= cmbCompany_SelectedIndexChanged;
            cmbCompany.DataSource = CompanyList;
            cmbCompany.DisplayMember = "company_name";
            cmbCompany.ValueMember = "Company_id";
            cmbCompany.SelectedIndexChanged += cmbCompany_SelectedIndexChanged;
        }
               

        #endregion

        #region ListBox operation
        void FillListBox()
        {
            try
            {
                PurchaseOrderDL objPurchasesOrderDL = new PurchaseOrderDL();

                ListPurchaseOrder.SelectedIndexChanged -= ListPurchaseOrder_SelectedIndexChanged;
                ListPurchaseOrder.DataSource = objPurchasesOrderDL.GetPurchasesOrderByComId(SelectedCompany.Company_id);
                ListPurchaseOrder.DisplayMember = "Purchases_Order_No";
                ListPurchaseOrder.ValueMember = "Purchases_Order_Id";
                ListPurchaseOrder.SelectedIndexChanged += ListPurchaseOrder_SelectedIndexChanged;
                GridBind();
            }
            catch
            {
            }
        }
        private void ListPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridBind();
        }

        #endregion

        #region grid operation
        void GridBind()
        {
            //dtDeletingPurchassOrderDetail.Rows.Clear();
            dataGridView1.Rows.Clear();
            BindControl();
            try
            {
                int PurchasesOrderId = SelectedPurchasesOrder.Purchases_Order_Id; //Convert.ToInt32(ListPurchaseOrder.SelectedValue);
                textPuchasesOrderNo.Text = SelectedPurchasesOrder.Purchases_Order_No;
                dateTimePickerPurchasesOrderDate.Value = SelectedPurchasesOrder.Date;

                PurchasesOrderDetailDL objPurchasesOrderDetailDL = new PurchasesOrderDetailDL();
                List<PurchasesOrderDetailEL> lstPurchasesOrderDetail = objPurchasesOrderDetailDL.GetPurchasesOrderDetailByOrderId(PurchasesOrderId);

                //dataGridView1.DataSource = dt;
                for (int i = 0; i < lstPurchasesOrderDetail.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["Purchase_Order_Detail_Id"].Value = lstPurchasesOrderDetail[i].Purchase_Order_Detail_Id;
                    //dataGridView1.Rows[i].Cells["Item_Name"].Value = lstPurchasesOrderDetail[i].Item_Name;
                    dataGridView1.Rows[i].Cells["ItemName"].Value = lstPurchasesOrderDetail[i].Item_id;
                    dataGridView1.Rows[i].Cells["Item_Quantity"].Value = lstPurchasesOrderDetail[i].Item_Quantity;
                    dataGridView1.Rows[i].Cells["Item_Rate"].Value = lstPurchasesOrderDetail[i].Item_Rate;
                    dataGridView1.Rows[i].Cells["Total_Amount"].Value = lstPurchasesOrderDetail[i].Total_Amount;
                }
            }
            catch
            {
            }
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            PurchasesOrderDetailEL objPurchasesOrderDetailEL = new PurchasesOrderDetailEL();
            objPurchasesOrderDetailEL.Purchase_Order_Detail_Id = Convert.ToInt32(e.Row.Cells["Purchase_Order_Detail_Id"].Value);
            lstDeletingPurchasesOrderDetailEL.Add(objPurchasesOrderDetailEL);
            e.Row.Visible = false;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = ((DataGridViewComboBoxEditingControl)sender).EditingControlRowIndex;
            ItemNameEL selectedItem = (ItemNameEL)((System.Windows.Forms.ComboBox)(((DataGridViewComboBoxEditingControl)sender))).SelectedItem;

            if (selectedItem != null)
            {
                //dataGridView1.Rows[rowIndex].Cells["Item_Rate"].Value = selectedItem.Item_Price.ToString();
            }
            else
            {
                dataGridView1.Rows[rowIndex].Cells["Item_Rate"].Value = "";
            }
        }

        #endregion

        private void lnkItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Item newForm = new Item();
            DialogResult result = newForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                newForm.Close();
                newForm.Dispose();
                bindGridComboBox();
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.companyEL = (CompanyEL)cmbCompany.SelectedItem;

            ControlClear();
            FillListBox();           
            bindGridComboBox();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CompanyEL companyEL = SelectedCompany;
            PurchaseOrderEL purchasesOrder = SelectedPurchasesOrder;
            string filePath = @"\ExlPurchasesOrder.xlsx";

            Common objCommon = new Common();
            objCommon.PurchasesOrderExcelExport(dataGridView1
                , saveFileDialog1
                , filePath
                , SelectedPurchasesOrder.Purchases_Order_No
                , SelectedPurchasesOrder.Date.ToString("MMMM, dd yyyy")
                , SelectedCompany.company_name
                , SelectedCompany.address1
                , SelectedCompany.city
                , SelectedCompany.state
                , SelectedCompany.pincode);
        }
    }
}
