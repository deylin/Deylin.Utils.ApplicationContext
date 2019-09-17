using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Deylin.Utils.ApplicationContext.UnitTest.Configuration
{
    internal static class Settings2
    {

        public static Deylin.Utils.ApplicationContext.Configuration.Settings<Configuration.Data> Current
        {
            get
            {
                return new Deylin.Utils.ApplicationContext.Configuration.Settings<Data>("Deylin.Utils.ApplicationContext.UnitTest", Assembly.GetExecutingAssembly(), "nonexisting.json");
            }
        }
    }
}
