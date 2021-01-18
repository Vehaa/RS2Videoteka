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
    public partial class PorukaDetaljiPage : ContentPage
    {
        public PorukaDetaljiViewModel model = null;
        public PorukaDetaljiPage(Poruka poruka)
        {
            InitializeComponent();
            BindingContext = model = new PorukaDetaljiViewModel()
            {
                Poruka = poruka
            };
        }

        public PorukaDetaljiPage()
        {
            InitializeComponent();
        }

        private async void ButtonOdgovori_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NovaPorukaPage(model.Poruka));
        }
    }
}