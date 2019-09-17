namespace $rootnamespace$.Configuration
{
	using Deylin.Utils.ApplicationContext.Configuration;
	using System;

    public class Data : IData
    {
        public Guid GUID { get; set; }

        public string ApplicationName { get; set; }

        public EnvironmentTypes Environment { get; set; }

        public string Release { get; set; }

        public Version Version { get; set; }
    }
}
