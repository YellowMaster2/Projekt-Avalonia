using CommunityToolkit.Mvvm.ComponentModel;
using TODO_List.Models;

namespace TODO_List.ViewModels;

public partial class ToDoItemViewModel : ViewModelBase
{
    public ToDoItemViewModel()
    {
        // empty
    }
    
    public ToDoItemViewModel(ToDoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }
    
    private bool _isChecked;

    public bool IsChecked
    {
        get { return _isChecked; }
        set { SetProperty(ref _isChecked, value); }
    }
    
    private string? _content;
    
    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
}
