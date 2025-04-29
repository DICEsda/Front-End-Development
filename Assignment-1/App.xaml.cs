using Assignment_1.Data;
using Assignment_1.OverviewViewModel;
namespace Assignment_1
{
    public partial class App : Application
    {
        public static string DatabasePath { get; private set; }

        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}