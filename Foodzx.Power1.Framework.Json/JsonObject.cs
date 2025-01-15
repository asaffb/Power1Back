using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;
using Newtonsoft.Json;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonObject : IJsonObject
    {
        public JsonObject Add(string name, IJsonObject jsonObject)
        {
            this.ChildList.Add(name, jsonObject);

            return this;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder()
                .Append("{");

            bool isFirst = true;

            foreach (KeyValuePair<string, IJsonObject> currentJasonObjectKVP in this.ChildList)
            {
                if (isFirst)
                {

                    isFirst = false;
                }
                else
                {
                    stringBuilder.Append(",");
                }

                if (currentJasonObjectKVP.Value == null)
                {

                    stringBuilder.AppendFormat(@"{0}:null", JsonConvert.ToString(currentJasonObjectKVP.Key));
                }
                else
                {
                    stringBuilder.AppendFormat(@"{0}:{1}", JsonConvert.ToString(currentJasonObjectKVP.Key), currentJasonObjectKVP.Value.ToString());
                }
            }

            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }

        public Dictionary<string, IJsonObject> ChildList { get; private set; } = new Dictionary<string, IJsonObject>();
    }
}
