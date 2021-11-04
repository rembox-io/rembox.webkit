using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbBlock: ComponentBase
    {
        [Parameter] public string Size { get; set; } = "1";

        [Parameter] public RenderFragment? ChildContent { get; set; }

        private string StyleFlex { get; set; } = "1";
        
        protected override void OnInitialized()
        {
            StyleFlex = GenerateFlex();
        }

        private string GenerateFlex()
        {
            if (string.IsNullOrEmpty(Size))
                return "1";
            
            if (Size.EndsWith("px"))
            {
                return $"0 0 {Size}";
            }
            else if(int.TryParse(Size, out _))
            {
                return Size;
            }

            return "1";
        }
    }
}