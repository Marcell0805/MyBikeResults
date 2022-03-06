using BikeResults.Web.ApiStructs;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using MyBikeResults.Domain.Settings;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BikeResults.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            AppSettings appSettings = new AppSettings();
            builder.Configuration.GetSection("AppSettings").Bind(appSettings);
            builder.Services.AddSingleton(appSettings);
            //builder.Services.AddIgniteUIBlazor();
            builder.Services.AddMudServices();

            #region Setting of ApiStructs

            var apiUrl = builder.Configuration.GetSection("AppSettings")["endpointRest"];

            builder.Services.AddRefitClient<IBikeApi>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri($"{appSettings.ApiBaseUrl}api"); });

            #endregion
            await builder.Build().RunAsync();
        }
    }
}
