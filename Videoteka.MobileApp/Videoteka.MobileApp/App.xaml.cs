﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Videoteka.MobileApp.Services;
using Videoteka.MobileApp.Views;

namespace Videoteka.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
