using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace SWGalacticArchives.Components.Interactive
{
    partial class EntityModal
    {
        [Parameter]
        [NotNull]
        public Modal? BackdropModal { get; set; }

        public void ToggleState()
        {
            BackdropModal?.Toggle();
        }
    }
}
