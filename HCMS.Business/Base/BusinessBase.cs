using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration.Provider;
using System.Configuration;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

using HCMS.Business.Common;

namespace HCMS.Business.Base
{
    /// <summary>
    /// Base Processing for all Business Objects
    /// </summary>
    [Serializable]
    public abstract class BusinessBase : ExceptionBase
    {
        #region Members

        private static Database _database = DatabaseFactory.CreateDatabase();

        #endregion

        #region Properties

        protected Database CurrentDatabase
        {
            get
            {
                return _database;
            }
        }

        #endregion

        #region Helper Methods

        #region Field Validation

        protected bool ValidateKeyField(Guid primaryKeyID)
        {
            if (primaryKeyID == Guid.Empty)
                throw new BusinessException("You must set the primary key before using this business object.");

            return true;
        }

        protected bool ValidateKeyField(int primaryKeyID)
        {
            if (primaryKeyID == -1)
                throw new BusinessException("You must set the primary key before using this business object.");

            return true;
        }

        protected bool ValidateKeyField(long primaryKeyID)
        {
            if (primaryKeyID == -1)
                throw new BusinessException("You must set the primary key before using this business object.");

            return true;
        }

        #endregion

        #region Parameters

        protected static void SetParameter<T>(DbCommand commandWrapper, string SQLParamName, T ? searchParam, T defaultValue)
                where T : struct
        {
            if (searchParam.HasValue && !searchParam.Value.Equals(defaultValue))
                commandWrapper.Parameters.Add(new SqlParameter(SQLParamName, searchParam.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter(SQLParamName, DBNull.Value));
        }

        protected static void SetParameter<T>(DbCommand commandWrapper, string SQLParamName, T searchParam, T defaultValue)
        {
            if (searchParam.Equals(defaultValue))
                commandWrapper.Parameters.Add(new SqlParameter(SQLParamName, DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter(SQLParamName, searchParam));
        }

        #endregion

        protected static DbCommand GetDbCommand(string sprocName)
        {
            return _database.GetStoredProcCommand(sprocName);
        }

        protected static string GetCommaDelimitedList(ArrayList paramList)
        {
            StringBuilder commaList = new StringBuilder();
            int cnt = 0;

            if (paramList != null)
            {
                if (paramList.Count == 0)
                    commaList.Append(paramList[0].ToString());
                else
                {
                    foreach (object singleParam in paramList)
                    {
                        if (cnt > 0)
                            commaList.Append(", ");

                        commaList.Append(singleParam.ToString());
                        cnt += 1;
                    }
                }
            }

            return commaList.ToString();
        }

        #endregion

        #region "General data access methods"

        public static Database CurrentDb
        { get { return _database; } }

        #region "ExecuteNonQuery"
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            return _database.ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
        {
            return _database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        public static void ExecuteNonQuery(DbCommand commandWrapper)
        {
            _database.ExecuteNonQuery(commandWrapper);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        public static void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
        {
            _database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);
        }


        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return _database.ExecuteNonQuery(commandType, commandText);
        }
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
        {
            Database database = transactionManager.Database;
            return database.ExecuteNonQuery(transactionManager.TransactionObject, commandType, commandText);
        }
        #endregion

        #region "ExecuteDataReader"
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
        {
            return _database.ExecuteReader(storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
        {
            Database database = transactionManager.Database;
            return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(DbCommand commandWrapper)
        {
            return _database.ExecuteReader(commandWrapper);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
        {
            Database database = transactionManager.Database;
            return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);
        }


        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return _database.ExecuteReader(commandType, commandText);
        }
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
        {
            Database database = transactionManager.Database;
            return database.ExecuteReader(transactionManager.TransactionObject, commandType, commandText);
        }
        #endregion

        #region "ExecuteDataSet"
        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            return _database.ExecuteDataSet(storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
        {
            Database database = transactionManager.Database;
            return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(DbCommand commandWrapper)
        {
            return _database.ExecuteDataSet(commandWrapper);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
        {
            Database database = transactionManager.Database;
            return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);
        }


        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            return _database.ExecuteDataSet(commandType, commandText);
        }
        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
        {
            Database database = transactionManager.Database;
            return database.ExecuteDataSet(transactionManager.TransactionObject, commandType, commandText);
        }
        #endregion

        #region "ExecuteScalar"
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
        {
            return _database.ExecuteScalar(storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
        {
            Database database = transactionManager.Database;
            return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(DbCommand commandWrapper)
        {
            return _database.ExecuteScalar(commandWrapper);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandWrapper">The command wrapper.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
        {
            Database database = transactionManager.Database;
            return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(CommandType commandType, string commandText)
        {
            return _database.ExecuteScalar(commandType, commandText);
        }
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        protected static object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
        {
            Database database = transactionManager.Database;
            return database.ExecuteScalar(transactionManager.TransactionObject, commandType, commandText);
        }
        #endregion

        #region Execute DataTable

        public static DataTable ExecuteDataTable(string sprocName, params object[] paramList)
        {
            DbCommand command = null;

            if (paramList.GetUpperBound(0) == -1)
                command = _database.GetStoredProcCommand(sprocName);
            else
                command = _database.GetStoredProcCommand(sprocName, paramList);

            return DatabaseUtility.ExecuteDataSet(_database, command).Tables[0];
        }

        public static DataTable ExecuteDataTable(int startRowIndex, int maximumRows, string sprocName, params object[] paramList)
        {
            DataTable table = null;

            using (DbConnection connection = _database.CreateConnection())
            {
                connection.Open();

                DbCommand command = null;

                if (paramList.GetUpperBound(0) == -1)
                    command = _database.GetStoredProcCommand(sprocName);
                else
                    command = _database.GetStoredProcCommand(sprocName, paramList);

                command.Connection = connection;

                DbDataAdapter da = _database.GetDataAdapter();
                da.SelectCommand = command;

                DataSet ds = new DataSet();

                da.Fill(ds, startRowIndex, maximumRows, "table");

                if (ds.Tables["table"] != null)
                {
                    table = ds.Tables["table"];
                }
            }

            return table;
        }

        public static DataTable ExecuteDataTable(DbCommand command)
        {
            return DatabaseUtility.ExecuteDataSet(_database, command).Tables[0];
        }

        public static DataTable ExecuteDataTable(TransactionManager transaction, DbCommand command)
        {
            return DatabaseUtility.ExecuteDataSet(transaction, command).Tables[0];
        }

        #endregion

        #endregion
    }
}
