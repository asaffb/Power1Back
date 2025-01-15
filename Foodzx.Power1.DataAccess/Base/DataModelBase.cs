using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodzx.Power1.DataAccess.Base
{
    public class DataModelBase
    {
        public virtual void LoadFromReader(IDataReader dataReader)
        {
            // Implement on derived types if needed
            throw new NotImplementedException("LoadFromReader is not implemented.");
        }

        public int? GetIntFromDB(object value)
        {
            int? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.GetType() == typeof(int))
                {
                    result = (int)value;
                }
                else
                {
                    throw new Exception(string.Format("Failed to convert db value '{0}' to Int from '{1}': ", value.ToString(), value.GetType().ToString()));
                }
            }


            return result;
        }

        public long? GetLongFromDB(object value)
        {
            long? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.GetType() == typeof(long))
                {
                    result = (long)value;
                }
                else
                {
                    throw new Exception(string.Format("Failed to convert db value '{0}' to Long from '{1}': ", value.ToString(), value.GetType().ToString()));

                }
            }


            return result;
        }

        public decimal? GetDecimalFromDB(object value)
        {
            decimal? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.GetType() == typeof(decimal))
                {
                    result = (decimal)value;
                }
                else
                {
                    throw new Exception(string.Format("Failed to convert db value '{0}' to Decimal from '{1}': ", value.ToString(), value.GetType().ToString()));
                }
            }


            return result;
        }

        public decimal? GetDecimalFromDBString(object value)
        {
            decimal? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    if (Decimal.TryParse(value.ToString(), out decimal tempDecimal))
                    {
                        result = tempDecimal;
                    }
                    else
                    {
                        throw new Exception(string.Format("Failed to convert db value '{0}' to Decimal from string. Type is '{1}': ", value.ToString(), value.GetType().ToString()));
                    }
                }
            }


            return result;
        }

        public double? GetDoubleFromDB(object value)
        {
            double? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.GetType() == typeof(double))
                {
                    result = (double)value;
                }
                else
                {
                    throw new Exception(string.Format("Failed to convert db value '{0}' to Double from '{1}': ", value.ToString(), value.GetType().ToString()));
                }
            }


            return result;
        }

        public string GetStringFromDB(object value)
        {
            string result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                result = value.ToString();
            }


            return result;
        }

        public bool GetBoolFromDB(object value)
        {
            bool result = false;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.ToString() != "" && value.ToString() != "0" && value.ToString().ToLower() != "false")
                {
                    result = true;
                }
            }

            return result;
        }

        public Guid? GetGuidFromDB(object id)
        {
            Guid? result = null;

            if ((id != null) & (id != DBNull.Value))
            {
                if (id.GetType() == typeof(Guid))
                {
                    result = (Guid)id;
                }
                else
                {
                    if (id.GetType() == typeof(byte[]))
                    {
                        if (((byte[])id).Length == 0)
                            result = Guid.Empty;

                        else if (((byte[])id).Length == 16)
                            result = new Guid((byte[])id);
                    }
                    else if (id.GetType() == typeof(string))
                    {
                        if (((string)id).Length == 0)
                            result = Guid.Empty;

                        else if (((string)id).Length == 36)
                            result = new Guid((string)id);
                    }
                }

                if (result == null)
                {
                    throw new Exception("Failed to convert db value to GUID: " + id.ToString());
                }
            }

            return result;
        }

        public DateTime? GetDateTimeFromDB(object value)
        {
            DateTime? result = null;

            if ((value != null) && (value != DBNull.Value))
            {
                if (value.GetType() == typeof(DateTime))
                {
                    result = (DateTime)value;
                }
                else
                {
                    throw new Exception(string.Format("Failed to convert db value '{0}' to DateTime from '{1}': ", value.ToString(), value.GetType().ToString()));
                }
            }


            return result;
        }

        /*
        /// <summary>This function converts a value returned from the database in one of the
        /// supported formats into a UUID.  This function is not actually DBMS-specific right
        /// now
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UUID? GetUUIDFromDB(object id)
        {
            if ((id == null) || (id == DBNull.Value))
                //return UUID.Zero;
                return null;

            if (id.GetType() == typeof(Guid))
                return new UUID((Guid)id);

            if (id.GetType() == typeof(byte[]))
            {
                if (((byte[])id).Length == 0)
                    return UUID.Zero;
                else if (((byte[])id).Length == 16)
                    return new UUID((byte[])id, 0);
            }
            else if (id.GetType() == typeof(string))
            {
                if (((string)id).Length == 0)
                    return UUID.Zero;
                else if (((string)id).Length == 36)
                    return new UUID((string)id);
            }

            throw new Exception("Failed to convert db value to UUID: " + id.ToString());
        }
        */


        public Dictionary<string, object> Data;
    }
}
