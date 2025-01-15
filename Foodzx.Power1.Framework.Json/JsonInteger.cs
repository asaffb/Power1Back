using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Json.Interface;

namespace Foodzx.Power1.Framework.Json
{
    public class JsonInteger : IJsonObject
    {
        public JsonInteger(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public int Value { get; private set; } = 0;
    }
}
