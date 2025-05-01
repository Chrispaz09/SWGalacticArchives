using Microsoft.AspNetCore.Components;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Implementations;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Components.Pages
{
    partial class VehiclesHome : ComponentBase
    {
        [Inject]
        public IVehicleService VehicleService { get; set; }

        [Parameter]
        public Vehicle SearchedVehicle { get; set; } = new();

        [Parameter]
        public IEnumerable<Result<Vehicle>> AllVehicles { get; set; } = new List<Result<Vehicle>>();

        private DataGridInfo GridInfo { get; set; } = new();

        private bool recordDoesNotExist = false;

        protected async override Task OnInitializedAsync()
        {
            GridInfo = await VehicleService.GetDataGridInfoAsync();

            AllVehicles = await VehicleService.GetAllResultsAsync();
        }

        private async Task OnSearch(string id)
        {
            if (AllVehicles.Any(p => p.Uid == id))
            {
                SearchedVehicle = await VehicleService.GetAsync(id);
            }
            else
            {
                recordDoesNotExist = true;
            }
        }

        private async Task GetItems(string route)
        {
            AllVehicles = await VehicleService.GetAllResultsAsync(route);

            GridInfo = await VehicleService.GetDataGridInfoAsync(route);
        }
    }
}
