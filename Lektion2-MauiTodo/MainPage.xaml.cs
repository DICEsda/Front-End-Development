using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MauiTodo.Data;
using MauiTodo.Models;

namespace Lektion2_MauiTodo
{
    public partial class MainPage : ContentPage
    {
        private Database _database;
        private string _todoListData = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
            _ = Initialize();
        }

        private async Task Initialize()
        {
            var todos = await _database.GetTodos();
            foreach (var todo in todos)
            {
                _todoListData += $"{todo.Title} - {todo.Due:f}{Environment.NewLine}";
            }
            TodosLabel.Text = _todoListData;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var todo = new TodoItem
            {
                Due = DueDatepicker.Date,
                Title = TodoTitleEntry.Text
            };
            var inserted = await _database.AddTodo(todo);
            if (inserted != 0)
            {
                _todoListData += $"{todo.Title} - {todo.Due:f}{Environment.NewLine}";
                TodosLabel.Text = _todoListData;
                TodoTitleEntry.Text = string.Empty;
                DueDatepicker.Date = DateTime.Now;
            }
        }

        private async void Slide_colorchanged(object sender, EventArgs e)
        {
            var slider = (Slider)sender;
            var value = slider.Value;
            var color = Color.FromHsla(value, 1, 0.5);
            slider.BackgroundColor = color;
        }
    }
}
