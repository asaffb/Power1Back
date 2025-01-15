using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Interfaces;
using MySql.Data.MySqlClient;

namespace Foodzx.Power1.DataAccess
{
    public class DataAccessManager
    {
        public void TestConnection(IDataAccessConfiguration dataAccessConfiguration)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(dataAccessConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                mySqlConnection.Close();
            }
        }
    }
}
