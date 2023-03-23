using WeatherApp.ViewModels;

namespace WeatherApp.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage(FavouritesViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}