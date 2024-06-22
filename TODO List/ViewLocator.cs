using Avalonia.Controls;
using TODO_List.ViewModels;
using System;

namespace TODO_List
{
    public class ViewLocator
    {
        public static Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                var control = (Control)Activator.CreateInstance(type)!;
                control.DataContext = data;
                return control;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public static bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
