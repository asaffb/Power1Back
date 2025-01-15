using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Foodzx.Power1.DataAccess.Base
{
    public class MySqlDataAccessBase<TDataModel> : MySqlDataAccessPrimeBase where TDataModel : DataModelBase
    {
        public MySqlDataAccessBase(MySqlDataAccessConnection connection) : base (connection)
        {

        }

        public int ExecuteNonQuery(string query)
        {
            return this.ExecuteNonQuery(query, null);
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = 0;

            MySqlCommand mySqlCommand = this.GetCommand(query);

            /*
            if (this.IsAutoMode)
            {
                mySqlConnection = this.GetAutoConnection();
                mySqlCommand = this.GetCommand(query, mySqlConnection);
            }
            else
            {
                //mySqlConnection = this.Connection;
                mySqlCommand = this.GetCommand(query);
            }
            */

            using (mySqlCommand)
            {
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> currentParameterKVP in parameters)
                    {
                        mySqlCommand.Parameters.AddWithValue(currentParameterKVP.Key, currentParameterKVP.Value);
                    }
                }

                result = mySqlCommand.ExecuteNonQuery();
            }

            this.DoneCommand();

            /*
            if (this.IsAutoMode)
            {
                this.DisposeConnection(mySqlConnection);
            }
            */

            return result;
        }

        public List<TDataModel> GetAll()
        {
            return this.GetFromQuery(null);
        }

        public List<TDataModel> GetFromQuery(string query)
        {
            return this.GetFromQuery(query, null);
        }

        public List<TDataModel> GetFromQuery(string query, Dictionary<string, object> parameters)
        {
            List<TDataModel> result = new List<TDataModel>();

            TDataModel dataModel;


            if (string.IsNullOrEmpty(query))
                query = this.GetAllQuery();


            MySqlCommand mySqlCommand = this.GetCommand(query);

            /*
            if (this.IsAutoMode)
            {
                mySqlConnection = this.GetAutoConnection();
                mySqlCommand = this.GetCommand(query, mySqlConnection);
            }
            else
            {
                //mySqlConnection = this.Connection;
                mySqlCommand = this.GetCommand(query);
            }
            */

            using (mySqlCommand)
            {

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> currentParameterKVP in parameters)
                    {
                        mySqlCommand.Parameters.AddWithValue(currentParameterKVP.Key, currentParameterKVP.Value);
                    }
                }

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    List<string> columnNameList = null;

                    while (mySqlDataReader.Read())
                    {
                        dataModel = this.CreateDataModel();

                        dataModel.LoadFromReader(mySqlDataReader);

                        if (columnNameList == null)
                        {
                            columnNameList = this.GetColumnNames(mySqlDataReader);
                        }

                        dataModel.Data = this.LoadRowData(mySqlDataReader, columnNameList);

                        result.Add(dataModel);
                    }
                }
            }

            this.DoneCommand();

            /*
            if (this.IsAutoMode)
            {
                this.DisposeConnection(mySqlConnection);
            }
            */

            return result;
        }

        public List<Dictionary<string, object>> GetDataFromQuery(string query, Dictionary<string, object> parameters)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            Dictionary<string, object> data;

            if (string.IsNullOrEmpty(query))
                query = this.GetAllQuery();

            MySqlCommand mySqlCommand = this.GetCommand(query);

            /*
            if (this.IsAutoMode)
            {
                mySqlConnection = this.GetAutoConnection();
            }
            else
            {
                mySqlConnection = this.Connection;
            }
            */

            using (mySqlCommand)
            {

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> currentParameterKVP in parameters)
                    {
                        mySqlCommand.Parameters.AddWithValue(currentParameterKVP.Key, currentParameterKVP.Value);
                    }
                }

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    List<string> columnNameList = null;

                    while (mySqlDataReader.Read())
                    {
                        if (columnNameList == null)
                        {
                            columnNameList = this.GetColumnNames(mySqlDataReader);
                        }

                        data = this.LoadRowData(mySqlDataReader, columnNameList);

                        result.Add(data);
                    }
                }
            }

            this.DoneCommand();

            /*
            if (this.IsAutoMode)
            {
                this.DisposeConnection(mySqlConnection);
            }
            */

            return result;
        }

        public long? GetCount(string query, string columnName)
        {
            long? result = null;

            result = this.GetCount(query, null, columnName);

            return result;
        }

        public long? GetCount(string query, Dictionary<string, object> parameters, string columnName)
        {
            long? result = null;

            List<Dictionary<string, object>> dataList = this.GetDataFromQuery(query, parameters);

            if (dataList.Count > 0)
            {
                if (dataList[0].ContainsKey(columnName))
                {
                    //Debug.WriteLine(dataList[0][columnName].GetType().ToString());

                    result = this.CreateDataModel().GetLongFromDB(dataList[0][columnName]);
                }
            }

            return result;
        }


        public List<string> GetColumnNames(IDataReader dataReader)
        {
            List<string> result = new List<string>();

            DataTable schemaTable = dataReader.GetSchemaTable();

            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["ColumnName"] != null)
                    result.Add(row["ColumnName"].ToString());
            }

            return result;
        }

        public Dictionary<string, object> LoadRowData(IDataReader dataReader, List<string> columnNameList)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (string currentColumnName in columnNameList)
            {
                result[currentColumnName] = dataReader[currentColumnName];
            }


            return result;
        }

        public virtual TDataModel CreateDataModel()
        {
            // Implement on derived types if needed
            throw new NotImplementedException("CreateDataModel is not implemented.");
        }

        public virtual string GetTableName()
        {
            // Implement on derived types if needed
            throw new NotImplementedException("GetTableName is not implemented.");
        }

        public virtual string GetAllQuery()
        {
            return string.Format("SELECT * FROM {0}", this.GetTableName());
        }
    }
}
