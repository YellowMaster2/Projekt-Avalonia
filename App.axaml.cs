using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SimpleToDoList.Services;
using SimpleToDoList.ViewModels;
using SimpleToDoList.Views;

namespace SimpleToDoList
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private readonly MainViewModel _mainViewModel = new MainViewModel();

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = _mainViewModel
                };

                desktop.ShutdownRequested += DesktopOnShutdownRequested;
            }

            base.OnFrameworkInitializationCompleted();

            await InitMainViewModelAsync();
        }

        private bool _canClose;
        private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
        {
            e.Cancel = !_canClose;

            if (!_canClose)
            {
                var itemsToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem());

                await ToDoListFileService.SaveToFileAsync(itemsToSave);

                _canClose = true;
                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    desktop.Shutdown();
                }
            }
        }

        private async Task InitMainViewModelAsync()
        {
            var itemsLoaded = await ToDoListFileService.LoadFromFileAsync();

            if (itemsLoaded is not null)
            {
                foreach (var item in itemsLoaded)
                {
                    _mainViewModel.ToDoItems.Add(new ToDoItemViewModel(item));
                }
            }
        }
    }
}
