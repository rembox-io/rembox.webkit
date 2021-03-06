using System;
using Rembox.WebKit.Blazor.Core;

namespace Rembox.WebKit.Blazor.Components
{
    public class RbSideBarContext: ContextBase
    {
        private string expandedItem;
        public bool IsExpanded { get; set; }

        public string Location { get; set; }

        public string ExpandedItem
        {
            get => expandedItem;
            set
            {
                expandedItem = value;
                OnPropertyChanged();
            }
        }
    }
}