using WeatherApp.ViewModels;

namespace WeatherApp.Pages;

public partial class DetailsWeatherPage : ContentPage
{
	public DetailsWeatherPage(DetailsWeatherViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}