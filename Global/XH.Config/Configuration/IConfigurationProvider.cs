using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Configurations
{
    public interface IConfigurationProvider
    {
        T GetConfiguration<T>() where T : IConfiguration, new();

        void SaveConfiguration<T>(T configuration) where T : IConfiguration, new();
    }
}
