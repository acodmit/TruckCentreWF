using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TruckCentreWF.Util
{
    public class Constants
    {
        public static readonly string ConnString = "Server=localhost;Port=3306;Database=truckcentre;User=root;Password=root;";
        public static readonly int PreconnectCount = 10;
        internal static readonly int MaxIdleConnections = 10;
    }
}
