using Microsoft.AspNetCore.Components;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Components.Pages
{
    partial class PlanetsHome : ComponentBase
    {
        [Inject]
        public IPlanetService PlanetService { get; set; }

        [Parameter]
        public Planet SearchedPlanet { get; set; } = new();

        [Parameter]
        public IEnumerable<Result<Planet>> AllPlanets { get; set; } = new List<Result<Planet>>();

        private DataGridInfo GridInfo { get; set; } = new();

        private bool recordDoesNotExist;

        protected async override Task OnInitializedAsync()
        {
            GridInfo = await PlanetService.GetDataGridInfoAsync();

            AllPlanets = await PlanetService.GetAllResultsAsync();
        }

        private async Task OnSearch(string id)
        {
            if (AllPlanets.Any(p => p.Uid == id))
            {
                SearchedPlanet = await PlanetService.GetAsync(id);
                
                recordDoesNotExist = false;
            }
            else
            {
                recordDoesNotExist = true;
            }
        }

        private async Task GetItems(string route)
        {
            AllPlanets = await PlanetService.GetAllResultsAsync(route);

            GridInfo = await PlanetService.GetDataGridInfoAsync(route);
        }
    }
}
