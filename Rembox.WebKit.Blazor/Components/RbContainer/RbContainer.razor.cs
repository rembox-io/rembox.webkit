using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbContainer: ComponentBase
    {
        //[Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public RbContainerOrientation Orientation { get; set; } = RbContainerOrientation.Vertical;

        [Parameter] public RenderFragment? ChildContent { get; set; }

        private void Foo()
        {
        }
    }

    public enum RbContainerOrientation
    {
        Vertical = 1,
        Horizontal = 2
    }
}