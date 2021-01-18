using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Xamarin.Forms;

namespace Videoteka.MobileApp.ViewModels.Rezervacije
{
    public class RezervacijeViewModel:BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");

        public int KlijentID;

        public RezervacijeViewModel(int Klijent)
        {
            KlijentID = Klijent;
            InitCommand = new Command(async () => await Init());

        }
        public RezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<RezervacijaFilma> RezervacijeFilmaList { get; set; } = new ObservableCollection<RezervacijaFilma>();
        public ObservableCollection<RezervacijaFilma> RezervacijeFilmaListZavrsene { get; set; } = new ObservableCollection<RezervacijaFilma>();

        public ICommand InitCommand { get; set; }


        private int ukupnoRezervacija;
        private int ukupnoRezervacijaUToku;
        private int ukupnoRezervacijaZavrsenih;
        private decimal ukupnoUtroseno;

        public int UkupnoRezervacija
        {
            set { SetProperty(ref ukupnoRezervacija, value); }
            get { return ukupnoRezervacija; }
        }
        public int UkupnoRezervacijaUToku
        {
            set { SetProperty(ref ukupnoRezervacijaUToku, value); }
            get { return ukupnoRezervacijaUToku; }
        }
        public int UkupnoRezervacijaZavrsenih
        {
            set { SetProperty(ref ukupnoRezervacijaZavrsenih, value); }
            get { return ukupnoRezervacijaZavrsenih; }
        }
        public decimal UkupnoUtroseno
        {
            set { SetProperty(ref ukupnoUtroseno, value); }
            get { return ukupnoUtroseno; }
        }

        public async Task Init()
        {
            if (KlijentID > 0)
            {
                RezervacijaFilmaSearchRequest searchRequest = new RezervacijaFilmaSearchRequest();
                searchRequest.KlijentId = KlijentID;
                searchRequest.Otkazana = false;

                var list = await _rezervacijeService.Get<IEnumerable<Model.Models.RezervacijaFilma>>(searchRequest);


                int brojRezervacija = 0, uToku = 0, Zavrsene = 0;
                decimal ukupno = 0;
                RezervacijeFilmaList.Clear();
                RezervacijeFilmaListZavrsene.Clear();
                foreach (var item in list)
                {
                    if (item.RezervacijaDo > DateTime.Now)
                    {
                        RezervacijeFilmaList.Add(item);
                        uToku++;
                    }
                    else
                    {
                        RezervacijeFilmaListZavrsene.Add(item);
                        Zavrsene++;
                    }
                    ukupno +=(decimal) item.IznosSaPopustom;
                    brojRezervacija++;
                }


                UkupnoRezervacija = brojRezervacija;
                UkupnoRezervacijaUToku = uToku;
                UkupnoRezervacijaZavrsenih = Zavrsene;
                UkupnoUtroseno = ukupno;
            }
        }
    }
}
