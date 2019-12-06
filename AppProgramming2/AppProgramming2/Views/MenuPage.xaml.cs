using AppProgramming2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using AppProgramming2.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgramming2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
            MainPage RootPage { get => Application.Current.MainPage as MainPage; }
            List<HomeMenuItem> menuItems;
            private MenuPageViewModel ViewModel;
            public MenuPage()
            {
                InitializeComponent();
                BindingContext = ViewModel = new MenuPageViewModel();
                ViewModel.GetUserCommand.Execute(this);
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Id = MenuItemType.Weather, Title="Weather" },
                    new HomeMenuItem {Id = MenuItemType.About, Title="About" },

                };
    
                ListViewMenu.ItemsSource = menuItems;
    
                ListViewMenu.SelectedItem = menuItems[0];
                ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem == null)
                        return;
    
                    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                    await RootPage.NavigateFromMenu(id);
                };
            }

            private void Button_OnClicked(object sender, EventArgs e)
            {
                SecureStorage.RemoveAll();
            }
    }
}