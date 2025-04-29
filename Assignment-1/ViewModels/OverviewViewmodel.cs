using Assignment_1.Models;
using Assignment_1.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.OverviewViewModel
{
    public partial class CalendarPageViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext; // instance of db to read from

        [ObservableProperty]
        private DateTime selectedDate = DateTime.Now;

        [ObservableProperty]
        public ObservableCollection<UserEntry>? tasksForSelectedDate = new();

        public CalendarPageViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ShowTasksCommand = new AsyncRelayCommand(LoadTasksForSelectedDateAsync);
        }

        public IAsyncRelayCommand ShowTasksCommand { get; }

        private async Task LoadTasksForSelectedDateAsync()
        {
            // Fetch tasks from the database
            var tasks = await _dbContext.Users
                                        .Where(t => t.SelectedDate.Date == selectedDate.Date)
                                        .ToListAsync();

            TasksForSelectedDate.Clear(); // Clear tasks
             
            foreach (var task in tasks)
            {
                TasksForSelectedDate.Add(task); // Add the fetched tasks
            }

            // Notify property change - force that shi
            OnPropertyChanged(nameof(TasksForSelectedDate));
            OnPropertyChanged(nameof(SelectedDate));
        }
    }
}
