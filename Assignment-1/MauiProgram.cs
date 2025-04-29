using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // For registering services
using Assignment_1.Models;
using Assignment_1.ViewModels;
using Assignment_1.Data;
using Assignment_1.OverviewViewModel;
using Assignment_1.Views;

namespace Assignment_1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "app.db");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options =>
                        options.SetShouldEnableSnackbarOnWindows(true)) // Enable Snackbar
                                                                        
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //SQLite database context
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
                options.UseSqlite($"Filename={dbPath}");    
            });

            builder.Services.AddSingleton<AppDbContext>(provider =>
            {
                var options = new DbContextOptionsBuilder<AppDbContext>().Options;
                return new AppDbContext(options, databasePath);
            });

            builder.Services.AddTransient<ResevationViewModel>(); // Inject MainViewModel
            builder.Services.AddTransient<CalendarPageViewModel>();
            builder.Services.AddTransient<InvoiceViewModel>();

            var app = builder.Build();

            // Ensure the database is created
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated(); // Create the database if it doesn't exist
            }

            return builder.Build();
        }
    }
}
