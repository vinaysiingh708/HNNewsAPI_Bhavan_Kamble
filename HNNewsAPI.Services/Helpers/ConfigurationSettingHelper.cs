using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNNewsAPI.Services.Helpers
{
    public class ConfigurationSettingHelper
    {
        public ConfigurationSettingHelper()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            NewsAPIBaseEndpoint = config.GetValue<string>("NewsSettings:ApiBaseEndPoint");
        }

        public string NewsAPIBaseEndpoint { get; set; }
    }
}
