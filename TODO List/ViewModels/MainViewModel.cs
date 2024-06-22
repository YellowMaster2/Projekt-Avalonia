﻿using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TODO_List.Models;
using TODO_List.Services;

namespace TODO_List.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (Design.IsDesignMode)
            {
                ToDoItems = new ObservableCollection<ToDoItemViewModel>(new[]
                {
                    new ToDoItemViewModel() { Content = "Hello" },
                    new ToDoItemViewModel() { Content = "Avalonia", IsChecked = true}
                });
            }
        }

        public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new ObservableCollection<ToDoItemViewModel>();

        [RelayCommand(CanExecute = nameof(CanAddItem))]
        private void AddItem()
        {
            ToDoItems.Add(new ToDoItemViewModel() { Content = NewItemContent });
            NewItemContent = null;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
        private string? _newItemContent;

        private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);

        [RelayCommand]
        private void RemoveItem(ToDoItemViewModel item)
        {
            ToDoItems.Remove(item);
        }
    }

    public partial class ToDoItemViewModel
    {
        public string Content { get; set; }
    }
}
