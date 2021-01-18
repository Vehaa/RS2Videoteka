using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Videoteka.MobileApp.Models;
using Videoteka.MobileApp.Views.Filmovi;
using Videoteka.MobileApp.Views.Rezervacije;
using Videoteka.MobileApp.Views.Poruke;
using Videoteka.MobileApp.Views.Klijenti;

namespace Videoteka.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public int _klijentId;

        public MainPage(int klijentId)
        {
            InitializeComponent();
            _klijentId = klijentId;

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Filmovi, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.KorisnickiProfil:
                        MenuPages.Add(id, new NavigationPage(new ProfileSettingsPage(_klijentId)));
                        break;
                    case (int)MenuItemType.Poruke:
                        MenuPages.Add(id, new NavigationPage(new PorukePage(_klijentId)));
                        break;
                    case (int)MenuItemType.MojeRezervacije:
                        MenuPages.Add(id, new NavigationPage(new MojeRezervacijePage(_klijentId)));
                        break;
                    case (int)MenuItemType.Filmovi:
                        MenuPages.Add(id, new NavigationPage(new FilmoviPage(_klijentId)));
                        break;
                    case (int)MenuItemType.OdjaviSe:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}