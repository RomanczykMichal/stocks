using Stocks.Client.Models.DTOs;
using Stocks.Client.Shared;
using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Article;
using Stocks.Shared.DTOs.Tickers;
using Syncfusion.Blazor.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.Pages
{
    public partial class StocksShow
    {
        public string tickerName { get; set; }
        public string tickerSearch { get; set; }
        public string username { get; set; }
        public bool favorite { get; set; }
        public List<ChartDataDTO> tickerData { get; set; }
        public List<Api_TickersResponseDTO> tickers { get; set; }
        public List<Api_ArticleDetailsDTO> articles { get; set; }
        public Api_TickerResponseDetailsDTO tickerDetails { get; set; }
        public ChartInfo chartInfoChild { get; set; }


        public async Task FindNewTickersAsync()
        {
            tickers = (await iStockRepo.GetNewTickersAsync(tickerSearch));
        }

        public void KeyPressed(Microsoft.AspNetCore.Components.ChangeEventArgs args)
        {
            if (args.Value == null)
                tickerSearch = "";
            else
                tickerSearch = args.Value.ToString();
        }

        public async Task UpdateTickerData()
        {
            await UpdateTickerDetails();

            if (tickerData.Count > 0)
                tickerData.RemoveAll(e => true);
            var tickerDataResponse = (await iStockRepo.GetTickerDataAsync(tickerName, new DateTime(1970, 1, 1)));
            if (tickerDataResponse != null)
                foreach (var indiv in tickerDataResponse)
                {
                    tickerData.Add(new ChartDataDTO
                    {
                        V = indiv.V,
                        Vw = indiv.Vw,
                        O = indiv.O,
                        C = indiv.C,
                        H = indiv.H,
                        L = indiv.L,
                        T = indiv.T,
                        N = indiv.N,
                    });
                }

            if (chartInfoChild.Chart != null)
                chartInfoChild.UpdateChart();
        }

        public async Task UpdateTickerDetails()
        {
            if (tickerName != null)
            {
                var t = await Task.WhenAny(iStockRepo.GetTickerDetailsAsync(tickerName));
                tickerDetails = await t;
                if (tickerDetails != null)
                    await UpdateFavoriteState();
                await GetRecentArticles();
            }
        }

        public async Task UpdateFavoriteState()
        {
            favorite = (await iStockRepo.IsFavoriteAsync(tickerDetails, username)).IsFavorite;
        }

        public async Task GetRecentArticles()
        {
            articles = (await iStockRepo.GetRecentArticlesAsync(tickerName)).results;
        }

        public async Task AddOrRemoveFavorite()
        {
            if (tickerDetails != null)
            {
                await iStockRepo.ManageFavoritesAsync(tickerDetails, username);
                await UpdateFavoriteState();
            }
        }
    }
}
