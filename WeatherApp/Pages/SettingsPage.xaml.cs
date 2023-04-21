using WeatherApp.ViewModels;

namespace WeatherApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;

		themeSwitch.IsToggled = App.Current.UserAppTheme == AppTheme.Dark;
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
		App.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}