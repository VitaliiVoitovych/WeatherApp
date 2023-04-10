namespace WeatherApp.Views;

public partial class WeatherInfoView : ContentView
{
	public static readonly BindableProperty ImageSourceProperty =
		BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(WeatherInfoView), default);

	public ImageSource ImageSource
	{
		get => (ImageSource)GetValue(ImageSourceProperty);
		set => SetValue(ImageSourceProperty, value);
	}

    public static readonly BindableProperty FrameTitleProperty =
        BindableProperty.Create(nameof(FrameTitle), typeof(string), typeof(WeatherInfoView), default);

    public string FrameTitle
    {
        get => (string)GetValue(FrameTitleProperty);
        set => SetValue(FrameTitleProperty, value);
    }

	public static readonly BindableProperty ValueProperty =
		BindableProperty.Create(nameof(Value), typeof(string), typeof(WeatherInfoView), default);

	public string Value
	{
		get => (string)GetValue(ValueProperty);
		set => SetValue(ValueProperty, value);
	}

    public WeatherInfoView()
	{
		InitializeComponent();
	}
}