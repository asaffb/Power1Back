using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonBoolean : IJsonObject
    {
        public JsonBoolean(bool value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return (this.Value ? "true" : "false");
        }

        public bool Value { get; private set; } = false;
    }
}
