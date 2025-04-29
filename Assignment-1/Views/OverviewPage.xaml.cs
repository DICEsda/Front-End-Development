using Assignment_1.OverviewViewModel;

namespace Assignment_1.Views
{
    public partial class OverviewPage : ContentPage
    {

        public OverviewPage(CalendarPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }
    }
}
