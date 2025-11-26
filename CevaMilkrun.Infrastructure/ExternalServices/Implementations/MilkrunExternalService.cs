using CevaMilkrun.Domain.Interfaces;
using CevaMilkrun.Infrastructure.ExternalServices.Refit;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace CevaMilkrun.Infrastructure.ExternalServices.Implementations
{
    public class MilkrunExternalService : IMilkrunExternalService
    {
        private readonly ICevaMilkrunApi _cevaApi;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;

        public MilkrunExternalService(ICevaMilkrunApi cevaApi, IDistributedCache cache, IConfiguration configuration)
        {
            _cevaApi = cevaApi;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<string> GetRawJsonAsync(string phoneNumber)
        {
            var cacheKey = $"milkrun:{phoneNumber}";
            var cachedJson = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedJson))
            {
                return cachedJson;
            }

            try
            {
                var cookie = _configuration["CevaApi:Cookie"];
                var apiResponse = await _cevaApi.GetRawMilkrunDataAsync(phoneNumber, cookie!);

                if (!string.IsNullOrEmpty(apiResponse))
                {
                    var cacheOptions = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    };
                    await _cache.SetStringAsync(cacheKey, apiResponse, cacheOptions);
                }

                return apiResponse;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}