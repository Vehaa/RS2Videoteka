using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videoteka.MobileApp.ViewModels.Rezervacije;
using Videoteka.Model.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views.Rezervacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MojeRezervacijePage : ContentPage
    {
        public int KlijentID;
        private RezervacijeViewModel model = null;

        public MojeRezervacijePage(int Klijent)
        {
            InitializeComponent();
            KlijentID = Klijent;
            BindingContext = model = new RezervacijeViewModel(KlijentID);
        }
        public MojeRezervacijePage()
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

            ListView zavrsene = (ListView)FindByName("ZavrseneRezervacije");
            ListView uToku = (ListView)FindByName("UTokuRezervacije");


            StackLayout sl = (StackLayout)FindByName("sl");
            if (e.Value)
            {
                sl.Children.Remove(uToku);
                if (!sl.Children.Contains(zavrsene))
                    sl.Children.Add(zavrsene);

                zavrsene.IsVisible = true;
                zavrsene.RowHeight = 130;
                uToku.RowHeight = 0;
            }
            else
            {
                sl.Children.Remove(zavrsene);

                if (!sl.Children.Contains(uToku))
                    sl.Children.Add(uToku);

                uToku.IsVisible = true;
                uToku.RowHeight = 130;
                zavrsene.RowHeight = 0;
            }
        }

        private async void UTokuRezervacije_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RezervacijaFilma;


            await Navigation.PushAsync(new RezervacijaDetaljiPage(item));
        }
    }
}