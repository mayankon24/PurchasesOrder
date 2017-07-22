using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PurchasesOrder.Entity;
using System.Data;
using System.Data.SqlClient;
using GlobleLibrary;

namespace PurchasesOrder.DataLayer
{
    class PurchasesOrderDetailDL
    {       
        public int Insert(PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = Insert(objSqlTransaction, objPurchasesOrderDetailEL);
                objSqlTransaction.Commit();
                return Id;
            }
            catch(Exception)
            {
                objSqlTransaction.Rollback();
                throw;
            }
        }
        public void Update(PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                Update(objSqlTransaction, objPurchasesOrderDetailEL);
                objSqlTransaction.Commit();                
            }
            catch
            {
                objSqlTransaction.Rollback();                
            }
        }
        public void Delete(PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                Delete(objSqlTransaction, objPurchasesOrderDetailEL);
                objSqlTransaction.Commit();               
            }
            catch
            {
                objSqlTransaction.Rollback();               
            }
        }
        public List<PurchasesOrderDetailEL> GetPurchasesOrderDetailByOrderId(int OrderId)
        {
            PurchasesOrderDetailEL objPurchasesOrderDetailEL;
            List<PurchasesOrderDetailEL> lstPurchasesOrderDetail = new List<PurchasesOrderDetailEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("GetPurchasesOrderDetailByOrderId"
                                                                    , objSQLHelper.SqlParam("@Purchases_Order_Id", OrderId, SqlDbType.Int)
                                                                     );
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPurchasesOrderDetailEL = new PurchasesOrderDetailEL();
                    objPurchasesOrderDetailEL.Item_Name = dt.Rows[i]["Item_Name"].ToString();
                    objPurchasesOrderDetailEL.Item_id = (int)dt.Rows[i]["Item_id"];
                    objPurchasesOrderDetailEL.Item_Quantity = Convert.ToDouble(dt.Rows[i]["Item_Quantity"]);
                    objPurchasesOrderDetailEL.Item_Rate = Convert.ToDouble(dt.Rows[i]["Item_Rate"]);
                    objPurchasesOrderDetailEL.Item_Unit = dt.Rows[i]["Item_Unit"].ToString();
                    objPurchasesOrderDetailEL.Purchase_Order_Detail_Id = (int)dt.Rows[i]["Purchase_Order_Detail_Id"];
                    objPurchasesOrderDetailEL.Purchases_Order_Id = (int)dt.Rows[i]["Purchases_Order_Id"];
                    objPurchasesOrderDetailEL.Total_Amount = Convert.ToDecimal(dt.Rows[i]["Total_Amount"]);
                    lstPurchasesOrderDetail.Add(objPurchasesOrderDetailEL);
                }
            }
            return lstPurchasesOrderDetail;
        }
        public List<PurchasesOrderDetailEL> GetPurchasesOrderDetail()
        {
            PurchasesOrderDetailEL objPurchasesOrderDetailEL;
            List<PurchasesOrderDetailEL> lstPurchasesOrderDetailEL = new List<PurchasesOrderDetailEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectPurchasesOrderDetailAll");

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPurchasesOrderDetailEL = new PurchasesOrderDetailEL();
                    objPurchasesOrderDetailEL.Item_Name = dt.Rows[i]["Item_Name"].ToString();
                    objPurchasesOrderDetailEL.Item_id = (int)dt.Rows[i]["Item_id"];
                    objPurchasesOrderDetailEL.Item_Quantity = Convert.ToDouble(dt.Rows[i]["Item_Quantity"]);
                    objPurchasesOrderDetailEL.Item_Rate = Convert.ToDouble(dt.Rows[i]["Item_Rate"]);
                    objPurchasesOrderDetailEL.Item_Unit = dt.Rows[i]["Item_Unit"].ToString();
                    objPurchasesOrderDetailEL.Purchase_Order_Detail_Id = (int)dt.Rows[i]["Purchase_Order_Detail_Id"];
                    objPurchasesOrderDetailEL.Purchases_Order_Id = (int)dt.Rows[i]["Purchases_Order_Id"];
                    objPurchasesOrderDetailEL.Total_Amount = Convert.ToDecimal(dt.Rows[i]["Total_Amount"]);
                    lstPurchasesOrderDetailEL.Add(objPurchasesOrderDetailEL);
                }
            }
            return lstPurchasesOrderDetailEL;
        }
        
        public int Insert(SqlTransaction objSqlTransaction, PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            int Id = objSQLHelper.ExecuteInsertProcedure("InsertPurchasesOrderDetail", objSqlTransaction
                                                     , objSQLHelper.SqlParam("@Item_Name", objPurchasesOrderDetailEL.Item_Name, SqlDbType.NVarChar)
                                                     , objSQLHelper.SqlParam("@Item_Id", objPurchasesOrderDetailEL.Item_id, SqlDbType.Int)
                                                     , objSQLHelper.SqlParam("@Item_Quantity", objPurchasesOrderDetailEL.Item_Quantity, SqlDbType.Float)
                                                     , objSQLHelper.SqlParam("@Item_Rate", objPurchasesOrderDetailEL.Item_Rate, SqlDbType.Float)
                                                     , objSQLHelper.SqlParam("@Item_Unit", objPurchasesOrderDetailEL.Item_Unit, SqlDbType.NVarChar)
                                                     , objSQLHelper.SqlParam("@Purchases_Order_Id", objPurchasesOrderDetailEL.Purchases_Order_Id, SqlDbType.Int)
                                                    );
            return Id;

        }
        public void Update(SqlTransaction objSqlTransaction, PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            int Id = objSQLHelper.ExecuteUpdateProcedure("UpdatePurchasesOrderDetail", objSqlTransaction
                                             , objSQLHelper.SqlParam("@Item_Name", objPurchasesOrderDetailEL.Item_Name, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Item_Id", objPurchasesOrderDetailEL.Item_id, SqlDbType.Int)
                                             , objSQLHelper.SqlParam("@Item_Quantity", objPurchasesOrderDetailEL.Item_Quantity, SqlDbType.Float)
                                             , objSQLHelper.SqlParam("@Item_Rate", objPurchasesOrderDetailEL.Item_Rate, SqlDbType.Float)
                                             , objSQLHelper.SqlParam("@Item_Unit", objPurchasesOrderDetailEL.Item_Unit, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Purchase_Order_Detail_Id", objPurchasesOrderDetailEL.Purchase_Order_Detail_Id, SqlDbType.Int)
                                           );
        }
        public void Delete(SqlTransaction objSqlTransaction, PurchasesOrderDetailEL objPurchasesOrderDetailEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();

            objSQLHelper.ExecuteDeleteProcedure("DeletePackagingDetails_By_PurchasesDetailId", objSqlTransaction
                                                  , objSQLHelper.SqlParam("@Purchase_Order_Detail_Id", objPurchasesOrderDetailEL.Purchase_Order_Detail_Id, SqlDbType.Int)
                                                 );

            int cpmpanyId = objSQLHelper.ExecuteDeleteProcedure("DeletePurchasesOrderDetail_ById", objSqlTransaction
                                                     , objSQLHelper.SqlParam("@Purchase_Order_Detail_Id", objPurchasesOrderDetailEL.Purchase_Order_Detail_Id, SqlDbType.Int)
                                                   );


           

        }

        public DataSet GetPurchasesBillReportData(int companyId, int PurchasesyOrderId)
        {
            SQLHelper objSQLHelper = new SQLHelper();

            DataSet ds = objSQLHelper.MyCustomExecuteSelectProcedureForDataSet("GetReportHeader", "GetReportBody"
                                                    , objSQLHelper.SqlParam("@Company_id", companyId, SqlDbType.Int)
                                                    , objSQLHelper.SqlParam("@Purchases_Order_Id", PurchasesyOrderId, SqlDbType.Int)
                                                    );
            return ds;
        }
    }
}
