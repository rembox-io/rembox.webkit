using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbContainer: ComponentBase
    {
        private RbContainerOrientation orientation = RbContainerOrientation.Vertical;

        [Parameter]
        public RbContainerOrientation Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                RenderCssDirection();
            }
        }

        [Parameter] public RenderFragment? ChildContent { get; set; }

        private string CssDirection { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            RenderCssDirection();
        }

        private void RenderCssDirection()
        {
            CssDirection = Orientation == RbContainerOrientation.Horizontal
                ? "rb-direction-horizontal"
                : "rb-direction-vertical";
        }
    }

    public enum RbContainerOrientation
    {
        Vertical = 1,
        Horizontal = 2
    }
}