using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBikeResults.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeResults.Web.Pages
{
    public partial class BikeResultsJS
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;
        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/jsExamples.js");
        }
        public async Task ShowAlertWindow()
        {
            //await _jsModule.InvokeVoidAsync("showAlert", "JS function called from .NET");
            await _jsModule.InvokeVoidAsync("readJsonB");
        }
        public async Task ReadData()
        {
            //await _jsModule.InvokeVoidAsync("readJson", "JS function called from .NET");
            var d=await _jsModule.InvokeAsync<object>("readJson", "JS function called from .NET");
            var e = new Bike();
            CheckData(e);
        }
        public void CheckData(Bike d)
        {
            var values = d;
        }
        [JSInvokable]
        public static Task<int[]> ReturnArrayAsync()
        {
            return Task.FromResult(new int[] { 1, 2, 3 });
        }
    }
}
