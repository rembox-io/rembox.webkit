using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbBadge: ComponentBase
    {
        [Parameter]public int? Size { get; set; }
        
        [Parameter] public RbSeverity Color { get; set; } = RbSeverity.Secondary;
        
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }

    public enum RbSeverity
    {
        Secondary,
        Primary,
        Info,
        Success,
        Warning,
        Danger
    }
}