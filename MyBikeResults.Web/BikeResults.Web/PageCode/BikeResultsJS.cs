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
        public async Task ReadData()
        {
            await _jsModule.InvokeVoidAsync("readJson", "JS function called from .NET");
        }
    }
}
