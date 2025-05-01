using Microsoft.AspNetCore.Components;

namespace SWGalacticArchives.Components.Interactive
{
    partial class EntitySearchBox<T> : ComponentBase
    {
        [Parameter]
        public string? Id { get; set; } 

        [Parameter]
        public string HeaderText { get; set; }

        [Parameter]
        public string FooterText { get; set; }

        [Parameter]
        public string Route { get; set; }

        [Parameter]
        public T SearchedItem { get; set; }

        [Parameter]
        public List<T> AllItems { get; set; }

        [Parameter]
        public EventCallback<string> Search { get; set; }

        [Parameter]
        public bool ItemDoesNotExist { get; set; }

        public async void OnSearch()
        {
            await Search.InvokeAsync(Id);

            StateHasChanged();
        }
    }
}
