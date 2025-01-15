using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;
using Newtonsoft.Json;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonString : IJsonObject
    {
        public JsonString(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return JsonConvert.ToString(this.Value);
        }

        public string Value { get; private set; } = string.Empty;
    }
}
