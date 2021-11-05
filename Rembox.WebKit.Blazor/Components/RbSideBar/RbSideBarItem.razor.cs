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

        [Parameter] public string Href { get; set; } = string.Empty;
        
        [Parameter] public string Badge { get; set; } = string.Empty;

        [Parameter] public RbSeverity BadgeSeverity { get; set; } = RbSeverity.Secondary;

        [Inject] public NavigationManager NavigationManager { get; set; }
        
        public bool IsActive { get; set; }
        
        [CascadingParameter] public RbSideBarContext? Context { get; set; }

        private void OnItemClicked()
        {
            Console.WriteLine($"item clicked {Href}");
            if (Context != null)
                Context.ExpandedItem = Href;
            
            if(!string.IsNullOrEmpty(Href))
                NavigationManager.NavigateTo(Href);
        }

        protected override void OnInitialized()
        {
            Context!.PropertyChanged += (_, _) =>
            {
                IsActive = Context.ExpandedItem.StartsWith(Href);
                StateHasChanged();
            };
        }
    }
}