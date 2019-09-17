// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IData.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Deylin.Utils.ApplicationContext.Configuration
{
    using System;

    /// <summary>
    /// Interface for the data structure used for configuration
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Gets the Guid
        /// </summary>
        Guid GUID { get; }

        /// <summary>
        /// Gets the application name
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// Gets the environment type
        /// </summary>
        EnvironmentTypes Environment { get; }

        /// <summary>
        /// Gets the release
        /// </summary>
        string Release { get; }

        /// <summary>
        /// Gets the version
        /// </summary>
        Version Version { get; }
    }
}
