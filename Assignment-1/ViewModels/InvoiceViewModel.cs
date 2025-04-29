using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Assignment_1.Models;
using Assignment_1.Data;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Assignment_1.ViewModels
{
    public class InvoiceViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext; 
        private InvoiceEntry _invoice = new InvoiceEntry();
        public InvoiceEntry Invoice
        {
            get => _invoice;
            set => SetProperty(ref _invoice, value);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }
        public ObservableCollection<string> Materials { get; set; } = new ObservableCollection<string>
        {
            "Material 1",
            "Material 2",
            "Material 3"
        };
        public InvoiceViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ConfirmCommand = new RelayCommand(async () => await ConfirmAsync());
            CancelCommand = new RelayCommand(Cancel);
        }
        private async Task ConfirmAsync()
        {
            _dbContext.Invoices.Add(Invoice);
            await _dbContext.SaveChangesAsync();

            Cancel();
        }

        private void Cancel()
        {
            Invoice = new InvoiceEntry
            {
                Mechanic = string.Empty,
                Material = string.Empty,
                TimeUsed = 0,
                Price = 0
            };
        }
    }
}
