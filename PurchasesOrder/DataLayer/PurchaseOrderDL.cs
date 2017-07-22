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
    class PurchaseOrderDL
    {
      
        public int Insert(PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = Insert(objSqlTransaction, objPurchasesOrderEL);
                objSqlTransaction.Commit();
                return Id;
            }
            catch (Exception)
            {
                objSqlTransaction.Rollback();
                throw;
            }

        }
        public void Update(PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                Update(objSqlTransaction, objPurchasesOrderEL);
                objSqlTransaction.Commit();                
            }
            catch
            {
                objSqlTransaction.Rollback();               
            }
        }
        public void Delete(PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();
            
            try
            {
                Delete(objSqlTransaction, objPurchasesOrderEL);
                objSqlTransaction.Commit();               
            }
            catch
            {
                objSqlTransaction.Rollback();                
            }
        }
       
        //public List<PurchaseOrderEL> GetPurchaseOrder()
        //{
        //    PurchaseOrderEL objPurchaseOrderEL;
        //    List<PurchaseOrderEL> lstPurchaseOrderEL = new List<PurchaseOrderEL>();

        //    SQLHelper objSQLHelper = new SQLHelper();
        //    DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectPurchasesOrderAll");

        //    if (dt != null)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            objPurchaseOrderEL = new PurchaseOrderEL();
        //            objPurchaseOrderEL.Company_id = (int)dt.Rows[i]["Company_id"];
        //            objPurchaseOrderEL.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
        //            objPurchaseOrderEL.Purchases_Order_Id = (int)dt.Rows[i]["Purchases_Order_Id"];
        //            objPurchaseOrderEL.Purchases_Order_No = dt.Rows[i]["Purchases_Order_No"].ToString();
        //            lstPurchaseOrderEL.Add(objPurchaseOrderEL);
        //        }
        //    }
        //    return lstPurchaseOrderEL;
        //}

        public int Insert(SqlTransaction objSqlTransaction, PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            int Id = objSQLHelper.ExecuteInsertProcedure("InsertPurchasesOrder", objSqlTransaction
                                                     , objSQLHelper.SqlParam("@Company_id", objPurchasesOrderEL.Company_id, SqlDbType.Int)
                                                     , objSQLHelper.SqlParam("@Date", objPurchasesOrderEL.Date, SqlDbType.DateTime)
                                                     , objSQLHelper.SqlParam("@Purchases_Order_No", objPurchasesOrderEL.Purchases_Order_No, SqlDbType.NVarChar)
                                                     , objSQLHelper.SqlParam("@Tax_Percentage", objPurchasesOrderEL.Tax_Percentage, SqlDbType.Decimal)
                                                     , objSQLHelper.SqlParam("@Other_Amount ", objPurchasesOrderEL.Other_Amount, SqlDbType.Decimal)
                                                     , objSQLHelper.SqlParam("@Requisitioner ", objPurchasesOrderEL.Requisitioner, SqlDbType.NVarChar)
                                                     , objSQLHelper.SqlParam("@Credit_Term ", objPurchasesOrderEL.Credit_Term, SqlDbType.NVarChar)
                                                     , objSQLHelper.SqlParam("@Shipping_Term ", objPurchasesOrderEL.Shipping_Term, SqlDbType.NVarChar)
                                                      , objSQLHelper.SqlParam("@Comments ", objPurchasesOrderEL.Comments, SqlDbType.NVarChar)
                                                    );
            return Id;
        }
        public void Update(SqlTransaction objSqlTransaction, PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            int Id = objSQLHelper.ExecuteUpdateProcedure("UpdatePurchasesOrder", objSqlTransaction
                                             , objSQLHelper.SqlParam("@Date", objPurchasesOrderEL.Date, SqlDbType.DateTime)
                                             , objSQLHelper.SqlParam("@Purchases_Order_No", objPurchasesOrderEL.Purchases_Order_No, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Purchases_Order_Id", objPurchasesOrderEL.Purchases_Order_Id, SqlDbType.Int)
                                             , objSQLHelper.SqlParam("@Tax_Percentage", objPurchasesOrderEL.Tax_Percentage, SqlDbType.Decimal)
                                             , objSQLHelper.SqlParam("@Other_Amount ", objPurchasesOrderEL.Other_Amount, SqlDbType.Decimal)
                                             , objSQLHelper.SqlParam("@Requisitioner ", objPurchasesOrderEL.Requisitioner, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Credit_Term ", objPurchasesOrderEL.Credit_Term, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Shipping_Term ", objPurchasesOrderEL.Shipping_Term, SqlDbType.NVarChar)
                                             , objSQLHelper.SqlParam("@Comments", objPurchasesOrderEL.Comments, SqlDbType.NVarChar)                                             
                                            
                                            );


        }
        public void Delete(SqlTransaction objSqlTransaction, PurchaseOrderEL objPurchasesOrderEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            int cpmpanyId = objSQLHelper.ExecuteDeleteProcedure("DeletePurchasesOrder", objSqlTransaction
                                                     , objSQLHelper.SqlParam("@Purchases_Order_Id", objPurchasesOrderEL.Purchases_Order_Id, SqlDbType.Int)
                                                   );
        }

        public List<PurchaseOrderEL> GetPurchasesOrderByComId(int companyId)
        {
            PurchaseOrderEL objPurchasesOrderEL;
            List<PurchaseOrderEL> lstPurchasesOrder = new List<PurchaseOrderEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("GetPurchasesOrderByCompId"
                                                                    , objSQLHelper.SqlParam("@Company_id", companyId, SqlDbType.Int)
                                                                     );
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPurchasesOrderEL = new PurchaseOrderEL();
                    objPurchasesOrderEL.Company_id = Convert.ToInt32(dt.Rows[i]["Company_id"]);
                    objPurchasesOrderEL.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                    objPurchasesOrderEL.Purchases_Order_Id = Convert.ToInt32(dt.Rows[i]["Purchases_Order_Id"]);
                    objPurchasesOrderEL.Purchases_Order_No = dt.Rows[i]["Purchases_Order_No"].ToString();
                    objPurchasesOrderEL.Tax_Percentage = Convert.ToDecimal(dt.Rows[i]["Tax_Percentage"]);
                     objPurchasesOrderEL.Other_Amount = Convert.ToDecimal(dt.Rows[i]["Other_Amount"]);
                     objPurchasesOrderEL.Requisitioner = dt.Rows[i]["Requisitioner"].ToString();
                     objPurchasesOrderEL.Credit_Term = dt.Rows[i]["Credit_Term"].ToString();
                     objPurchasesOrderEL.Shipping_Term = dt.Rows[i]["Shipping_Term"].ToString();
                    objPurchasesOrderEL.Comments = dt.Rows[i]["Comments"].ToString();
                
                    lstPurchasesOrder.Add(objPurchasesOrderEL);
                }
            }
            return lstPurchasesOrder;
        }
        public PurchaseOrderEL GetPurchasesOrderById(int purchasesOrderId)
        {
            PurchaseOrderEL objPurchasesOrderEL = new PurchaseOrderEL();
            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectPurchasesOrderById"
                                                    , objSQLHelper.SqlParam("@Purchases_Order_Id", purchasesOrderId, SqlDbType.Int)
                                                    );

            if (dt != null && dt.Rows.Count > 0)
            {
                objPurchasesOrderEL.Company_id = (int)dt.Rows[0]["Company_id"];
                objPurchasesOrderEL.Purchases_Order_No = dt.Rows[0]["Purchases_Order_No"].ToString();
                objPurchasesOrderEL.Date = Convert.ToDateTime(dt.Rows[0]["Date"]);
                objPurchasesOrderEL.Tax_Percentage = Convert.ToDecimal(dt.Rows[0]["Tax_Percentage"]);
                objPurchasesOrderEL.Other_Amount = Convert.ToDecimal(dt.Rows[0]["Other_Amount"]);
                objPurchasesOrderEL.Requisitioner = dt.Rows[0]["Requisitioner"].ToString();
                objPurchasesOrderEL.Credit_Term = dt.Rows[0]["Credit_Term"].ToString();
                objPurchasesOrderEL.Shipping_Term = dt.Rows[0]["Shipping_Term"].ToString();
                objPurchasesOrderEL.Comments = dt.Rows[0]["Comments"].ToString();
            }

            return objPurchasesOrderEL;
        }
        public DataTable GetBalanceSheet(int purchasesOrderId)
        {
            SQLHelper objSQLHelper = new SQLHelper();

            DataTable dt = objSQLHelper.ExecuteSelectProcedure("GetBalanceSheet"
                                                    , objSQLHelper.SqlParam("@Purchases_Order_Id", purchasesOrderId, SqlDbType.Int)
                                                    );
            return dt;
        }
        public List<int> GetCompletePurchasesOrder(int CompanyId)
        {
            SQLHelper objSQLHelper = new SQLHelper();

            DataTable dt = objSQLHelper.ExecuteSelectProcedure("GetCompletePurchasesOrder"
                                                            , objSQLHelper.SqlParam("@Company_id", CompanyId, SqlDbType.Int)
                                                            );

            List<int> lstCompleteDeliverPurchasesOrder = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstCompleteDeliverPurchasesOrder.Add((int)dt.Rows[i]["Purchases_Order_Id"]);
            }

            return lstCompleteDeliverPurchasesOrder;
        }
        public List<PurchaseOrderEL> GetPurchasesOrderByBillId(int BillId)
        {
            PurchaseOrderEL objPurchasesOrderEL;
            List<PurchaseOrderEL> lstPurchasesOrder = new List<PurchaseOrderEL>();
            
            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("GetPurchasesOrderByBillId"
                                                    , objSQLHelper.SqlParam("@Bill_Id", BillId, SqlDbType.Int)
                                                    );

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPurchasesOrderEL = new PurchaseOrderEL();
                    objPurchasesOrderEL.Company_id = Convert.ToInt32(dt.Rows[i]["Company_id"]);
                    objPurchasesOrderEL.Date = Convert.ToDateTime(dt.Rows[i]["Date"]);
                    objPurchasesOrderEL.Purchases_Order_Id = Convert.ToInt32(dt.Rows[i]["Purchases_Order_Id"]);
                    objPurchasesOrderEL.Purchases_Order_No = dt.Rows[i]["Purchases_Order_No"].ToString();
                    objPurchasesOrderEL.Tax_Percentage = Convert.ToDecimal(dt.Rows[i]["Tax_Percentage"]);
                    objPurchasesOrderEL.Other_Amount = Convert.ToDecimal(dt.Rows[i]["Other_Amount"]);
                    objPurchasesOrderEL.Requisitioner = dt.Rows[i]["Requisitioner"].ToString();
                    objPurchasesOrderEL.Credit_Term = dt.Rows[i]["Credit_Term"].ToString();
                    objPurchasesOrderEL.Shipping_Term = dt.Rows[i]["Shipping_Term"].ToString();
                    objPurchasesOrderEL.Comments = dt.Rows[i]["Comments"].ToString();
                    lstPurchasesOrder.Add(objPurchasesOrderEL);
                }
            }
            return lstPurchasesOrder;
        }
    }
}
