using Microsoft.AspNetCore.Components;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Components.Pages
{
    partial class PlanetDetails : ComponentBase
    {
        [Inject]
        public IPlanetService PlanetService { get; set; }

        [Parameter]
        public string Uid { get; set; }

        private Planet Planet { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Planet = await PlanetService.GetAsync(Uid);
        }
    }
}
