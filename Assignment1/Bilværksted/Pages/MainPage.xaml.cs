using Bilværksted.Models;
using Bilværksted.PageModels;

namespace Bilværksted.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}