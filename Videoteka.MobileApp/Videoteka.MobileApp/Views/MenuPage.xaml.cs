using Videoteka.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                 new HomeMenuItem {Id = MenuItemType.KorisnickiProfil, Title="Korisnički profil",IconSource="user.png" },
                new HomeMenuItem {Id = MenuItemType.Poruke, Title="Poruke",IconSource="envelope.png" },
                new HomeMenuItem {Id = MenuItemType.MojeRezervacije, Title="Moje rezervacije",IconSource="reservation.png" },
                new HomeMenuItem {Id = MenuItemType.Filmovi, Title="Filmovi",IconSource="movie.png" },
                new HomeMenuItem {Id = MenuItemType.OdjaviSe, Title="Odjavi se",IconSource="logout.png" }
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
    }
}