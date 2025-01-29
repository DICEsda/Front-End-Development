using MauiTodo.Models;
namespace Lektion2_MauiTodo;

public partial class MainPage : ContentPage
{
	string _todoListData = string.Empty; //Values of the to-do items
	readonly Database _database; //Stores an instance of the database clas

	public MainPage() {
		_database = new Database(); //create an instance of the database class & assign it to the _database field.
		_ = Initialize(); //Uses the discard variable to call our Initialize meth
		InitializeComponent();
	}
	private async Task Initialize() { //Async/Await
		await Task.CompletedTask;
	}	
	
	private void Button_Clicked(object sender, EventArgs e){ // Event Handler TODO

	}

}




