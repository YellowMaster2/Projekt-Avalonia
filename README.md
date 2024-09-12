
# ListaZadań

ListaZadań to aplikacja do zarządzania listą zadań, zbudowana przy użyciu Avalonia.

## Struktura projektu
```
_docs/
App.axaml
App.axaml.cs
app.manifest
Assets/
bin/
	Debug/
		net6.0/
			...
Models/
	ToDoItem.cs
obj/
	Debug/
		net6.0/
			...
	project.assets.json
	project.nuget.cache
	SimpleToDoList.csproj.nuget.dgspec.json
	SimpleToDoList.csproj.nuget.g.props
	SimpleToDoList.csproj.nuget.g.targets
Program.cs
Projekt-Avalonia.sln
Services/
	ToDoListFileService.cs
SimpleToDoList.csproj
ViewModels/
	MainViewModel.cs
	ToDoItemViewModel.cs
	ViewModelBase.cs
Views/
	MainWindow.axaml
	MainWindow.axaml.cs
```

## Pliki i katalogi

- **App.axaml**: Główny plik XAML aplikacji.
- **App.axaml.cs**: Kod-behind dla `App.axaml`.
- **Models/ToDoItem.cs**: Definicja modelu `ToDoItem`.
- **Services/ToDoListFileService.cs**: Serwis do zapisywania i ładowania listy zadań z pliku.
- **ViewModels/MainViewModel.cs**: Główny ViewModel aplikacji.
- **ViewModels/ToDoItemViewModel.cs**: ViewModel dla pojedynczego zadania.
- **Views/MainWindow.axaml**: Widok głównego okna aplikacji.
- **Views/MainWindow.axaml.cs**: Kod-behind dla `MainWindow.axaml`.

## Klasy i funkcje

### Models

#### [ToDoItem](Models/ToDoItem.cs)

```csharp
public class ToDoItem
{
    public bool IsChecked { get; set; }
    public string? Content { get; set; }
}
```

### Services

#### ToDoListFileService

> Serwis do zapisywania i ładowania listy zadań z pliku.

### ViewModels

#### MainViewModel

> Główny ViewModel aplikacji, zarządza listą zadań.

#### ToDoItemViewModel

> ViewModel dla pojedynczego zadania.

### Views

#### MainWindow

> Główne okno aplikacji.

```axaml
<Window xmlns="https://github.com/avaloniaui"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:vm="using:SimpleToDoList.ViewModels"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Width="300" Height="500" Padding="4"
    x:Class="SimpleToDoList.Views.MainWindow"
    x:DataType="vm:MainViewModel"
    Icon="/Assets/list.ico"
    Title="Lista zadań"
    Background="#3d3d3d">
    <Design.DataContext>
    <vm:MainViewModel />
    </Design.DataContext>
    <Grid RowDefinitions="Auto, *, Auto"
      x:Name="Root">
    <TextBlock Text="Lista zadań" Classes="h1" Foreground="White" />
    <ScrollViewer Grid.Row="1">
        <ItemsControl ItemsSource="{Binding ToDoItems}">
        <ItemsControl.ItemTemplate>
            <DataTemplate DataType="vm:ToDoItemViewModel">
```

## Uruchomienie aplikacji

> Aby uruchomić aplikację, użyj Visual Studio lub Visual Studio Code. Otwórz plik `Projekt-Avalonia.sln` i uruchom projekt.

## Autorzy

- [Sławomir Żyła](https://github.com/YellowMaster2)

## Licencja

Ten projekt jest licencjonowany na warunkach licencji MIT.
