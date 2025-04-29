using Assignment_1.ViewModels;

namespace Assignment_1.Views;

public partial class InvoicePage : ContentPage
{
    private readonly InvoiceViewModel _viewModel;

    public InvoicePage(InvoiceViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
