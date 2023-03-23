using WeatherApp.ViewModels;

namespace WeatherApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}