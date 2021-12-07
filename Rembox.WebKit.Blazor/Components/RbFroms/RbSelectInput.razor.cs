using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

// ReSharper disable once CheckNamespace
namespace Rembox.WebKit.Blazor.Components
{
    public partial class RbSelectInput<TValue>: ComponentBase
    {
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }
        
        [Parameter] public EventCallback<List<TValue>> SelectedValuesChanged { get; set; }

        [Parameter] public Func<TValue, string>? ItemText { get; set; }
        
        [Parameter] public RenderFragment<TValue>? ItemTemplate { get; set; }

        [Parameter] public bool IsMultiselect { get; set; }

        [Parameter] public bool IsAutoComplete { get; set; }

        [Parameter] public Func<string, Task<TValue[]>>? AutoComplete { get; set; }
            
        [Parameter] public TValue[] Items { get; set; } = Array.Empty<TValue>();

        [Parameter] public TValue? SelectedValue
        {
            get => SelectedValues.FirstOrDefault();
            set
            {
                SelectedValues.Clear();
                
                if(value == null)
                    return;
                
                SelectedValues.Add(value);
            } 
        }

        [Parameter] public List<TValue> SelectedValues { get; set; } = new();

        [Parameter] public bool IsOpen { get; set; }

        [Inject] public IJSRuntime? JsRuntime { get; set; }
        
        protected override void OnInitialized()
        {
            SetupError = String.Empty;
            
            if (IsAutoComplete && ItemText == null && AutoComplete == null)
            {
                SetupError = "With IsAutoComplete option ItemText or AutoComplete values should be provided";
                return;
            }
            
            if (!IsMultiselect)
            {
                if (ItemText == null && ItemTemplate == null)
                {
                    SetupError = "ItemText or ItemTemplate selectors should be provided";
                }
            }
            else
            {
                if (ItemText == null)
                {
                    SetupError = "With IsMultiselect mode ItemText selector should be provided"; 
                }
            }
        }

        private TValue[] FilteredItems => Items.Where(p => !SelectedValues.Contains(p)).ToArray();

        private TValue[] AutoCompleteItems { get; set; } = Array.Empty<TValue>();
        
        private async void ToggleIsOpen()
        {
            IsOpen = !IsOpen;
            if (IsOpen && IsAutoComplete && autocompleteTextReference.Context != null)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(10));
                
                //if (SelectedValue != null && !IsMultiselect && ItemText != null)
                    AutocompleteText = ItemText(SelectedValue);
                await autocompleteTextReference.FocusAsync();
                StateHasChanged();
            }
        }

        private RenderFragment GetItemView(TValue value)
        {
            if (ItemTemplate != null)
                return ItemTemplate(value);

            if (ItemText != null)
                return builder =>
                {
                    builder.AddContent(0, ItemText(value));
                };

            return builder => builder.AddContent(0, "<div>No ItemTemplate or ItemText has been provided.</div>");
        }

        private async void OnItemSelected(TValue item)
        {
            if (IsMultiselect)
            {
                if (SelectedValues.Contains(item))
                    SelectedValues.Remove(item);
                else
                    SelectedValues.Add(item);
            }
            else
            {
                if(SelectedValues.Contains(item))
                    return;
                SelectedValues.Clear();
                SelectedValues.Add(item);
            }
            
            if (SelectedValueChanged.HasDelegate)
                await SelectedValueChanged.InvokeAsync(item);
            
            if (SelectedValuesChanged.HasDelegate)
                await SelectedValuesChanged.InvokeAsync(SelectedValues);

            IsOpen = false;
            
            StateHasChanged();
        }

        private async void AutocompleteTextChanged(ChangeEventArgs obj)
        {
            IsOpen = true;
            if (ItemText != null)
            {
                AutoCompleteItems = FilteredItems
                    .Where(p => ItemText(p).ToLower().Contains(obj.Value?.ToString() ?? string.Empty))
                    .ToArray();
            }
            else
            {
                if (AutoComplete != null)
                    AutoCompleteItems = await AutoComplete(obj.Value?.ToString() ?? string.Empty);
            }
        }
        
        private string SetupError { get; set; }

        private ElementReference autocompleteTextReference;

        private string AutocompleteText { get; set; }
        
        private bool isAutocompleteInProgress;
    }
}