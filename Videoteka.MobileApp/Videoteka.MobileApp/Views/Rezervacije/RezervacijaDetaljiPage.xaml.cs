using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videoteka.MobileApp.CustomViews;
using Videoteka.MobileApp.ViewModels.Rezervacije;
using Videoteka.Model.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views.Rezervacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijaDetaljiPage : ContentPage
    {
        public RezervacijaDetaljiPage()
        {
            InitializeComponent();
        }

        public RezervacijaDetaljiViewModel model = null;
        public RezervacijaDetaljiPage(RezervacijaFilma rezervacija)
        {
            InitializeComponent();
            BindingContext = model = new RezervacijaDetaljiViewModel()
            {
                rezervacijaFilma = rezervacija
            };

            if (rezervacija.RezervacijaDo > DateTime.Now)
            {
                Grid g = (Grid)FindByName("Red4Button");
                g.IsVisible = true;
            }
            else
            {
                Grid g = (Grid)FindByName("Red4Ocjena");
                g.IsVisible = true;
            }
        }

        private async void OnRatingChanged(object sender, float e)
        {
            CustomRatingBar customRatingBar = (CustomRatingBar)FindByName("customRatingBar");
            customRatingBar.IsEnabled = false;
            customRatingBar.Rating = e;
            int rezervacijaId = model.rezervacijaFilma.RezervacijaFilmaId;

            await model.DodajOcjenu(rezervacijaId, e);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool izbor = await Application.Current.MainPage.DisplayAlert(null, "Da li ste sigurni da želite otkazati rezervaciju ?", "Da", "Ne");
            if (izbor)
            {
                await model.OtkaziRezervaciju();
                if (model.Provjera)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavijest", "Rezervacija otkazana", "OK");
                    await Navigation.PopAsync();
                }
            }
        }


    }
}