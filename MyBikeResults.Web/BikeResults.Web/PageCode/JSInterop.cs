using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBikeResults.Domain.Entities;
using Newtonsoft.Json;

namespace BikeResults.Web.Pages
{
    public partial class JSInterop
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public HttpClient client { get; set; }
        private IJSObjectReference _jsModule;
        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/jsExamples.js");
        }
        public async Task ReadData()
        {
            await _jsModule.InvokeVoidAsync("JSMethod");
        }
        protected static string message { get; set; }
        public static List<Bike> bikes = new List<Bike>();
        [JSInvokable]
        public static void CSCallBackMethod()
        {
            try
            {
                var a = Directory.GetCurrentDirectory();
                string bikeJson = File.ReadAllText(@"Seeds" + Path.DirectorySeparatorChar + "bikes_response.json");
                bikes = JsonConvert.DeserializeObject<List<Bike>>(bikeJson);
                message = "C# Method invoked";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            

        }


    }
}