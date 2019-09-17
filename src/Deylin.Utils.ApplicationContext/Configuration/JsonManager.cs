// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonManager.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Reflection;


    public sealed class JsonManager<TData> : BaseManager<TData>
        where TData : IData
    {
        private string filepath;
        private bool isConfigurationLoaded;

        /// <summary>
        /// Constructor for the json configuration manager
        /// </summary>
        /// <param name="filepath">the filename</param>
        public JsonManager(string filepath)
        {
            this.filepath = filepath;
            this.isConfigurationLoaded = false;
        }

        /// <summary>
        /// Boolean indicating whether the configuration was loaded or not
        /// </summary>
        public override bool IsConfigurationLoaded => this.isConfigurationLoaded;

        /// <summary>
        /// Gets the configuration data from the file
        /// </summary>
        /// <returns></returns>
        public override TData GetConfigurationData()
        {
            try
            {
                if (!Path.IsPathRooted(filepath))
                {
                    if (File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filepath)))
                    {
                        filepath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filepath);
                    }
                    else
                    {
                        if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filepath)))
                        {
                            filepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filepath);
                        }
                    }
                }



                if (File.Exists(filepath))
                {
                    var filestring = File.ReadAllText(filepath);
                    var data = JsonConvert.DeserializeObject<TData>(filestring);
                    //var list = data.GetProperties();
                    this.isConfigurationLoaded = true;
                    return data;
                }
                else
                {
                    throw new FileNotFoundException($"Could not find file '{filepath}'");
                }
            }
            catch (Exception exc)
            {
                base.ExceptionHandler(this, exc);
                return default(TData);
            }
        }
    }
}
