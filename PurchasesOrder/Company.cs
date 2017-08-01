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

namespace PurchasesOrder
{
    public partial class company : Form
    { 
        #region Property
        public CompanyEL DataGridViewSelectedCompany
        {
            get
            {
                CompanyEL objCompanyEL = new CompanyEL();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    objCompanyEL.Company_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["company_Id"].Value);
                    objCompanyEL.company_name = dataGridView1.SelectedRows[0].Cells["company_name"].Value.ToString();
                    objCompanyEL.tin_no = dataGridView1.SelectedRows[0].Cells["tin_no"].Value.ToString();
                    objCompanyEL.pan_no = dataGridView1.SelectedRows[0].Cells["pan_no"].Value.ToString();
                    objCompanyEL.phone = dataGridView1.SelectedRows[0].Cells["phone"].Value.ToString();
                    objCompanyEL.address1 = dataGridView1.SelectedRows[0].Cells["address1"].Value.ToString();
                    objCompanyEL.city = dataGridView1.SelectedRows[0].Cells["city"].Value.ToString();
                    objCompanyEL.state = dataGridView1.SelectedRows[0].Cells["state"].Value.ToString();
                    objCompanyEL.pincode = dataGridView1.SelectedRows[0].Cells["pincode"].Value.ToString();
                    objCompanyEL.email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
                    objCompanyEL.phone = dataGridView1.SelectedRows[0].Cells["phone"].Value.ToString();
                    objCompanyEL.Fax_No = dataGridView1.SelectedRows[0].Cells["Fax_No"].Value.ToString();
                    objCompanyEL.delivery_at = dataGridView1.SelectedRows[0].Cells["delivery_at"].Value.ToString();
                }
                return objCompanyEL;
            }
        } 
        #endregion

        #region Constructor
        public company()
        {
            InitializeComponent();
            Common objCommon = new Common();
            objCommon.SetStyle(this);
          
            ControlClear();
            
        }
        #endregion

        #region Event
        private void Company_Load(object sender, EventArgs e)
        {
            GridBind();
        }

        #region Functionality Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textCompanyName.Text))
                {
                    Common.MessageAlert("First Enter Company Name");
                }
                else
                {
                    CompanyEL objCompanyEL = new CompanyEL();
                    CompanyDL objCompanyDL = new CompanyDL();

                    objCompanyEL.address1 = textAddress1.Text;
                    objCompanyEL.city = textCity.Text;
                    objCompanyEL.email = textEmail.Text;
                    objCompanyEL.Fax_No = textFaxNo.Text;
                    objCompanyEL.pan_no = textPan.Text;
                    objCompanyEL.tin_no = txtTin.Text;
                    objCompanyEL.phone = textPhone.Text;
                    objCompanyEL.pincode = textpinCode.Text;
                    objCompanyEL.state = textState.Text;
                    objCompanyEL.company_name = textCompanyName.Text;                   
                    objCompanyEL.delivery_at = textDelivertAt.Text; 
                   
                   
                    if (objCompanyDL.Insert(objCompanyEL))
                    {
                        Common.MessageSave();
                        GridBind();
                        ControlClear();
                    }
                    else
                    {

                    }
                }
            }
            catch
            {

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textCompanyName.Text))
                {
                    Common.MessageAlert("First Enter Company Name");
                }
                else
                {
                    CompanyEL objCompanyEL = new CompanyEL();
                    CompanyDL objCompanyDL = new CompanyDL();

                    objCompanyEL.address1 = textAddress1.Text;
                    objCompanyEL.city = textCity.Text;
                    objCompanyEL.email = textEmail.Text;
                    objCompanyEL.Fax_No = textFaxNo.Text;
                    objCompanyEL.pan_no = textPan.Text;
                    objCompanyEL.tin_no = txtTin.Text;
                    objCompanyEL.phone = textPhone.Text;
                    objCompanyEL.pincode = textpinCode.Text;
                    objCompanyEL.state = textState.Text;
                    objCompanyEL.company_name = textCompanyName.Text;
                    objCompanyEL.delivery_at = textDelivertAt.Text;                   
                    objCompanyEL.Company_id = DataGridViewSelectedCompany.Company_id;

                    if (objCompanyDL.Update(objCompanyEL))
                    {
                        Common.MessageUpdate();
                        GridBind();
                        ControlClear();
                    }
                    else
                    {

                    }
                }

            }
            catch
            {

            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.MessageConfim("Are You Want To Delete This "))
                {                
                    CompanyEL objCompanyEL = new CompanyEL();
                    CompanyDL objCompanyDL = new CompanyDL();

                    objCompanyEL.Company_id = DataGridViewSelectedCompany.Company_id;


                    if (objCompanyDL.Delete(objCompanyEL))
                    {
                        Common.MessageDelete();
                        GridBind();
                        ControlClear();
                    }
                    else
                    {

                    }
                }

            }
            catch
            {

            }

        }
       
        #endregion

        #region Nqavigation event
        private void cmbCompanyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridBind();
        }

        #endregion
        #endregion

        #region Private Method
        void ControlClear()
        {
            Common objCommon = new Common();
            objCommon.ClearControl(this);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;                        
        }
        void BindControl()
        {
            try
            {
                CompanyEL objCompanyEL = DataGridViewSelectedCompany;
                textAddress1.Text = objCompanyEL.address1;
                textCity.Text = objCompanyEL.city;
                textEmail.Text = objCompanyEL.email;
                textFaxNo.Text = objCompanyEL.Fax_No;
                textPan.Text = objCompanyEL.pan_no;
                txtTin.Text = objCompanyEL.tin_no; 
                textPhone.Text = objCompanyEL.phone;
                textpinCode.Text = objCompanyEL.pincode;
                textState.Text = objCompanyEL.state;
                textCompanyName.Text = objCompanyEL.company_name;
                textDelivertAt.Text = objCompanyEL.delivery_at;  

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            catch
            {
                ControlClear();
            }

        }
        
     
        #endregion        

        #region DataGrid operation
        void GridBind()
        {
            try
            {
                CompanyDL objCompanyDL = new CompanyDL();
                List<CompanyEL> CompanyList = objCompanyDL.GetCompanyList();

                dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;
                dataGridView1.Click-= dataGridView1_Click;

                for (int i = 0; i < CompanyList.Count; i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells["Company_id"].Value = CompanyList[i].Company_id;
                    dataGridView1.Rows[i].Cells["company_name"].Value = CompanyList[i].company_name;
                    dataGridView1.Rows[i].Cells["tin_no"].Value = CompanyList[i].tin_no;
                    dataGridView1.Rows[i].Cells["pan_no"].Value = CompanyList[i].pan_no;
                    dataGridView1.Rows[i].Cells["phone"].Value = CompanyList[i].phone;
                    dataGridView1.Rows[i].Cells["address1"].Value = CompanyList[i].address1;
                    dataGridView1.Rows[i].Cells["city"].Value = CompanyList[i].city;
                    dataGridView1.Rows[i].Cells["state"].Value = CompanyList[i].state;
                    dataGridView1.Rows[i].Cells["pincode"].Value = CompanyList[i].pincode;
                    dataGridView1.Rows[i].Cells["email"].Value = CompanyList[i].email;
                    dataGridView1.Rows[i].Cells["phone"].Value = CompanyList[i].phone;
                    dataGridView1.Rows[i].Cells["Fax_No"].Value = CompanyList[i].Fax_No;
                    dataGridView1.Rows[i].Cells["delivery_at"].Value = CompanyList[i].delivery_at;
                }               
                dataGridView1.Columns["Company_id"].Visible = false;
                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
                dataGridView1.Click += dataGridView1_Click;
            }
            catch
            {
            }
            ControlClear();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            BindControl();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            BindControl();
        }

        #endregion        

       

       
    }
}

