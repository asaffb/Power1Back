using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonArray : IJsonObject
    {
        public JsonArray Add(IJsonObject jsonObject)
        {
            this.ChildList.Add(jsonObject);

            return this;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder()
                .Append("[");

            bool isFirst = true;

            foreach (IJsonObject currentJasonObjectKVP in this.ChildList)
            {
                if (isFirst)
                {

                    isFirst = false;
                }
                else
                {
                    stringBuilder.Append(",");
                }

                if (currentJasonObjectKVP == null)
                {

                    stringBuilder.AppendFormat("null");
                }
                else
                {
                    stringBuilder.AppendFormat("{0}", currentJasonObjectKVP.ToString());
                }
            }

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }

        public List<IJsonObject> ChildList { get; private set; } = new List<IJsonObject>();
    }
}
