﻿using FootballMatches.Common;
using Microsoft.Extensions.Caching.Memory;

namespace FootballMatches.Services
{
    public class FootballDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseApi;
        private readonly IMemoryCache _cache;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(2);

        public FootballDataService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
            _apiKey = configuration["ApiKey"];
            _baseApi = configuration["BaseUrl"];
        }

        /// <summary>
        /// Method request the matches based on the type from remote API
        /// </summary>
        /// <param name="matchType"></param>
        /// <returns></returns>
        public async Task<string> GetMatchesAsync(MatchTypes matchType)
        {
            if(_cache.TryGetValue(matchType, out string cachedData))
            {
                return cachedData;
            }

            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _apiKey);
            string status = matchType.ToString();

            var response = await _httpClient.GetAsync($"{_baseApi}/matches?status={status}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            _cache.Set(matchType, result, CacheDuration);

            return result;
        }
    }
}
