using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Foodzx.Power1.DataAccess.Base
{
    public class MySqlDataAccessPrimeBase : DataModelBase
    {
        /*
        public MySqlDataAccessPrimeBase(string connectionString)
        {
            this.DataAccessConnection = new MySqlDataAccessConnection(connectionString);
        }
        */

        public MySqlDataAccessPrimeBase(MySqlDataAccessConnection connection)
        {
            this.DataAccessConnection = connection;
        }

        public MySqlCommand GetCommand(string query)
        {
            MySqlCommand result = null;

            if (this.DataAccessConnection.IsTransactionActive)
            {
                result = new MySqlCommand(query, this.DataAccessConnection.Connection, this.DataAccessConnection.Transaction);
            }
            else
            {
                if (!this.DataAccessConnection.IsConnectionOpen)
                {
                    this.DataAccessConnection.OpenAutoConnection();
                }

                result = new MySqlCommand(query, this.DataAccessConnection.Connection);
            }

            return result;
        }

        public void DoneCommand()
        {
            this.DataAccessConnection.Done();
        }

        public void BeginTransaction()
        {
            this.DataAccessConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.DataAccessConnection.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.DataAccessConnection.RollbackTransaction();
        }

        public void OpenConnection()
        {
            this.DataAccessConnection.OpenConnection();
        }

        public void CloseConnection()
        {
            this.DataAccessConnection.CloseConnection();
        }

        public void DisposeConnection()
        {
            this.DataAccessConnection.DisposeConnection();
        }

        /*
        public MySqlCommand GetCommand(string query, MySqlConnection connection)
        {
            MySqlCommand result = null;

            result = new MySqlCommand(query, connection);

            return result;
        }
        */

        /*
        public MySqlCommand GetCommandAndConnection(string query, out MySqlConnection connection)
        {
            MySqlCommand result = null;

            connection = null;

            if (this.DataAccessConnection.IsAutoMode)
            {
                connection = this.GetAutoConnection();
                result = this.GetCommand(query, connection);
            }
            else
            {
                result = this.GetCommand(query);
            }

            return result;
        }
        */

        /*
        public void CloseConnection()
        {
            if (this.IsConnectionOpen)
            {
                this.DataAccessConnection.Close();

                this.IsConnectionOpen = false;
            }
            else
            {
                throw new SystemException("Connection is not open.");
            }
        }

        public void DisposeConnection()
        {
            if (this.IsConnectionInit)
            {
                if (this.IsConnectionOpen)
                {
                    this.DataAccessConnection.Close();

                    this.IsConnectionOpen = false;
                }

                this.DataAccessConnection.Dispose();
                this.IsConnectionInit = false;
            }
            else
            {
                throw new SystemException("Connection is not initialized.");
            }
        }

        public void DisposeConnection(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Close();
            mySqlConnection.Dispose();
        }
        */


        /*
        protected MySqlConnection GetAutoConnection()
        {
            MySqlConnection result = new MySqlConnection(this.ConnectionString);

            result.Open();

            return result;
        }
        */


        public MySqlDataAccessConnection DataAccessConnection { get; private set; }

        /*
        public bool IsAutoMode { get; set; } = true;

        public string ConnectionString { get; protected set; } = string.Empty;

        public bool IsConnectionInit { get; protected set; } = false;

        public bool IsConnectionOpen { get; protected set; } = false;

        public bool IsTransactionActive { get; protected set; } = false;

        public MySqlConnection Connection { get; protected set; } = null;

        public MySqlTransaction Transaction { get; protected set; } = null;
        */
    }
}
