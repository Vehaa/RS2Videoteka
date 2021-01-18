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
    public partial class PorukePage : ContentPage
    {

        public int KlijentID;
        private PorukaViewModel model = null;
        public PorukePage(int Klijent)
        {
            InitializeComponent();

            KlijentID = Klijent;
            BindingContext = model = new PorukaViewModel(KlijentID);
        }
        public PorukePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();


        }

        private async void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Poruka;

            if (item.Posiljaoc == "Uposlenik")
                await model.OznaciKaoProcitanu(item);
            await Navigation.PushAsync(new PorukaDetaljiPage(item));
        }

    }
}