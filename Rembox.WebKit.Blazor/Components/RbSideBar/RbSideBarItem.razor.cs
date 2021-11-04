using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbSideBarItem: ComponentBase
    {
        [Parameter] public string Title { get; set; } = string.Empty;
        
        [Parameter] public string? Icon { get; set; } = String.Empty;
        
        [Parameter] public bool IsRoot { get; set; } = true;

        [CascadingParameter]
        public RbSideBarContext Context { get; set; } = new();
    }
}