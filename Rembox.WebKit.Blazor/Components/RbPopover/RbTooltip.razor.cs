using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbTooltip: ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        
        [Parameter] public string Text { get; set; }
        
        [Parameter] public RbPopoverPosition Position { get; set; }
    }
}