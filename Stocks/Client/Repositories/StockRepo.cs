using Stocks.Client.HttpHelpers;
using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Article;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Client.Repositories
{
    public class StockRepo : IStockRepo
    {
        private readonly IHttpService _httpService;
        private string url { get; set; } = "api/stocks";

        public StockRepo(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Api_TickersResponseDTO>> GetNewTickersAsync(string tickerName)
        {
            return (await _httpService.Get<List<Api_TickersResponseDTO>>($"{url}/tickers/{tickerName}")).Response;
        }

        public string GetUrl()
        {
            return url;
        }

        public async Task<List<Api_OpenCloseResponseDTO>> GetTickerDataAsync(string tickerName, DateTime dateFrom)
        {
            return (await _httpService.Get<List<Api_OpenCloseResponseDTO>>($"{url}/ticker/aggregates/{tickerName}/{dateFrom}")).Response;
        }

        public async Task<Api_TickerResponseDetailsDTO> GetTickerDetailsAsync(string tickerName)
        {
            return (await _httpService.Get<Api_TickerResponseDetailsDTO>($"{url}/ticker/{tickerName}")).Response;
        }

        public async Task<ManageFavoriteDTO> ManageFavoritesAsync(Api_TickerResponseDetailsDTO details, string username)
        {
            var resp = await _httpService.Post<AddingNewFavoriteDTO, ManageFavoriteDTO>($"{url}/user/favorites", new AddingNewFavoriteDTO { Details = details, Username = username });
            if (!resp.Success)
            {
                throw new ApplicationException(await resp.GetBody());
            }
            return resp.Response;
        }

        public async Task<IsFavoriteDTO> IsFavoriteAsync(Api_TickerResponseDetailsDTO details, string username)
        {
            return (await _httpService.Get<IsFavoriteDTO>($"{url}/user/favorites/{username}/{details.symbol}")).Response;
        }

        public async Task<UserFavorites> GetUserFavoritesAsync(string username)
        {
            return (await _httpService.Get<UserFavorites>($"{url}/user/favorites/{username}")).Response;
        }

        public async Task<Api_ArticleRootDTO> GetRecentArticlesAsync(string tickerName)
        {
            return (await _httpService.Get<Api_ArticleRootDTO>($"{url}/articles/{tickerName}")).Response;
        }
    }
}
