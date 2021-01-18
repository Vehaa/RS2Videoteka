using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videoteka.MobileApp.ViewModels.Poruke;
using Videoteka.Model.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views.Poruke
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaPorukaPage : ContentPage
    {
        public NovaPorukaViewModel model = null;

        public NovaPorukaPage(Poruka p)
        {
            InitializeComponent();
            BindingContext = model = new NovaPorukaViewModel(p)
            {
                Poruka = p
            };

        }
        public NovaPorukaPage()
        {
            InitializeComponent();
        }

        private async void ButtonPosalji_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste poslali poruku", "OK");
            //await Navigation.PushAsync(new MessagesPage(model.novaPoruka.KlijentId));
            await Navigation.PopAsync();
        }


    }
}