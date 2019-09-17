// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Deylin">
//   (c) 2019, Deylin
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Deylin.Utils.ApplicationContext.Configuration
{
    using System.IO;
    using System.Reflection;

    public class Settings<TData>
        where TData : IData
    {

        private IManager<TData> manager = default(IManager<TData>);

        public Settings(string name, Assembly currentassembly, string configfile)
        {
            this.Name = name.ToUpper();
            this.ConfigFile = Path.Combine(Path.GetDirectoryName(currentassembly.Location), configfile);
        }

        public Settings(string name, Assembly currentassembly, string configfile, IManager<TData> manager)
        {
            this.Name = ($"{currentassembly.GetName().Name}.{name}").ToUpper();
            this.ConfigFile = Path.Combine(Path.GetDirectoryName(currentassembly.Location), configfile);
        }

        public string Name { get; private set; }

        public string ConfigFile { get; private set; }

        public IManager<TData> Manager
        {
            get
            {
                if (this.manager == null)
                {
                    var jm = new JsonManager<TData>(ConfigFile);
                    return jm;
                }
                else
                {
                    return this.manager;
                }
            }
        }

    }
}
