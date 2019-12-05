using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProgramming2.Models;
using AppProgramming2.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgramming2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherView : ContentPage
    {
        private WeatherViewModel ViewModel;

        public WeatherView()
        {
            InitializeComponent();
            
            BindingContext = ViewModel = new WeatherViewModel();
            ViewModel.GetLocationCommand.Execute(this);
          
            MessagingCenter.Subscribe<MainPage, string>(ViewModel, "ERROR_MESSAGE", async (sender, arg) =>
            {
                await DisplayAlert("Error", arg, "OK");
            });
            MessagingCenter.Subscribe<MainPage, string>(ViewModel, "NOT_SUPPORTED", async (sender, arg) =>
            {
                await DisplayAlert("Not supported", arg, "OK");
            });
            MessagingCenter.Subscribe<MainPage, string>(ViewModel, "NOT_ENABLED", async (sender, arg) =>
            {
                await DisplayAlert("Not enabled", arg, "OK");
            });
            MessagingCenter.Subscribe<MainPage, string>(ViewModel, "PERMISSION_NOT_GRANTED", async (sender, arg) =>
            {
                await DisplayAlert("No permission", arg, "OK");
            });
        }

    }
}