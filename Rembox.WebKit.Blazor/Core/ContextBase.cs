using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rembox.WebKit.Blazor.Annotations;

namespace Rembox.WebKit.Blazor.Core
{
    public class ContextBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}