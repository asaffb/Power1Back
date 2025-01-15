using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.Configuration;
using Foodzx.Power1.Framework.DataModel;
using Foodzx.Power1.Framework.Providers;

namespace Foodzx.Power1.Framework
{
    public class UserManager
    {
        public (ActionResultDataModel, List<UserDataModel>) GetAllUsers(FrameworkConfigurationDataModel frameworkConfigurationDataModel)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            List<UserDataModel> userList = new List<UserDataModel>();


            UserProvider userProvider = new UserProvider();


            MySqlDataAccessConnection mySqlDataAccessConnection = null;

            try
            {
                mySqlDataAccessConnection = new MySqlDataAccessConnection(frameworkConfigurationDataModel.ConnectionString);

                mySqlDataAccessConnection.OpenConnection();


                (result, userList) = userProvider.GetAllUsers(mySqlDataAccessConnection);
            }
            catch (Exception ex)
            {
                result = new ActionResultDataModel(ex);
            }
            finally
            {
                mySqlDataAccessConnection.CloseConnection();
                mySqlDataAccessConnection.DisposeConnection();
            }

            return (result, userList);
        }

        public (ActionResultDataModel, Guid) CreateUser(UserDataModel userDataModel, FrameworkConfigurationDataModel frameworkConfigurationDataModel)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            Guid userId = Guid.Empty;

            UserProvider userProvider = new UserProvider();


            MySqlDataAccessConnection mySqlDataAccessConnection = null;

            try
            {
                mySqlDataAccessConnection = new MySqlDataAccessConnection(frameworkConfigurationDataModel.ConnectionString);

                mySqlDataAccessConnection.OpenConnection();

                mySqlDataAccessConnection.BeginTransaction();


                (result, userId) = userProvider.CreateUser(userDataModel, mySqlDataAccessConnection);


                if (result.IsOK)
                {
                    mySqlDataAccessConnection.CommitTransaction();
                }
                else
                {
                    mySqlDataAccessConnection.RollbackTransaction();
                }
            }
            catch (Exception ex)
            {
                mySqlDataAccessConnection.RollbackTransaction();

                result = new ActionResultDataModel(ex);
            }
            finally
            {
                mySqlDataAccessConnection.CloseConnection();
                mySqlDataAccessConnection.DisposeConnection();
            }


            return (result, userId);
        }
    }
}
