using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbSideBarItem: ComponentBase
    {
        [Parameter] public string Title { get; set; } = string.Empty;
        
        [Parameter] public string? Icon { get; set; } = String.Empty;
        
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string NavigateUrl { get; set; } = string.Empty;

        public bool IsExpanded { get; set; }
        
        [CascadingParameter] public RbSideBarContext? Context { get; set; }

        private void OnItemClicked()
        {
            Console.WriteLine($"item clicked {NavigateUrl}");
            if (Context != null)
                Context.ExpandedItem = NavigateUrl;
        }

        protected override void OnInitialized()
        {
            Context!.PropertyChanged += (_, _) =>
            {
                IsExpanded = Context.ExpandedItem == NavigateUrl;
                StateHasChanged();
            };
        }
    }
}