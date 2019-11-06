﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApi.Services
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
