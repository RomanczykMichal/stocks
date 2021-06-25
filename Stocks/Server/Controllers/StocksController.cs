using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stocks.Server.Services;
using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {

        private readonly IDbService _db;
        private readonly IApiService _ap;
        private readonly ILogger<StocksController> _logger;

        public StocksController(IDbService db, IApiService ap, ILogger<StocksController> logger)
        {
            _db = db;
            _ap = ap;
            _logger = logger;
        }

        [HttpGet("tickers/{tickerName}")]
        public async Task<IActionResult> GetAllTickers(string tickerName = "")
        {
            var apiResponse = await _ap.GetTickersAsync(tickerName);
            if (apiResponse == null)
                return NotFound();
            return Ok(apiResponse);
        }

        [HttpGet("ticker/{tickerName}")]
        public async Task<IActionResult> GetTickerDetails(string tickerName)
        {
            var apiResponse = await _ap.GetTickerDetailsAsync(tickerName);
            if (apiResponse == null)
                return NotFound();
            return Ok(apiResponse);
        }

        [HttpGet("ticker/aggregates/{tickerName}/{dateFrom}")]
        public async Task<IActionResult> GetTickerAggregates(string tickerName, DateTime dateFrom)
        {
            var apiResponse = await _ap.GetTickerAggregatesAsync(tickerName, dateFrom);
            if (apiResponse == null)
            {
                var dbResponse = await _db.GetCachedTickerOHLC(tickerName);
                if (dbResponse != null)
                    return Ok(dbResponse);
                return NotFound();
            } else
            {
                await _db.CacheTickerOHLC(apiResponse, tickerName);
            }
            return Ok(apiResponse);
        }

        [HttpPost("user/favorites")]
        public async Task<IActionResult> ManageFarovites(AddingNewFavoriteDTO newFavorites)
        {
            var dbResponse = await _db.ManageFavorites(newFavorites);

            if (dbResponse.Item1 == 0)
                return Ok(dbResponse.Item2);
            if (dbResponse.Item1 == 1)
                return NotFound(dbResponse.Item2);

            return BadRequest(dbResponse.Item2);
        }

        [HttpGet("user/favorites/{username}/{tickerName}")]
        public async Task<IActionResult> IsFavorite(string username, string tickerName)
        {
            var dbResponse = await _db.ChechIfFavoriteAsync(username, tickerName);
            return Ok(dbResponse);
        }

        [HttpGet("user/favorites/{username}")]
        public async Task<IActionResult> GetAllFavorites(string username)
        {
            return Ok(await _db.GetAllUserFavorites(username));
        }
        
        [HttpGet("articles/{tickerName}")]
        public async Task<IActionResult> GetRecentArticles(string tickerName)
        {
            var apiResult = await _ap.GetRecentArticlesAsync(tickerName);
            if (apiResult == null)
                return NotFound("Not found any articles");
            return Ok(apiResult);
        }
    }
}
