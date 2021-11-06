using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components
{
    public partial class RbNavBar : ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}