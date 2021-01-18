using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videoteka.MobileApp.ViewModels.Rezervacije;
using Videoteka.MobileApp.Views.Filmovi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views.Rezervacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaRezervacijaPage : ContentPage
    {
        private NovaRezervacijaViewModel model = null;
        int _klijentId, _filmId;

        public NovaRezervacijaPage(int klijentId,int filmId)
        {
            _klijentId = klijentId;
            _filmId = filmId;
            InitializeComponent();
            DatePicker rezervacijaod = (DatePicker)FindByName("rezervacijaod");
            rezervacijaod.MinimumDate = DateTime.Now;
            BindingContext = model = new NovaRezervacijaViewModel(_klijentId, _filmId);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (model.Provjera)
            {
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste izvršili rezervaciju!", "OK");
                Page p = Navigation.NavigationStack[Navigation.NavigationStack.Count- 1];
                Navigation.InsertPageBefore(new FilmoviPage(model._klijentId), p);
                await Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Pogrešan datum!", "OK");
            }
        }

        public NovaRezervacijaPage()
        {
            InitializeComponent();
        }

        

        private async void Rezervacijado_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker rezervacijaod = (DatePicker)FindByName("rezervacijaod");
            DatePicker rezervacijado = (DatePicker)FindByName("rezervacijado");
            bool result = await model.CheckRezervacijaDo(rezervacijaod.Date, rezervacijado.Date);
            if (!result)
            {
                rezervacijado.TextColor = Color.Red;
                await Application.Current.MainPage.DisplayAlert("Greška", "Molimo vas da unesete validan datum!", "OK");

            }
            else
            {
                rezervacijado.TextColor = Color.Black;
            }
        }



    }
}