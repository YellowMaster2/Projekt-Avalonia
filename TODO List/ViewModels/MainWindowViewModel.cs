using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace TODO_List.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public string Greeting => "Welcome to Avalonia!";
    }
}
