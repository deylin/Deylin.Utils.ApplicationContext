// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseManager.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext.Configuration
{
    using System;

    public abstract class BaseManager<TData> : IManager<TData>
        where TData : IData
    {
        /// <summary>
        /// Abstract base class for configuration managers
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// 
        /// <summary>
        /// Boolean indicating whether the configuration data is loaded or not
        /// </summary>
        public abstract bool IsConfigurationLoaded { get; }

        /// <summary>
        /// Eventhandler for exceptions
        /// </summary>
        public event EventHandler<Exception> OnException;

        /// <summary>
        /// Abstract method for extracting the data from the configuration source
        /// </summary>
        /// <returns></returns>
        public abstract TData GetConfigurationData();

        protected virtual void ExceptionHandler(object sender, Exception exc)
        {
            this.OnException?.Invoke(sender, exc);
        }
    }
}
