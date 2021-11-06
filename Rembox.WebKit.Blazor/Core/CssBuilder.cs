using System;
using System.Linq;

namespace Rembox.WebKit.Blazor.Core
{
    public static class CssBuilder
    {
        public static string CssClasses(params string[]? classes)
        {
            if(classes == null)
                return string.Empty;
            
            return string.Join(" ", classes.Where(p => !string.IsNullOrEmpty(p)));
        }

        public static string Styles(params string[]? classes)
        {
            if(classes == null)
                return string.Empty;
            
            return string.Join(";", classes.Where(p => !string.IsNullOrEmpty(p)));
        }
    }
}