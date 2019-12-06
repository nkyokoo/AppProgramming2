﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppProgramming2.Services;
using AppProgramming2.Views;

namespace AppProgramming2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new loginPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
