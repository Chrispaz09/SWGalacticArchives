using Microsoft.AspNetCore.Components;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Components.Pages
{
    partial class VehicleDetails : ComponentBase
    {
        [Inject]
        public IVehicleService VehicleService { get; set; }

        [Parameter]
        public string Uid { get; set; }

        private Vehicle Vehicle { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Vehicle = await VehicleService.GetAsync(Uid);
        }
    }
}
