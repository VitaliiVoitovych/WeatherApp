using WeatherApp.ViewModels;

namespace WeatherApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}