using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.Json;

namespace Foodzx.Power1.Framework.Common.Providers
{
    public class ActionResultJsonProvider
    {
        public static JsonObject GetJsonObject(ActionResultDataModel actionResult, JsonObject data)
        {
            JsonObject result = new JsonObject();

            if (actionResult != null)
            {
                result.Add("IsOK", new JsonBoolean(actionResult.IsOK));

                result.Add("ErrorMessage", new JsonString(actionResult.ErrorMessage));

                if (!string.IsNullOrEmpty(actionResult.ErrorDescription))
                {
                    result.Add("ErrorDescription", new JsonString(actionResult.ErrorDescription));
                }

                if (data == null)
                {

                    result.Add("Data", new JsonObject());
                }
                else
                {
                    result.Add("Data", data);
                }
            }

            return result;
        }
    }
}
