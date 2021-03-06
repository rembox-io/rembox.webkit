using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbContainerBlock: ComponentBase
    {
        [Parameter] public string Size { get; set; } = "0";

        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public RbContainerBlockType BlockType { get; set; } = RbContainerBlockType.Content;
        
        private string StyleFlex { get; set; } = "0";
        
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

    public enum RbContainerBlockType
    {
        Empty,
        Content,
        Columns
    }
}