using WeatherApp.Pages;

namespace WeatherApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;

            Routing.RegisterRoute(nameof(DetailsWeatherPage), typeof(DetailsWeatherPage));

            if (DeviceInfo.Idiom == DeviceIdiom.Phone)
                CurrentItem = PhoneTabs;

            App.Current.UserAppTheme = AppTheme.Dark;
        }

        private string selectedRoute;

        public string SelectedRoute
        {
            get => selectedRoute;
            set
            {
                selectedRoute = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedRoute))
                Shell.Current.GoToAsync($"//{selectedRoute}");
        }
    }
}