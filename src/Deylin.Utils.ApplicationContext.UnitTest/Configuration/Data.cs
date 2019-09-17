using Deylin.Utils.ApplicationContext.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deylin.Utils.ApplicationContext.UnitTest.Configuration
{
    public class Data : IData
    {
        public Guid GUID { get; set; }

        public string ApplicationName { get; set; }

        public EnvironmentTypes Environment { get; set; }

        public string Release { get; set; }

        public Version Version { get; set; }

        public UnitTestClass TestClass { get; set; }
    }

    public class UnitTestClass
    {
        public string TestString { get; set; }
    }
}
