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
          
          
       
        }

    }
}