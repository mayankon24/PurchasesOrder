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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;


namespace PurchasesOrder
{
    public partial class ReportViewer : Form
    {
        #region Variable
        int CompanyId;
        int CompanyTypeId;
        int PurchasesOrderId;
        PurchasesBill objRpt = null;

        #endregion

        #region constractor
        private ReportViewer()
        {
            InitializeComponent();
        }
        public ReportViewer(int companyId, string compnayName, int PurchasesOrderId)
            : this()
        {
            this.CompanyId = companyId;
            this.PurchasesOrderId = PurchasesOrderId;
            CreateReport();
        }

        #endregion

        #region Event
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            crystalReportViewer1.Dispose();
            objRpt = null;
            this.Close();
            this.Dispose();
        }
       
        #endregion

        #region Method
        void CreateReport()
        {            
            //DisposeReport();
            try
            {
                PurchasesOrderDetailDL objPurchasesOrderDetailDL = new PurchasesOrderDetailDL();
                DataSet ds = objPurchasesOrderDetailDL.GetPurchasesBillReportData(CompanyId, PurchasesOrderId);

                objRpt = new PurchasesBill();
                objRpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = objRpt;
            }
            catch
            {
            }
        }
        private void DisposeReport()
        {
            if (objRpt != null)
            {
                objRpt.Dispose();
            }           
        }
        #endregion

        
    }
}
