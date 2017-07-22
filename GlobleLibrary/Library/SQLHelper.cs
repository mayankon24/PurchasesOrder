//===============================================================================
// SQL HELPER CLASS
//===============================================================================
// THIS FILE PROVIDES THE FUNCTIONS FOR CONNECTING THROUGH THE DATABASE, 
// ALLOWS THE SELECT, INSERT, UPDATE OPRETAIONS ON THE DATABASE
//
// CREATED BY: MEGHA GUPTA
// DATE CREATED: 7/04/10
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace GlobleLibrary
{
    public class SQLHelper
    {
        string sqlConnStr;
        SqlCommand SqlCommand;
        SqlDataAdapter SqlDAdapter;
        SqlConnection sqlConn = null;
        
        DataTable dt;


        /// <summary>
        /// Gets the connection string.
        /// </summary>
        private string ConnectionString()
        {
            sqlConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["PurchasesOrder.Properties.Settings.DataConnectionString"].ToString();
            return sqlConnStr;
        }

        /// <summary>
        /// Returns the connection object.
        /// </summary>
        /// <returns></returns>
        private SqlConnection Connection()
        {
            sqlConn = new SqlConnection(ConnectionString());
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            return sqlConn;
        }

        /// <summary>
        /// Executes the select query, make calls to the connection function to get the connection
        /// </summary>
        /// <param name="str" >
        /// <value>Select quesry that has to executed</value>
        /// </param>
        /// <returns>Datable with the select query result </returns>
        public DataTable ExecuteSelectCommand(string str)
        {
            try
            {
              dt = new DataTable();
              SqlCommand = new SqlCommand(str, Connection());
              SqlDAdapter = new SqlDataAdapter(SqlCommand);
                
                SqlDAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, str, e.Message);
               throw e;
            }
            finally
            {
                if (Connection().State == ConnectionState.Open)
                    Connection().Close();

                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }
        }


        public DataTable ExecuteSelectCommand(string str,SqlTransaction transaction)
        {
            try
            {
                dt = new DataTable();
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(str, transaction.Connection, transaction);
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, str, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }
        }


        /// <summary>
        /// Executes the insert query.
        /// </summary>
        /// <param name="str" >
        /// <value>insert query that has to be executed</value>
        /// </param>
        /// <returns>Number of records inserted.</returns>

        public int ExecuteInsertCommand(SqlTransaction objSQLTransaction, string str, SqlTransaction transaction)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();
                
                dt = new DataTable();

                SqlCommand = new SqlCommand(str, transaction.Connection, transaction);
               return Convert.ToInt32(SqlCommand.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, str, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }
        }

        /// <summary>
        /// Executes the insert query.
        /// </summary>
        /// <param name="str" >
        /// <value>insert query that has to be executed</value>
        /// </param>
        /// <returns>Number of records inserted.</returns>
        public int ExecuteUpdateCommand(SqlTransaction _objSQLTransaction, string str)
        {
            try
            {
                if (_objSQLTransaction.Connection.State == ConnectionState.Closed)
                    _objSQLTransaction.Connection.Open();

                dt = new DataTable();
                SqlCommand = new SqlCommand(str, _objSQLTransaction.Connection, _objSQLTransaction);
                return SqlCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, str, e.Message);
                throw e;
            }
            finally
            {
                if (SqlDAdapter != null)
                {
                    SqlDAdapter.Dispose();
                    SqlDAdapter = null;
                }
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
            }
        }

        #region "ErrorLogging"

        /// <summary>
        /// Function to write the error to the error log table.
        /// </summary>
        /// <param name="stackStr">stack trace</param>
        /// <param name="sqlStr">sql query string</param>
        /// <param name="errMsg">error message</param>
        public void ErrorLogger(string stackStr, string sqlStr, string errMsg)
        {
            string errLOgName = String.Empty;
            string errDateTime = System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString();
            try
            {
                DataSet ds = new DataSet();
                string SQLStr =
                    " INSERT into TX_ERRORLOG (ErrTime, StackStr, SqlStr, ErrMsg)" +
                    " Values('" + errDateTime + "','" + stackStr + "','"
                     + sqlStr + "','" + errMsg.Replace("'","''") + "')";

                SqlCommand.CommandText = SQLStr;
                SqlDAdapter.SelectCommand = SqlCommand;
                SqlDAdapter.Fill(ds);
            }
            catch
            {
                LocalErrorLogger(stackStr, sqlStr, errMsg, errDateTime, "ErrorLogger.txt");
               // throw new Exception(e.Message, e.InnerException);
            }

        }

        /// <summary>
        /// Function to create and write the error to the local error file in the current directory.
        /// </summary>
        /// <param name="stackStr">error stack trace</param>
        /// <param name="sqlStr">sql query string</param>
        /// <param name="errMsg">error message</param>
        /// <param name="errDateTime">error date/time</param>
        private void LocalErrorLogger(string stackStr, string sqlStr, string errMsg, string errDateTime, string ErrorLogFName)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\"+ ErrorLogFName))
            {

                using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() +"\\"+ ErrorLogFName))
                {
                    sw.WriteLine("[DATE - TIME]" + errDateTime);
                    sw.WriteLine("[STACK STR]" + stackStr);
                    sw.WriteLine("[SQL STR]" + sqlStr);
                    sw.WriteLine("[ERROR MSG]" + errMsg);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() +"\\" + ErrorLogFName))
                {

                    sw.WriteLine("[DATE - TIME]" + errDateTime);
                    sw.WriteLine("[STACK STR]" + stackStr);
                    sw.WriteLine("[SQL STR]" + sqlStr);
                    sw.WriteLine("[ERROR MSG]" + errMsg);
                }
            }
        }
    #endregion


        /// <summary>
        /// Executes the insert query, without Transcation Object
        /// </summary>
        /// <param name="str" >
        /// <value>insert query that has to be executed</value>
        /// </param>
        /// <returns>Number of records inserted.</returns>

        public int ExecuteInsertCommand(String str, SqlTransaction transaction)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(str, transaction.Connection, transaction);
                return Convert.ToInt32(SqlCommand.ExecuteNonQuery());

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, str, e.Message);
                throw e;

            }
        }

        public void ExecuteInsertProcedureNonQuery(string ProcedureName, SqlTransaction transaction, params IDataParameter[] parameters)
        { 
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(ProcedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                
                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }
                
                SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              
                throw e;
            }
        }

        public int ExecuteInsertProcedure(String procedureName,  SqlTransaction transaction, params SqlParameter[] parameters)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                
                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }
                int ID;
                ID=int.Parse(SqlCommand.ExecuteScalar().ToString());
                return ID; 
            }

            catch (Exception e)
            {
              
                throw e;
            }
         
        }

        public DataSet ExecuteInsertProcedureForGetDataSet(String procedureName, SqlTransaction transaction, params SqlParameter[] parameters)
        {

            DataSet ds = new DataSet();
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(ds);
                return ds;
            }

            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                ds.Dispose();
                ds = null;
            }

        }


        public int ExecuteInsertProcedureNonQuery(String procedureName, SqlParameter[] parameters, SqlTransaction transaction)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }

                int ID = int.Parse(SqlCommand.ExecuteNonQuery().ToString());
                return ID;
            }

            catch (Exception e)
            {

                throw e;
            }

        }


        /// <summary>
        /// This Overload is needed when no transaction is required.
        /// </summary>
        public int ExecuteInsertProcedure(String procedureName, params IDataParameter[] parameters)
        {
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteInsertProcedure_GetId(String procedureName, params IDataParameter[] parameters)
        {
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteUpdateProcedure(String procedureName, SqlTransaction transaction, params IDataParameter[] parameters)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();
                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteDeleteProcedure(String procedureName,  params IDataParameter[] parameters)
        {
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int ExecuteDeleteProcedure(String procedureName,SqlTransaction transaction, params IDataParameter[] parameters)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExecuteUpdateProcedure(String procedureName, SqlParameter[] parameters, SqlTransaction transaction)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }

                SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteUpdateProcedure(String procedureName, params IDataParameter[] parameters)
        {
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
                return SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable ExecuteSelectProcedure(String procedureName)
        {
            try
            {
                dt = new DataTable();
                SqlCommand = new SqlCommand(procedureName , Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure; 
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }

        }

        public DataTable ExecuteSelectProcedure(String procedureName, SqlParameter[] parameters)
        {
            try
            {
                dt = new DataTable();
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;

                         foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }
                string querystring = "EXEC " + procedureName + "  ";
                for(int ctr=0;ctr<parameters.Length;ctr++)
                {
                    querystring = querystring + parameters[ctr].Value + ",";
                
                }

                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }

        }


        public DataTable ExecuteSelectProcedure(String procedureName, SqlTransaction transaction, SqlParameter[] parameters)
        {
            try
            {
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                dt = new DataTable();
                SqlCommand = new SqlCommand(procedureName, transaction.Connection, transaction);               
                SqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter sqlPar in parameters)
                {
                    SqlCommand.Parameters.Add(sqlPar);
                }
                string querystring = "EXEC " + procedureName + "  ";
                for (int ctr = 0; ctr < parameters.Length; ctr++)
                {
                    querystring = querystring + parameters[ctr].Value + ",";

                }

                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                dt.Dispose();
                dt = null;
            }

        }


        public DataTable ExecuteSelectProcedure(String procedureName, params IDataParameter[] parameters)
        {
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                foreach (IDataParameter sqlPar in parameters)
                    SqlCommand.Parameters.Add(sqlPar);
               SqlDAdapter= new SqlDataAdapter(SqlCommand);
               SqlDAdapter.Fill(dt);
                return dt;

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;
                dt.Dispose();
                dt = null;
            }

        }

        public DataSet ExecuteSelectProcedureForDataSet(String procedureName)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(ds);
                return ds;

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                ds.Dispose();
                ds = null;
            }

        }

        public DataSet ExecuteSelectProcedureForDataSet(String procedureName, params IDataParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand = new SqlCommand(procedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (IDataParameter sqlPar in parameters)
                        SqlCommand.Parameters.Add(sqlPar);
                }
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(ds);
                return ds;

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, procedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                ds.Dispose();
                ds = null;
            }

        }

        /// <summary>
        /// Initializes sqlparameter with parameter name , value and its sqldatatype. 
        /// Check is made to validate its value for DBNull.
        /// </summary>
        /// <typeparam name="T">Type of value to be passed</typeparam>
        /// <param name="parameterName">Parameter Name as specified in Query or Stored Procedure. '@' is concatinated internally.  </param>
        /// <param name="value">Value to be set for in Database field.</param>
        /// <param name="dbType">DataType of Column Field</param>
        /// <returns>Initialized Sql parameter </returns>
        public SqlParameter SqlParam(string parameterName, object value, SqlDbType dbType)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = parameterName;
                param.SqlDbType = dbType;

                param.Value = object.Equals(value, null) ? DBNull.Value : value;
                return param;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region "SQLTransaction"
        /// <summary>
        /// Sets transaction in begintransaction mode
        /// </summary>
        /// <returns>return SQLtransction</returns>
        public SqlTransaction BeginTrans()
        {
            try
            {
                SqlTransaction trtmpTran;
                sqlConn = Connection();

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                trtmpTran = sqlConn.BeginTransaction();
                return trtmpTran;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Method for Commiting Transaction
        /// </summary>
        /// <param name="trCommitable">Transaction to be commited</param>
        public void CommitTrans(SqlTransaction trCommitable)
        {
            try
            {
                SqlConnection cnCon = trCommitable.Connection;
                trCommitable.Commit();
                cnCon.Close();
                cnCon.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method for RollBack Transaction
        /// </summary>
        /// <param name="trRollable">transaction to rollback</param>
        public void RollBackTrans(SqlTransaction trRollable)
        {
            try
            {
                SqlConnection cnCon = trRollable.Connection;
                trRollable.Rollback();

                cnCon.Close();
                cnCon.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion



        public DataSet MyCustomExecuteSelectProcedureForDataSet(String headerProcedureName, String BodyProcedureName, params IDataParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand = new SqlCommand(headerProcedureName, Connection());
                SqlCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (IDataParameter sqlPar in parameters)
                        SqlCommand.Parameters.Add(sqlPar);
                }
                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(ds, headerProcedureName);

                SqlCommand.CommandText = BodyProcedureName;

                SqlDAdapter = new SqlDataAdapter(SqlCommand);
                SqlDAdapter.Fill(ds, BodyProcedureName);

                return ds;

            }
            catch (Exception e)
            {
                ErrorLogger(e.StackTrace, headerProcedureName, e.Message);
                throw e;
            }
            finally
            {
                SqlDAdapter.Dispose();
                SqlDAdapter = null;

                ds.Dispose();
                ds = null;
            }

        }
    }
}
