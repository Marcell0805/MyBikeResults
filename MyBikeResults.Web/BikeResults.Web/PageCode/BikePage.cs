using BikeResults.Web.ApiStructs;
using Microsoft.AspNetCore.Components;
using MyBikeResults.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;

namespace BikeResults.Web.Pages
{
    public partial class BikePage
    {
        #region Injections
        [Inject]
        private IBikeApi BikeApi { get; set; }
        
        public List<Bike> bikeCollection { get; set; } = new();
        public IEnumerable<Bike> bikeResults { get; set; }

        public Bike bike = new();
        #endregion
        #region
        private string _searchString;
        private string _btnText="CHECKOUT";
        private bool _sortNameByLength;
        #endregion
        protected override async Task OnInitializedAsync()
        {
            bikeResults = await BikeApi.GetAll();
            bikeCollection = bikeResults.ToList();
        }
        private Func<Bike, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Make.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Model.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (x.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        private Func<Bike, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Model.Length;
            else
                return x.Make;
        };
    }
}
