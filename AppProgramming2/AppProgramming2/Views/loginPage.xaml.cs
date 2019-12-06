using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProgramming2.Models;
using AppProgramming2.Services;
using AppProgramming2.util;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgramming2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginPage : ContentPage
    {
        
        private Validation validator;

        public loginPage()
        {
            InitializeComponent();
            validator = new Validation();
            checkLogin();
        }

        void LoginBtn_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailInput.Text) || string.IsNullOrEmpty(passwordInput.Text))
            {
                DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                Authentication auth = new Authentication();
                Task<Boolean> successful = null;
                Task.Run(() => successful = auth.login(emailInput.Text, passwordInput.Text)).Wait();
                if (successful.Result)
                {
                    Navigation.PushModalAsync(new MainPage());

                }
                else
                {
                    DisplayAlert("Login", "login failed", "ok");
                }
                
            }
        }

        void EmailInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!validator.IsValidEmail(emailInput.Text))
            {
                loginBtn.IsEnabled = false;
            }
            else
            {
                loginBtn.IsEnabled = true;
            }
        }

         void checkLogin()
        {
            var authToken = SecureStorage.GetAsync("auth_token");
            

            if (authToken.Result != null)
            {
               Navigation.PushModalAsync(new MainPage());
            }

        }
       
    }
}