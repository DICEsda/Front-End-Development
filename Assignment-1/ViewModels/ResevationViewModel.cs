using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Assignment_1.Models;
using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore.Query;

namespace Assignment_1.ViewModels
{
    public class ResevationViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        private UserEntry _user = new UserEntry();

        
        public UserEntry User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public ResevationViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ConfirmCommand = new RelayCommand(async() 
                => await ConfirmAsync());
            CancelCommand = new RelayCommand(Cancel);
        }

        private async Task ConfirmAsync()
        {
                _dbContext.Users.Add(User);
                await _dbContext.SaveChangesAsync();
                Cancel();
        }

        private void Cancel()
        {
            User = new UserEntry
            {
                Name = string.Empty,
                Adresse = string.Empty,
                Brand = string.Empty,
                Model = string.Empty,
                Registry = string.Empty,
                Description = string.Empty,
                SelectedDate = DateTime.Now,
                SelectedTime = TimeSpan.Zero
            };
        }
    }
}
