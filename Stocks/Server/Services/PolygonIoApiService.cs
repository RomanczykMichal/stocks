using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Article;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface IApiService
    {
        Task<IEnumerable<Api_TickersResponseDTO>> GetTickersAsync(string tickerName);
        Task<Api_TickerResponseDetailsDTO> GetTickerDetailsAsync(string tickerName);
        Task<IEnumerable<Api_OpenCloseResponseDTO>> GetTickerAggregatesAsync(string tickerName, DateTime dateFrom);
        Task<Api_ArticleRootDTO> GetRecentArticlesAsync(string tickerName);
    }

    public class PolygonIoApiService : IApiService
    {
        private string ApiKey { get; set; }
        private readonly IConfiguration _config;

        public PolygonIoApiService(IConfiguration config)
        {
            _config = config;
            ApiKey = _config.GetSection("ApiKeys:PolygonIO").Value;
        }

        public async Task<IEnumerable<Api_TickersResponseDTO>> GetTickersAsync(string tickerName)
        {
            string search = (tickerName.Length == 0 ? "" : $"search={tickerName}");
            var request = (HttpWebRequest)WebRequest.Create($"https://api.polygon.io/v3/reference/tickers?{search}&active=true&sort=ticker&order=asc&limit=10&apiKey={ApiKey}");
            request.Method = "GET";
            request.ContentType = "application/json";

            var responseString = "";
            using (var response1 = await request.GetResponseAsync())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var responseJson = JsonConvert.DeserializeObject<Api_TickersResponseRootDTO>(responseString);
            return responseJson.Results;
        }

        public async Task<Api_TickerResponseDetailsDTO> GetTickerDetailsAsync(string tickerName)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://api.polygon.io/v1/meta/symbols/{tickerName}/company?&apiKey={ApiKey}");
            request.Method = "GET";
            request.ContentType = "application/json";

            var responseString = "";
            try
            {
                using (var response1 = await request.GetResponseAsync())
                {
                    using (var reader = new StreamReader(response1.GetResponseStream()))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }
            } catch (Exception)
            {
                return null;
            }

            var responseJson = JsonConvert.DeserializeObject<Api_TickerResponseDetailsDTO>(responseString);
            return responseJson;
        }

        public async Task<IEnumerable<Api_OpenCloseResponseDTO>> GetTickerAggregatesAsync(string tickerName, DateTime dateFrom)
        {
            var dateFromFormated = dateFrom.ToString("yyyy'-'MM'-'dd");
            var dateToFormated = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            var request = (HttpWebRequest)WebRequest.Create($"https://api.polygon.io/v2/aggs/ticker/{tickerName}/range/1/day/{dateFromFormated}/{dateToFormated}?sort=asc&limit=5000&apiKey={ApiKey}");
            request.Method = "GET";
            request.ContentType = "application/json";

            var responseString = "";
            using (var response1 = await request.GetResponseAsync())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var responseJson = JsonConvert.DeserializeObject<Api_OpenCloseResponseRootDTO>(responseString);
            return responseJson.results;
        }

        async public Task<Api_ArticleRootDTO> GetRecentArticlesAsync(string tickerName)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://api.polygon.io/v2/reference/news?limit=5&order=descending&sort=published_utc&ticker={tickerName}&apiKey={ApiKey}");
            request.Method = "GET";
            request.ContentType = "application/json";

            var responseString = "";
            using (var response1 = await request.GetResponseAsync())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var responseJson = JsonConvert.DeserializeObject<Api_ArticleRootDTO>(responseString);
            return responseJson;
        }
    }
}