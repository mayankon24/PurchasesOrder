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
    class CompanyDL
    {
        public bool Insert(CompanyEL objCompanyEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = objSQLHelper.ExecuteInsertProcedure("InsertCompany", objSqlTransaction
                                                         , objSQLHelper.SqlParam("@tin_no", objCompanyEL.tin_no, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@company_name", objCompanyEL.company_name, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@address1", objCompanyEL.address1, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@pan_no", objCompanyEL.pan_no, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@city", objCompanyEL.city, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@state", objCompanyEL.state, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@pincode", objCompanyEL.pincode, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@email", objCompanyEL.email, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@phone", objCompanyEL.phone, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@Fax_No", objCompanyEL.Fax_No, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@delivery_at", objCompanyEL.delivery_at, SqlDbType.NVarChar)
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
        public bool Update(CompanyEL objCompanyEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int Id = objSQLHelper.ExecuteUpdateProcedure("UpdateCompany", objSqlTransaction
                                                         , objSQLHelper.SqlParam("@tin_no", objCompanyEL.tin_no, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@company_name", objCompanyEL.company_name, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@address1", objCompanyEL.address1, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@pan_no", objCompanyEL.pan_no, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@city", objCompanyEL.city, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@state", objCompanyEL.state, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@pincode", objCompanyEL.pincode, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@email", objCompanyEL.email, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@phone", objCompanyEL.phone, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@Fax_No", objCompanyEL.Fax_No, SqlDbType.NVarChar)
                                                         , objSQLHelper.SqlParam("@company_id", objCompanyEL.Company_id, SqlDbType.Int)
                                                         , objSQLHelper.SqlParam("@delivery_at", objCompanyEL.delivery_at, SqlDbType.NVarChar)
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
        public bool Delete(CompanyEL objCompanyEL)
        {
            SQLHelper objSQLHelper = new SQLHelper();
            SqlTransaction objSqlTransaction = objSQLHelper.BeginTrans();

            try
            {
                int cpmpanyId = objSQLHelper.ExecuteDeleteProcedure("DeleteCompany", objSqlTransaction
                                                                    , objSQLHelper.SqlParam("@company_id", objCompanyEL.Company_id, SqlDbType.Int)
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
        public List<CompanyEL> GetCompanyList()
        {
            CompanyEL objCompanyEL;
            List<CompanyEL> lstCompanyEL = new List<CompanyEL>();

            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectCompanyAll" );

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objCompanyEL = new CompanyEL();
                    objCompanyEL.Company_id = (int)dt.Rows[i]["company_Id"];
                    objCompanyEL.company_name = dt.Rows[i]["company_name"].ToString();
                    objCompanyEL.tin_no = dt.Rows[i]["tin_no"].ToString();
                    objCompanyEL.pan_no = dt.Rows[i]["pan_no"].ToString();
                    objCompanyEL.phone = dt.Rows[i]["phone"].ToString();
                    objCompanyEL.address1 = dt.Rows[i]["address1"].ToString();
                    objCompanyEL.city = dt.Rows[i]["city"].ToString();
                    objCompanyEL.state = dt.Rows[i]["state"].ToString();
                    objCompanyEL.pincode = dt.Rows[i]["pincode"].ToString();
                    objCompanyEL.email = dt.Rows[i]["email"].ToString();
                    objCompanyEL.phone = dt.Rows[i]["phone"].ToString();
                    objCompanyEL.Fax_No = dt.Rows[i]["Fax_No"].ToString();
                    objCompanyEL.delivery_at = dt.Rows[i]["delivery_at"].ToString();
                    lstCompanyEL.Add(objCompanyEL);

                }

            }
            return lstCompanyEL;
        }
        public CompanyEL GetCompanyById(int CompanyId)
        {
            CompanyEL objCompanyEL = null;            
            SQLHelper objSQLHelper = new SQLHelper();
            DataTable dt = objSQLHelper.ExecuteSelectProcedure("SelectCompanyById"
                                                                    , objSQLHelper.SqlParam("@Company_Id", CompanyId, SqlDbType.Int)
                                                                     );

            if (dt != null && dt.Rows.Count > 0)
            {
                objCompanyEL = new CompanyEL();
                objCompanyEL.Company_id = (int)dt.Rows[0]["company_Id"];
                objCompanyEL.company_name = dt.Rows[0]["company_name"].ToString();
                objCompanyEL.tin_no = dt.Rows[0]["tin_no"].ToString();
                objCompanyEL.pan_no = dt.Rows[0]["pan_no"].ToString();
                objCompanyEL.phone = dt.Rows[0]["phone"].ToString();
                objCompanyEL.address1 = dt.Rows[0]["address1"].ToString();
                objCompanyEL.city = dt.Rows[0]["city"].ToString();
                objCompanyEL.state = dt.Rows[0]["state"].ToString();
                objCompanyEL.pincode = dt.Rows[0]["pincode"].ToString();
                objCompanyEL.email = dt.Rows[0]["email"].ToString();
                objCompanyEL.phone = dt.Rows[0]["phone"].ToString();
                objCompanyEL.Fax_No = dt.Rows[0]["Fax_No"].ToString();
                objCompanyEL.delivery_at = dt.Rows[0]["delivery_at"].ToString();
            }
            return objCompanyEL;
        }
    }
}




