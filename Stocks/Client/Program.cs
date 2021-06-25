using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Client.HttpHelpers;
using Stocks.Client.Repositories;
using Syncfusion.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stocks.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDU3NzQzQDMxMzkyZTMxMmUzMFlTZ1RrRCt3WllURWh6RGlDa1lNT2ZXRWdtNXZmbkpiZlUwOVAwTXNrUFE9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("Stocks.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Stocks.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IStockRepo, StockRepo>();

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
