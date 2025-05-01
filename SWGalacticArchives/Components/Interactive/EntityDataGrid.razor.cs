using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Components.Interactive
{
    partial class EntityDataGrid<T> : ComponentBase
    {
        [Parameter]
        public string DataGridName { get; set; }

        [Parameter]
        public DataGridInfo DataGridInfo { get; set; } = new();

        [Parameter]
        public IEnumerable<Result<T>> AllItems { get; set; } = new List<Result<T>>();

        [Parameter]
        public string ViewDetails { get; set; }


        [Parameter]
        public EventCallback<string> NextGridItems { get; set; }


        [Parameter]
        public EventCallback<string> PreviousGridItems { get; set; }

        public Root<T> ContentRoot { get; set; }

        private void GetNextItems()
        {
            NextGridItems.InvokeAsync(DataGridInfo.next);
        }

        private void GetPreviousItems()
        {
            PreviousGridItems.InvokeAsync(DataGridInfo.previous);
        }

        private void GoToViewDetails(string Uid)
        {
            Navigation.NavigateTo($"{ViewDetails}/{Uid}");
        }
    }
}
