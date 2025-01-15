using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonGuid : IJsonObject
    {
        public JsonGuid(Guid value)
        {
            Value = value;
        }

        public override string ToString()
        {
            // TODO: Escape output for JSON
            return string.Concat(@"""", this.Value.ToString(), @"""");
        }

        public Guid Value { get; private set; } = Guid.Empty;
    }
}
