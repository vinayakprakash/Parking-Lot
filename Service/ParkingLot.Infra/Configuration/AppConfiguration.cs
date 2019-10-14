using System.IO;
using Microsoft.Extensions.Configuration;

namespace ParkingLot.Infra.Configuration
{
    public class AppConfiguration: IAppConfiguration
    {
        public string GetConnectionString()
        {
            return RetrieveFromAppConfig();
        }

        private static string RetrieveFromAppConfig()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            return root.GetConnectionString("DataConnection");
        }
    }
}