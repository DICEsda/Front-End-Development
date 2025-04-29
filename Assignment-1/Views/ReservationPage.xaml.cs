using Assignment_1.ViewModels;

namespace Assignment_1.Views
{
    public partial class ResevationPage : ContentPage
    {

        public ResevationPage(ResevationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}
