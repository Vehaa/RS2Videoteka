using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videoteka.MobileApp.ViewModels;
using Videoteka.MobileApp.ViewModels.Filmovi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Videoteka.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PocetnaPage : ContentPage
    {
        private PocetnaViewModel model = null;
        public int _klijentId;

        public PocetnaPage()
        {
            InitializeComponent();
            BindingContext = model = new PocetnaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

    }
}