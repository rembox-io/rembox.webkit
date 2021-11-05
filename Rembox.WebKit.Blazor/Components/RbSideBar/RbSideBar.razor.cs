using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbSideBar: ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        [Parameter] public RenderFragment? Header { get; set; }

        [Parameter] public RenderFragment? CollapsedHeader { get; set; }

        [Parameter] public RenderFragment? Items { get; set; }
        
        [Parameter] public RenderFragment? Footer { get; set; }
        
        [Parameter] public RenderFragment? Content { get; set; }

        public RbSideBarContext Context { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += (_, args) =>
            {
                Context.Location = args.Location;
                Console.WriteLine($"Url: {args.Location}");
                Console.WriteLine($"Uri: {NavigationManager.Uri}");
            };
        }

        protected override void OnInitialized()
        {
            Context.IsExpanded = true;
        }

        public void Toggle()    
        {
            Context.IsExpanded = !Context.IsExpanded;
        }
    }   
}