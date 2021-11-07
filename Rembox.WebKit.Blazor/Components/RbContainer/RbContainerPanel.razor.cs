using Microsoft.AspNetCore.Components;

namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbContainerPanel: ComponentBase
    {
        [Parameter] public RbContainerPanelSize Size { get; set; } = RbContainerPanelSize.Full;
        
        [Parameter] public string Header { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }

    public enum RbContainerPanelSize
    {
        Quarter,
        Third,
        Half,
        ThreeQuarters,
        Full,
    }
}