// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Current.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext
{
    using Deylin.Utils.ApplicationContext.Configuration;
    using Deylin.Utils.ApplicationContext.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Current : IDisposable
    {
        /// <summary>
        /// Dictionary with all configuration data
        /// </summary>
        private Dictionary<string, IData> ConfigurationData { get; set; }

        private NLog.Logger currentlogger;

        /// <summary>
        /// the instance of <see cref="CurrentMulti"/>
        /// </summary>
        private static readonly Current instance = new Current();

        /// <summary>
        /// Static contructor for <see cref="Current"/>
        /// </summary>
        static Current()
        {

        }

        /// <summary>
        /// Private contructor for <see cref="Current"/> to hide the constructor for creating an instance other than <see cref="Instance"/>
        /// </summary>
        private Current()
        {
            this.ConfigurationData = new Dictionary<string, IData>();
        }

        /// <summary>
        /// Creates a singleton instance of the current applicationcontext
        /// </summary>
        public static Current Instance => instance;

        public TData GetConfigurationData<TData>(Configuration.Settings<TData> settings)
            where TData : IData
        {
            try
            {
                TData result = default(TData);
                lock (this.ConfigurationData)
                {
                    result = (TData)this.ConfigurationData.FirstOrDefault(d => d.Key == settings.Name).Value;
                    if (result == null)
                    {
                        result = (TData)settings.Manager.GetConfigurationData();
                        this.ConfigurationData.Add(settings.Name, result);
                    }
                }

                return result;
            }
            catch (Exception exc)
            {
                this.OnException?.Invoke(this, exc);
                return default(TData);
            }
        }

        public void Log(Level level, string message, Exception exc = null)
        {
            try
            {
                if (this.currentlogger == null)
                {
                    this.currentlogger = NLog.LogManager.GetCurrentClassLogger();
                    //NLog.LogManager.KeepVariablesOnReload = true;
                    //NLog.LogManager.Configuration.Variables["logFilename"] = Assembly.GetEntryAssembly().GetName().Name;

                    //NLog.LogManager.ReconfigExistingLoggers();
                    //var logFilename = NLog.LogManager.Configuration.Variables["logFilename"];
                }
                switch (level)
                {
                    case Level.Fatal:
                        this.currentlogger?.Fatal(exc, message);
                        break;
                    case Level.Error:
                        this.currentlogger?.Error(exc, message);
                        break;
                    case Level.Debug:
                        this.currentlogger?.Debug(exc, message);
                        break;
                    case Level.Info:
                        this.currentlogger?.Info(exc, message);
                        break;
                    case Level.Trace:
                        this.currentlogger?.Trace(exc, message);
                        break;
                    case Level.Warning:
                        this.currentlogger?.Warn(exc, message);
                        break;
                }
            }
            catch (Exception e)
            {
                this.OnException?.Invoke(this, e);
            }
        }

        /// <summary>
        /// Eventhandler for exceptions
        /// </summary>
        public event EventHandler<Exception> OnException;

        public string CurrentFramework
        {
            get
            {
#if NET45
                return "NET45";
#elif NET451
                return "NET451";
#elif NET452
                return "NET452";
#elif NET46
                return "NET46";
#elif NET461
                return "NET461";
#elif NET462
                return "NET462";
#elif NET47
                return "NET47";
#elif NET471
                return "NET471";
#elif NET472
                return "NET472";
#elif NET48
                return "NET48";
#elif NETSTANDARD2_0
                return "NETSTANDARD2_0";
#else
                return "UNKNOWN";
#endif
            }
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
#endregion

    }
}
