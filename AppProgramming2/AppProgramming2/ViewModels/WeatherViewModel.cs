using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Input;
using AppProgramming2.Models;
using AppProgramming2.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppProgramming2.Services
{
    public class WeatherViewModel : BaseViewModel
    {
        private LocalLocation localLocation;
        private WeatherServices _weatherServices;

        private Forecast _forecast;
        public Forecast forecastData
        {
            get => _forecast;
            set
            {
                _forecast = value;
                OnPropertyChanged(nameof(forecastData));
                
            }
            
        }

        public WeatherViewModel()
        {
            
            localLocation = new LocalLocation();
            _weatherServices = new WeatherServices();
            

        }
        
        public ICommand GetLocationCommand => new Command(GetLocation);

         async void GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    string data = _weatherServices.GetWeather(location.Latitude,location.Longitude);
                    Debug.WriteLine(data);
                    var forecast = Forecast.FromJson(data);
                    forecastData = forecast;
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}