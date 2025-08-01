using Microsoft.Extensions.Configuration;
using System.IO;

namespace CSharpSeleniumFramework.Utils
{
    public class ConfigReader
    {
        public IConfiguration Configuration { get; }
        public ConfigReader()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public string Get(string key)
        {
            return Configuration[key];
        }
    }
}