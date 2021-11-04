using Microsoft.AspNetCore.Components;

namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbSideBar: ComponentBase
    {
        [Parameter] public RenderFragment? Header { get; set; }

        [Parameter] public RenderFragment? Items { get; set; }
        
        [Parameter] public RenderFragment? Footer { get; set; }
        
        [Parameter] public RenderFragment? Content { get; set; }

        public bool IsExpanded { get; set; } = true;

        public void Toggle()    
        {
            IsExpanded = !IsExpanded;
        }
    }   
}