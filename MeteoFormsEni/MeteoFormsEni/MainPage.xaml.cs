using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoFormsEni.Services;
using RestSharp;
using webservices.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MeteoFormsEni
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(city.Text))
            {
                // afficher une erreur
                await DisplayAlert("Erreur", "Vous devez renseigner une ville", "OK");
                return;
            }

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                // afficher une erreur
                await DisplayAlert("Erreur", "Vous devez être connecté", "OK");
                return;
            }

            // requête HTTP
            IRestResponse<OpenWeatherMap> content = await OpenweatherService.GetCity(city.Text.Trim()); // raw content as string

            if (content.IsSuccessful)
            {
                var weather = Serialize.FromJson(content.Content);
                
                resultat.Text = $"{weather.Name} : {weather.Main.Temp}";
                imageIcon.Source =
                    $"https://openweathermap.org/img/wn/{weather.Weather[0].Icon}@2x.png?rand={Guid.NewGuid().ToString()}";
            }
            else
            {
                await DisplayAlert("Erreur", "Erreur serveur", "Fermer");
            }
        }
    }
}
