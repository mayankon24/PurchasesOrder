using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PurchasesOrder.DataLayer;
using GlobleLibrary;

namespace PurchasesOrder
{
    public partial class PackagingDetail : Form
    {
        DataTable dtPackagingDetail = new DataTable();
        int purchasesOrderDetailId;
        #region constractor
        public PackagingDetail()
        {
            dtPackagingDetail.Columns.Add("Packaging_Id", typeof(int));
            InitializeComponent();                   
        }
        public PackagingDetail(int purchasesOrderDetailId, string compnayName, string itemName): this()
        {
            this.purchasesOrderDetailId = purchasesOrderDetailId;
            lbCompanyName.Text = compnayName;
            lbItemName.Text = itemName; 
            GridBind();
        }

        #endregion

        #region Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();
            try
            {
                PackagingDetailDL objPackagingDetailDL = new PackagingDetailDL();

                if (dataGridView1.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Packaging_Id", typeof(int));
                    dt.Columns.Add("Packaging_Description", typeof(string));                  

                    for (int i = 0; i < dataGridView1.Rows.Count- 1; i++)
                    {
                        int PackagingId = Convert.ToInt32(dataGridView1.Rows[i].Cells["Packaging_Id"].Value);
                        string PackagingDescription = dataGridView1.Rows[i].Cells["Packaging_Description"].Value.ToString().Trim();

                        dt.Rows.Add(PackagingId, PackagingDescription);
                    }
                    objPackagingDetailDL.Update(objSqlTransaction, this.purchasesOrderDetailId, dt);

                    objPackagingDetailDL.DeletePackagingDetail(objSqlTransaction, dtPackagingDetail);

                    objSqlTransaction.Commit();
                    Common.MessageSave();
                    GridBind();

                }
                else
                {
                    Common.MessageAlert("First Enter Packging Description");
                }

            }
            catch
            {
                objSqlTransaction.Rollback();
                Common.MessageAlert("First enter data in correct format");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Method
        #endregion

        #region grid operation

        void GridBind()
        {
            dataGridView1.Rows.Clear();
            try
            {
                PackagingDetailDL objPackagingDetailDL = new PackagingDetailDL();
                DataTable dt = objPackagingDetailDL.GetPackingDetail(this.purchasesOrderDetailId);
                
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["Packaging_Id"].Value = dt.Rows[i]["Packaging_Id"];
                        dataGridView1.Rows[i].Cells["Packaging_Description"].Value = dt.Rows[i]["Packaging_Description"];
                       
                    }
                }
            }
            catch
            {
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dtPackagingDetail.Rows.Add(Convert.ToInt32(e.Row.Cells["Packaging_Id"].Value));
            e.Row.Visible = false;
        }
        #endregion

    } 
}
