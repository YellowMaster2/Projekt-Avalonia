using CommunityToolkit.Mvvm.ComponentModel;

namespace TODO_List.Models;

public class ToDoItem
{
    public bool IsChecked { get; set; }
    public string? Content { get; set; }
}
