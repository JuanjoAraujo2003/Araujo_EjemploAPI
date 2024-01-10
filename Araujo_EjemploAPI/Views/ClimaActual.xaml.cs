using Araujo_EjemploAPI.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Araujo_EjemploAPI.Views;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
		string longitud = lon.Text;

		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient())
			{
				string url = $"https://api.openweather.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=3d16d3aa3c180a86418fe7f36c387457";

				 var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);

					weatherLabel.Text = clima.weather[0].main;
					citylabel.Text = clima.name;
				}

            }

		}
    }
}