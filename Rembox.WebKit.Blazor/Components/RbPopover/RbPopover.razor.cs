using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbPopover : ComponentBase
    {
        private bool isContentVisible = false;
        
        [Parameter] public RenderFragment Target { get; set; }

        [Parameter] public RenderFragment Content { get; set; }

        [Parameter] public string Header { get; set; }
        
        [Parameter] public bool IsContentVisible
        {
            get => isContentVisible;
            set
            {
                if (Trigger == RbPopoverTrigger.Custom)
                    isContentVisible = value;
            }
        }

        [Parameter] public bool ShowArrow { get; set; } = true;
        
        [Parameter] public RbPopoverTrigger Trigger { get; set; } = RbPopoverTrigger.Click;

        [Parameter] public RbPopoverPosition Position { get; set; } = RbPopoverPosition.BottomCenter;

        public void OnTargetClicked()
        {
            if (Trigger == RbPopoverTrigger.Click)
                isContentVisible = !isContentVisible;
        }
    }

    public enum RbPopoverTrigger
    {
        Hover,
        Click,
        Custom
    }
    
    public enum RbPopoverPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        RightTop,
        RightCenter,
        RightBottom,
        BottomLeft,
        BottomCenter,
        BottomRight,
        LeftTop,
        LeftCenter,
        LeftBottom
    }
}