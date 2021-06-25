using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Article;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.Repositories
{
    public interface IStockRepo
    {
        string GetUrl();
        Task<List<Api_TickersResponseDTO>> GetNewTickersAsync(string tickerName);
        Task<List<Api_OpenCloseResponseDTO>> GetTickerDataAsync(string tickerName, DateTime dateFrom);
        Task<Api_TickerResponseDetailsDTO> GetTickerDetailsAsync(string tickerName);
        Task<ManageFavoriteDTO> ManageFavoritesAsync(Api_TickerResponseDetailsDTO details, string username);
        Task<IsFavoriteDTO> IsFavoriteAsync(Api_TickerResponseDetailsDTO details, string username);
        Task<UserFavorites> GetUserFavoritesAsync(string username);
        Task<Api_ArticleRootDTO> GetRecentArticlesAsync(string tickerName);
    }
}
