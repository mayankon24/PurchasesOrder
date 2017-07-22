using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobleLibrary;
using PurchasesOrder.Entity;

namespace PurchasesOrder.DataLayer
{
    class ItemNameDL
    {
        public int Insert(ItemNameEL objItemNameEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = objSQLHelper.ExecuteInsertProcedure("InsertItemName", objSqlTransaction
                                                         , objSQLHelper.SqlParam("@Item_Name", objItemNameEL.Item_name, SqlDbType.NVarChar)                                                                                                                 
                                                       );
                objSqlTransaction.Commit();
                return Id;
            }
            catch
            {
                objSqlTransaction.Rollback();
                return 0;
            }

        }
        public int Update(ItemNameEL objItemNameEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = objSQLHelper.ExecuteUpdateProcedure("UpdateItemName", objSqlTransaction
                                                         , objSQLHelper.SqlParam("@Item_Name", objItemNameEL.Item_name, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@Item_id", objItemNameEL.Item_id, SqlDbType.Int)
                                                       );
                objSqlTransaction.Commit();
                return Id;
            }
            catch
            {
                objSqlTransaction.Rollback();
                return 0;
            }

        }
        public bool Delete(ItemNameEL objItemNameEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int cpmpanyId = objSQLHelper.ExecuteDeleteProcedure("DeleteItemName", objSqlTransaction
                                                                    , objSQLHelper.SqlParam("@Item_id", objItemNameEL.Item_id, SqlDbType.Int)
                                                                   );
                objSqlTransaction.Commit();
                return true;
            }
            catch
            {
                objSqlTransaction.Rollback();
                return false;
            }

        }
        public List<ItemNameEL> GetItemNameAll()
        {
            ItemNameEL objItemNameEL;
            List<ItemNameEL> lstInputFieldEL = new List<ItemNameEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectItemNameAll");
            
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objItemNameEL = new ItemNameEL();
                    objItemNameEL.Item_id = (int)dt.Rows[i]["Item_id"];
                    objItemNameEL.Item_name = dt.Rows[i]["Item_name"].ToString();                                      
                    lstInputFieldEL.Add(objItemNameEL);
                }

            }
            return lstInputFieldEL;
        }       
        public ItemNameEL GetItemNameById(int ItemName_id)
        {
            ItemNameEL objItemNameEL = null;            
            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectItemNameById"
                                                                    , objSQLHelper.SqlParam("@Item_id", ItemName_id, SqlDbType.Int)
                                                                     );

            if (dt != null && dt.Rows.Count > 0)
            {
                objItemNameEL = new ItemNameEL();
                objItemNameEL.Item_id = (int)dt.Rows[0]["Item_id"];
                objItemNameEL.Item_name = dt.Rows[0]["Item_name"].ToString();
                
            }
            return objItemNameEL;
        }
        public DataTable GetpurchaseReport(DateTime startDate, DateTime endDate, int? companyId, int? itemId)
        {
            List<ItemNameEL> lstInputFieldEL = new List<ItemNameEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("PurchasesReport"
                                                                    , objSQLHelper.SqlParam("@Start_Date", startDate, SqlDbType.DateTime)
                                                                    , objSQLHelper.SqlParam("@End_date", endDate, SqlDbType.DateTime)
                                                                    , objSQLHelper.SqlParam("@Company_id", companyId, SqlDbType.BigInt)
                                                                    , objSQLHelper.SqlParam("@item_id", itemId, SqlDbType.BigInt)
                                                                );
            return dt;
        } 
    }
}




