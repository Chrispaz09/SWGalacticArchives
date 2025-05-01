using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace SWGalacticArchives.Components.Interactive
{
    partial class EntityCard
    {
        [Parameter]
        public string Uid { get; set; }

        [Parameter]
        public string HeaderText { get; set; }

        [Parameter]
        public string BodyText { get; set; }

        [Parameter]
        public string ButtonText { get; set; }

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public string FooterText { get; set; }

        [Parameter]
        public bool IsCollapsible { get; set; }

        [Parameter]
        public string Route { get; set; }

        private void NavigateTo()
        {
            Navigation.NavigateTo($"{Route}/{Uid}");
        }
    }
}
