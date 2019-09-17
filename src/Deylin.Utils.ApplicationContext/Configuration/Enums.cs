// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext.Configuration
{
    /// <summary>
    /// Environment types used in <see cref="IData"/>
    /// </summary>
    public enum EnvironmentTypes
    {
        /// <summary>
        /// Development environment
        /// </summary>
        Development,

        /// <summary>
        /// Testing environment
        /// </summary>
        Test,

        /// <summary>
        /// Acceptance environment
        /// </summary>
        Acceptance,

        /// <summary>
        /// Production environment
        /// </summary>
        Production,

        /// <summary>
        /// Education environment
        /// </summary>
        Education,

        /// <summary>
        /// Backup environment
        /// </summary>
        Backup
    }
}
