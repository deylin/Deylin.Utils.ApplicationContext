// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManager.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext.Configuration
{
    /// <summary>
    /// Interface for configuration managers
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IManager<out TData>
        where TData : IData
    {
        /// <summary>
        /// Method for getting the data from the configuration source
        /// </summary>
        /// <returns></returns>
        TData GetConfigurationData();

        /// <summary>
        /// Property indicating whether the configuration has loaded or not
        /// </summary>
        bool IsConfigurationLoaded { get; }
    }
}
