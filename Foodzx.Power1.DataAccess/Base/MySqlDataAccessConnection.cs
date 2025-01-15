using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Foodzx.Power1.DataAccess.Base
{
    public class MySqlDataAccessConnection
    {
        public MySqlDataAccessConnection(string connectionString)
        {
            this.ConnectionString = connectionString;

            this.Connection = new MySqlConnection(this.ConnectionString);
        }


        public void OpenConnection()
        {
            if (!this.IsConnectionOpen)
            {
                if (!this.IsDirty)
                {
                    this.Connection.Open();

                    this.IsConnectionOpen = true;

                    this.IsDirty = true;

                    this.IsAutoMode = false;
                }
                else
                {
                    throw new SystemException("Cannot open dirty connection.");
                }
            }
            else
            {
                throw new SystemException("Connection is already open.");
            }
        }


        public void OpenAutoConnection()
        {
            if (!this.IsConnectionOpen)
            {
                if (!this.IsDirty)
                {
                    this.Connection.Open();

                    this.IsConnectionOpen = true;

                    this.IsDirty = true;
                }
                else
                {
                    throw new SystemException("Cannot open dirty connection.");
                }
            }
            else
            {
                throw new SystemException("Connection is already open.");
            }
        }


        public void BeginTransaction()
        {
            if (this.IsConnectionOpen)
            {
                if (!this.IsTransactionActive)
                {
                    this.Transaction = this.Connection.BeginTransaction();

                    this.IsTransactionActive = true;

                    this.IsAutoMode = false;
                }
                else
                {
                    throw new SystemException("Transaction is already active.");
                }
            }
            else
            {
                throw new SystemException("Cannot begin transaction when connection is not open.");
            }
        }

        public void CommitTransaction()
        {
            if (this.IsConnectionOpen)
            {
                if (this.IsTransactionActive)
                {
                    this.Transaction.Commit();

                    this.IsTransactionActive = false;
                }
                else
                {
                    throw new SystemException("Transaction is not active.");
                }
            }
            else
            {
                throw new SystemException("Cannot commit transaction when connection is not open.");
            }
        }

        public void RollbackTransaction()
        {
            if (this.IsConnectionOpen)
            {
                if (this.IsTransactionActive)
                {
                    this.Transaction.Rollback();

                    this.IsTransactionActive = false;
                }
                else
                {
                    throw new SystemException("Transaction is not active.");
                }
            }
            else
            {
                throw new SystemException("Cannot rollback transaction when connection is not open.");
            }
        }


        public void Done()
        {
            if (this.IsAutoMode)
            {
                this.CloseConnection();
                this.DisposeConnection();
            }
        }


        public void CloseConnection()
        {
            if (this.IsConnectionOpen)
            {
                try
                {
                    this.Connection.Close();
                }
                catch
                {
                    // Fail silently
                }

                this.IsConnectionOpen = false;
            }
            else
            {
                throw new SystemException("Connection is not open.");
            }
        }

        public void DisposeConnection()
        {
            if (this.IsConnectionOpen)
            {
                try
                {
                    this.Connection.Close();
                }
                catch
                {
                    // Fail silently
                }

                this.IsConnectionOpen = false;
            }

            try
            {
                this.Connection.Dispose();
            }
            catch
            {
                // Fail silently
            }
        }


        public bool IsAutoMode { get; private set; } = true;

        public string ConnectionString { get; private set; } = string.Empty;

        public bool IsConnectionOpen { get; private set; } = false;

        public bool IsTransactionActive { get; private set; } = false;

        public bool IsDirty { get; private set; } = false;

        public MySqlConnection Connection { get; private set; } = null;

        public MySqlTransaction Transaction { get; private set; } = null;
    }
}
