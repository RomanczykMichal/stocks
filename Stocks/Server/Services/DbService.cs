
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stocks.Server.Data;
using Stocks.Server.Models;
using Stocks.Shared.DTOs;
using Stocks.Shared.DTOs.Response;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface IDbService
    {
        Task<Tuple<int, ManageFavoriteDTO>> ManageFavorites(AddingNewFavoriteDTO addingNewFavoriteDTO);
        Task<Tuple<int, string>> AddToFavoriteAsync(AddingNewFavoriteDTO addingNewFavoriteDTO);
        Task<bool> ChechIfFavoriteAsync(AddingNewFavoriteDTO newFavorite);
        Task<IsFavoriteDTO> ChechIfFavoriteAsync(string username, string tickerName);
        Task<bool> CheckIfDetailsExistsAsync(AddingNewFavoriteDTO newFavorite);
        Task<Tuple<int, string>> DeleteFromFavoritesAsync(AddingNewFavoriteDTO newFavorite);
        Task<UserFavorites> GetAllUserFavorites(string username);
        Task AddDetailsToDbAsync(AddingNewFavoriteDTO newFavorite);

        Task CacheTickerOHLC(IEnumerable<Api_OpenCloseResponseDTO> tickersOHLC, string tickerName);
        Task<IEnumerable<Api_OpenCloseResponseDTO>> GetCachedTickerOHLC(string tickerName);

    }

    public class DbService : IDbService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public DbService(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<Tuple<int, ManageFavoriteDTO>> ManageFavorites(AddingNewFavoriteDTO newFavorite)
        {
            if (!await CheckIfDetailsExistsAsync(newFavorite))
            {
                await AddDetailsToDbAsync(newFavorite);
                var addRes = await AddToFavoriteAsync(newFavorite);
                return new Tuple<int, ManageFavoriteDTO>(addRes.Item1, new ManageFavoriteDTO { Result = addRes.Item2 });
            }

            if (await ChechIfFavoriteAsync(newFavorite))
            {
                var delRes = await DeleteFromFavoritesAsync(newFavorite);
                return new Tuple<int, ManageFavoriteDTO>(delRes.Item1, new ManageFavoriteDTO { Result = delRes.Item2 });
            }

            var res = await AddToFavoriteAsync(newFavorite);
            return new Tuple<int, ManageFavoriteDTO>(res.Item1, new ManageFavoriteDTO { Result = res.Item2 });
        }

        public async Task<Tuple<int, string>> AddToFavoriteAsync(AddingNewFavoriteDTO newFavorite)
        {
            var applicationUser = await _context.Users.Where(e => e.UserName == newFavorite.Username).SingleOrDefaultAsync();

            if (applicationUser == null)
            {
                return new Tuple<int, string>(1, "Application user doesn't exists");
            }

            var tickerDetails = await _context.TickersDetails.Where(e => e.symbol == newFavorite.Details.symbol).SingleOrDefaultAsync();

            var tickersUsers = new TickersUsers()
            {
                IdApplicationUser = applicationUser.Id,
                IdTickersDetails = tickerDetails.IdTickersDetails,
                ApplicationUser = applicationUser,
                TickersDetails = tickerDetails
            };

            await _context.AddAsync(tickersUsers);
            await _context.SaveChangesAsync();
            return new Tuple<int, string>(0, "Successfuly added relation to database");
        }

        public async Task AddDetailsToDbAsync(AddingNewFavoriteDTO newFavorite)
        {
            var newTickersDetails = new TickersDetails()
            {
                logo = newFavorite.Details.logo,
                listdate = newFavorite.Details.listdate,
                cik = newFavorite.Details.cik,
                bloomberg = newFavorite.Details.bloomberg,
                lei = newFavorite.Details.lei,
                sic = newFavorite.Details.sic,
                country = newFavorite.Details.country,
                industry = newFavorite.Details.industry,
                sector = newFavorite.Details.sector,
                marketcap = newFavorite.Details.marketcap,
                phone = newFavorite.Details.phone,
                ceo = newFavorite.Details.ceo,
                url = newFavorite.Details.url,
                description = newFavorite.Details.description,
                exchange = newFavorite.Details.exchange,
                name = newFavorite.Details.name,
                symbol = newFavorite.Details.symbol,
                exchangeSymbol = newFavorite.Details.exchangeSymbol,
                hq_address = newFavorite.Details.hq_address,
                hq_state = newFavorite.Details.hq_state,
                hq_country = newFavorite.Details.hq_country,
                type = newFavorite.Details.type,
                updated = newFavorite.Details.updated,
                active = newFavorite.Details.active
            };

            await _context.AddAsync(newTickersDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChechIfFavoriteAsync(AddingNewFavoriteDTO newFavorite)
        {
            return await _context.TickersUsers.AnyAsync(e => e.ApplicationUser.UserName == newFavorite.Username && e.TickersDetails.symbol == newFavorite.Details.symbol);
        }
        public async Task<IsFavoriteDTO> ChechIfFavoriteAsync(string username, string tickerName)
        {
            return new IsFavoriteDTO { IsFavorite = await _context.TickersUsers.AnyAsync(e => e.ApplicationUser.UserName == username && e.TickersDetails.symbol == tickerName) };
        }
        public async Task<bool> CheckIfDetailsExistsAsync(AddingNewFavoriteDTO newFavorite)
        {
            return await _context.TickersDetails.AnyAsync(e => e.symbol == newFavorite.Details.symbol);
        }

        public async Task<Tuple<int, string>> DeleteFromFavoritesAsync(AddingNewFavoriteDTO newFavorite)
        {
            var entity = await _context.TickersUsers.Where(e => e.ApplicationUser.UserName == newFavorite.Username && e.TickersDetails.symbol == newFavorite.Details.symbol).SingleAsync();
            _context.TickersUsers.Remove(entity);
            await _context.SaveChangesAsync();
            return new Tuple<int, string>(0, "Successfuly deleted from database");
        }

        public async Task<UserFavorites> GetAllUserFavorites(string username)
        {
            var userFavoritesList = await _context.TickersUsers.Where(e => e.ApplicationUser.UserName == username).Select(e => e.TickersDetails).ToListAsync();
            List<TickerDetailsResponse> tickerDetailsList = new List<TickerDetailsResponse>();
            foreach (var details in userFavoritesList)
            {
                tickerDetailsList.Add(new TickerDetailsResponse()
                {
                    logo = details.logo,
                    listdate = details.listdate,
                    cik = details.cik,
                    bloomberg = details.bloomberg,
                    lei = details.lei,
                    sic = details.sic,
                    country = details.country,
                    industry = details.industry,
                    sector = details.sector,
                    marketcap = details.marketcap,
                    phone = details.phone,
                    ceo = details.ceo,
                    url = details.url,
                    description = details.description,
                    exchange = details.exchange,
                    name = details.name,
                    symbol = details.symbol,
                    exchangeSymbol = details.exchangeSymbol,
                    hq_address = details.hq_address,
                    hq_state = details.hq_state,
                    hq_country = details.hq_country,
                    type = details.type,
                    updated = details.updated,
                    active = details.active
                });
            }

            return new UserFavorites() { Username = username, TickersDetailsList = tickerDetailsList };
        }

        public async Task CacheTickerOHLC(IEnumerable<Api_OpenCloseResponseDTO> tickersOHLC, string tickerName)
        {
            foreach (var tickerOHLC in tickersOHLC)
            {
                var tmp = new TickerOHLC
                {
                    TickerName = tickerName,
                    C = tickerOHLC.C,
                    H = tickerOHLC.H,
                    L = tickerOHLC.L,
                    N = tickerOHLC.N,
                    O = tickerOHLC.O,
                    T = tickerOHLC.T,
                    V = tickerOHLC.V,
                    Vw = tickerOHLC.Vw,
                };

                if (!await _context.TickerOHLC.AnyAsync(e => e.TickerName == tickerName && e.T != tmp.T))
                    await _context.TickerOHLC.AddAsync(tmp);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Api_OpenCloseResponseDTO>> GetCachedTickerOHLC(string tickerName)
        {
            var tickerList = new List<Api_OpenCloseResponseDTO>();

            var tickerCached = await _context.TickerOHLC.Where(e => e.TickerName == tickerName).ToListAsync();

            foreach (var cached in tickerCached)
            {
                tickerList.Add(new Api_OpenCloseResponseDTO
                {
                    C = cached.C,
                    H = cached.H,
                    L = cached.L,
                    N = cached.N,
                    O = cached.O,
                    T = cached.T,
                    V = cached.V,
                    Vw = cached.Vw
                });
            }

            return tickerList;
        }
    }
}
