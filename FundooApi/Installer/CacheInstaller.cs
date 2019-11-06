using FundooApi.Cache;
using FundooApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApi.Installer
{
    public class CacheInstaller:IInstaller
    {
            public void InstallServices(IServiceCollection services, IConfiguration configuration)
            {
                var redisCacheSettings = new RedisCacheSettings();
                configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
                services.AddSingleton(redisCacheSettings);

                if (!redisCacheSettings.Enabled)
                {
                    return;
                }

                services.AddDistributedRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
                services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            }
        
    }
}
