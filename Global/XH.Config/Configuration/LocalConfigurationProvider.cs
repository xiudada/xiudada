using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XH.Infrastructure.Caching;
using XH.Infrastructure.Extensions;

namespace XH.Configurations
{
    public class LocalConfigurationProvider : IConfigurationProvider
    {
        private readonly string _filePath;
        private readonly ICacheManager _cacheManager;

        public LocalConfigurationProvider(ICacheManager cacheManager, string filePath = "\\configs")
        {
            _cacheManager = cacheManager;
            _filePath = AppDomain.CurrentDomain.BaseDirectory + filePath;

            if (Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }
        }

        public T GetConfiguration<T>() where T : IConfiguration, new()
        {
            string cacheKey = typeof(T).FullName;
            return _cacheManager.Get<T>(cacheKey, () =>
            {
                string content = GetConfigurationContent<T>();
                if (!String.IsNullOrEmpty(content))
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }

                return new T();
            });
        }

        public void SaveConfiguration<T>(T configuration) where T : IConfiguration, new()
        {
            string filePath = $"{_filePath}\\{typeof(T).Name}.json";
            string content = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            File.WriteAllText(filePath, content);

            string cacheKey = typeof(T).FullName;
            _cacheManager.Set(cacheKey, configuration);
        }

        private string GetConfigurationContent<T>()
        {
            string filePath = $"{_filePath}\\{typeof(T).Name}.json";
            string content = String.Empty;

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
            }

            return content;
        }
    }
}
