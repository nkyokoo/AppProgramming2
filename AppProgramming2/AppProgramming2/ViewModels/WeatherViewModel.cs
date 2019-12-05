using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Input;
using AppProgramming2.Models;
using AppProgramming2.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppProgramming2.Services
{
    public class WeatherViewModel : BaseViewModel
    {
       
        private WeatherServices _weatherServices;

        private string _errormessage;

       
        private string _iconurl;
        public string iconurl
        {
            get => _iconurl;
            set
            {
                _iconurl = value;
                OnPropertyChanged(nameof(iconurl));
            }
        }

        private Forecast _forecast;

        public Forecast forecastData
        {
            get => this._forecast;
            set
            {
                this._forecast = value;
                OnPropertyChanged(nameof(forecastData));
            }
        }
        public WeatherViewModel()
        {
            Title = "weather";
            
            forecastData = new Forecast();
            _weatherServices = new WeatherServices();
        }

        public ICommand GetLocationCommand => new Command(GetLocation);

        async void GetLocation()
        {               

            try
            {
                
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    string data = _weatherServices.GetWeather(location.Latitude, location.Longitude);
                    Debug.WriteLine(data);
                    var forecast = JsonConvert.DeserializeObject<Forecast>(data);
            
                    forecastData = forecast;
                    var icon = forecastData.Weather[0].Icon;
                    iconurl = "https://openweathermap.org/img/w/" + icon + ".png";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                MessagingCenter.Send(this, "NOT_SUPPORTED","This device doesn't support location services");

            }
            catch (FeatureNotEnabledException fneEx)
            {
                MessagingCenter.Send(this, "NOT_ENABLED","Location services is not enabled on this device");

            }
            catch (PermissionException pEx)
            {
                MessagingCenter.Send(this, "PERMISSION_NOT_GRANTED","The application has no permission to access your location");
            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "LOCATION_ERROR",ex);
            }
        }
    }
}