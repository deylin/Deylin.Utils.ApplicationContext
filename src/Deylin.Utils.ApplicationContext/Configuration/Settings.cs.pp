using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace $rootnamespace$.Configuration
{
    internal static class Settings
    {

        public static Deylin.Utils.ApplicationContext.Configuration.Settings<Configuration.Data> Current
        {
            get
            {
                return new Deylin.Utils.ApplicationContext.Configuration.Settings<Data>("$rootnamespace$", Assembly.GetExecutingAssembly(), "$rootnamespace$.json");
            }
        }
    }
}
