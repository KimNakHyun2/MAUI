
using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
	public List<Models.List> WeatherList;
	private double latitude;
	private double longitude;

	public WeatherPage()
	{
		InitializeComponent();
        WeatherList = new List<Models.List>();

    }

	protected async override void OnAppearing()
	{
		base.OnAppearing();

        var result = await ApiService.GetWeather(latitude, longitude);
        foreach (var item in result.list)
		{
			WeatherList.Add(item);
		}
		CvWeather.ItemsSource = WeatherList;
		
		LblCitiy.Text = result.city.name;
		LblWeatherDescription.Text = result.list[0].weather[0].description;
		LblTemperature.Text = result.list[0].main.temperature + "¡ÆC";
		LblHumidity.Text = result.list[0].main.humidity + "%";
		LblWind.Text = result.list[0].wind.speed + "km/h";
		ImgWeatherIcon.Source = result.list[0].weather[0].customIcon;

    }

	public async Task GetLocation()
	{
		var location = await Geolocation.GetLocationAsync();
		this.latitude = location.Latitude;
		this.longitude = location.Longitude;
	}
}