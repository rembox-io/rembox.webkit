using Microsoft.AspNetCore.Components;

namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbContainer: ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}