using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skcc.Transactions;
using Skcc.Data;
using System.Collections;
using System.Data.Common;
using System.Data;

namespace eHR.Framework.Base
{
    public class ShDacBase : DacBase
    {
        /// 
        /// Common 데이터 액세스 컴포넌트
        ///
        private DataAccessWrapper _daw = null;

        public DataAccessWrapper daWrapper
        {
            get { return _daw; }
            set { _daw = value; }
        }

        // 기본 연결 문자열
        private string _connectionString = string.Empty;

        protected string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public ShDacBase(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDataAccess();
        }

        /// 
        /// create new instance of DataAccessWrapper
        ///
        public ShDacBase()
        {
            InitializeDataAccess();
        }

        private void InitializeDataAccess()
        {
            if (string.IsNullOrEmpty(_connectionString) == true)
            {
                _connectionString = SetConnectionString();
            }

            if (string.IsNullOrEmpty(_connectionString) == false)
            {
                _daw = new DataAccessWrapper(_connectionString);
            }
            else
            {
                _daw = new DataAccessWrapper();
            }

            string xmlFilePath = SetXmlFilePath();

            if (string.IsNullOrEmpty(xmlFilePath) == false)
            {
      
            }
        }

        // 프로젝트에 특화된 내용을 여기에 추가하거나, 재정의하는 곳임.

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string SetConnectionString()
        {
            return string.Empty;
        }

        protected virtual string SetXmlFilePath()
        {
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="_type"></param>
        /// <param name="size"></param>
        /// <param name="_parameter"></param>
        /// <returns></returns>
        protected DbCommand EditOutPutParameter(DbCommand cmd, System.Data.DbType _type, int size, string _parameter)
        {
            cmd.Parameters.RemoveAt(string.Format("@{0}", _parameter));

            DbParameter dp = cmd.CreateParameter();

            dp.Direction = System.Data.ParameterDirection.Output;
            dp.DbType = _type;
            dp.Size = size;
            dp.ParameterName = string.Format("@{0}", _parameter);

            cmd.Parameters.Add(dp);

            return cmd;
        }

        protected int ExecuteNonQuery(DataAccessWrapper _daw, string storedProcedureName, Hashtable row, int timeout)
        {
            DbCommand cmd = _daw.GetStoredProcCommand(storedProcedureName, row);
            cmd.CommandTimeout = timeout;
            return _daw.ExecuteNonQuery(cmd);

        }

        protected DataSet ExecuteDataSet(DataAccessWrapper _daw, string storedProcedureName, Hashtable row, int timeout)
        {
            DbCommand cmd = _daw.GetStoredProcCommand(storedProcedureName, row);
            cmd.CommandTimeout = timeout;
            return _daw.ExecuteDataSet(cmd);

        }
    }
}
