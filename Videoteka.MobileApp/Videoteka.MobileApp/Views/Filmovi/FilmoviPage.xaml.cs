using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videoteka.MobileApp.ViewModels.Filmovi;
using Videoteka.MobileApp.Views.Rezervacije;
using Videoteka.Model.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views.Filmovi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmoviPage : ContentPage
    {
        private FilmoviViewModel model = null;
        public int _klijentId;

        public FilmoviPage(int klijentId)
        {
            InitializeComponent();
            _klijentId = klijentId;
            BindingContext = model = new FilmoviViewModel();
        }
        public FilmoviPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            ListView sva = (ListView)FindByName("SviFilmovi");
            ListView preporucena = (ListView)FindByName("PreporuceniFilmovi");


            StackLayout sl = (StackLayout)FindByName("s1");
            if (e.Value)
            {
                sl.Children.Remove(sva);
                if (!sl.Children.Contains(preporucena))
                    sl.Children.Add(preporucena);

                preporucena.IsVisible = true;
                preporucena.RowHeight = 110;
                sva.RowHeight = 0;
            }
            else
            {
                sl.Children.Remove(preporucena);

                if (!sl.Children.Contains(sva))
                    sl.Children.Add(sva);

                sva.IsVisible = true;
                sva.RowHeight = 110;
                preporucena.RowHeight = 0;
            }
        }

        private async void SviFilmovi_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Film;

            await Navigation.PushAsync(new NovaRezervacijaPage(_klijentId, item.FilmId));
        }
    }
}