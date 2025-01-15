using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodzx.Power1.DataAccess.Interfaces
{
    public interface IDataAccessConfiguration
    {
        string ConnectionString { get; }
    }
}
