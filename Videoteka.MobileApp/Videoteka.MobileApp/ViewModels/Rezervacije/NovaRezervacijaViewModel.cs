using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videoteka.Model.Requests;
using Xamarin.Forms;

namespace Videoteka.MobileApp.ViewModels.Rezervacije
{
    public class NovaRezervacijaViewModel : BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _filmoviService = new APIService("Film");
        private readonly APIService _racuniService = new APIService("Racun");

        public int _klijentId, _filmId;


        public NovaRezervacijaViewModel(int klijentId, int filmId)
        {
            _klijentId = klijentId;
            _filmId = filmId;
            RezervisiCommand = new Command(async () => await Rezervisi());
        }

        public NovaRezervacijaViewModel()
        {

        }

        public RezervacijaFilmaUpsertRequest novaRezervacija { get; set; } = new RezervacijaFilmaUpsertRequest();

        public ICommand RezervisiCommand { get; set; }

        public DateTime _rezervacijaOd = DateTime.Now;
        public DateTime RezervacijaOd
        {
            get { return _rezervacijaOd; }
            set
            {
                SetProperty(ref _rezervacijaOd, value);
                if (value != null)
                    RezervacijaDo = value;
            }
        }

        public DateTime _rezervacijaDo = DateTime.Now;
        public DateTime RezervacijaDo
        {
            get { return _rezervacijaDo; }
            set
            {
                SetProperty(ref _rezervacijaDo, value);

            }
        }

        public byte[] _slikaThumb;
        public byte[] SlikaThumb
        {
            get { return _slikaThumb; }
            set { SetProperty(ref _slikaThumb, value); }
        }

        public decimal _cijenaIznajmljivanja;
        public decimal CijenaIznajmljivanja
        {
            get { return _cijenaIznajmljivanja; }
            set { SetProperty(ref _cijenaIznajmljivanja, value); }
        }

        public string _filmInformacije = string.Empty;
        public string FilmInformacije
        {
            get { return _filmInformacije; }
            set { SetProperty(ref _filmInformacije, value); }
        }

        public string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }

        bool _provjera = false;
        public bool Provjera
        {
            get { return _provjera; }
            set { SetProperty(ref _provjera, value); }
        }


        public async Task Rezervisi()
        {
            IsBusy = true;

            novaRezervacija.KlijentId = _klijentId;
            novaRezervacija.FilmId = _filmId;
            novaRezervacija.DatumKreiranja = DateTime.Now;
            novaRezervacija.Otkazana = false;

            if (RezervacijaOd != null && RezervacijaDo != null && _provjera==true)
            {
                novaRezervacija.RezervacijaDo = RezervacijaDo;
                novaRezervacija.RezervacijaOd = RezervacijaOd;

                TimeSpan brojDana = RezervacijaDo - RezervacijaOd;
                novaRezervacija.Popust = 0;

                //Automatsko definisanje popusta
                //Uposlenik (Desktop) može izmjeniti iznos popusta uređivanjem rezervacije
                if (brojDana.Days >= 3 && brojDana.Days < 5)
                    novaRezervacija.Popust = 0.1;
                else if (brojDana.Days >= 5 && brojDana.Days < 10)
                    novaRezervacija.Popust = 0.2;
                else if (brojDana.Days >= 10)
                    novaRezervacija.Popust = 0.3;

                if (_filmId != 0)
                {
                    var film = await _filmoviService.GetById<Model.Models.Film>(_filmId);

                    if (brojDana.Days == 0)
                    {
                        novaRezervacija.Iznos = (film.CijenaIznajmljivanja * 1);
                    }
                    else
                    {
                        novaRezervacija.Iznos = (film.CijenaIznajmljivanja * brojDana.Days);
                    }

                    novaRezervacija.IznosSaPopustom = novaRezervacija.Iznos - (novaRezervacija.Iznos * (decimal)novaRezervacija.Popust);

                    novaRezervacija.FilmId = _filmId;
                    SlikaThumb = film.Slika;
                    CijenaIznajmljivanja = film.CijenaIznajmljivanja;
                    FilmInformacije = film.Naziv + " (" + film.Godina + ") ";

                    try
                    {
                        var racun = new RacunUpsertRequest()
                        {
                            DatumIzdavanja = DateTime.Now,
                            UkupanIznos = (decimal)novaRezervacija.IznosSaPopustom
                        };

                        var entityRacun = await _racuniService.Insert<Model.Models.Racun>(racun);
                        novaRezervacija.RacunId = entityRacun.RacunId;
                        novaRezervacija.Opis = FilmInformacije;

                        var entity = await _rezervacijeService.Insert<Model.Models.RezervacijaFilma>(novaRezervacija);

                        if (entity != null)
                        {
                            entity.SlikaThumb = SlikaThumb;
                            entity.CijenaIznajmljivanja = CijenaIznajmljivanja;
                            entity.FilmInformacije = FilmInformacije;
                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Uneseni podaci nisu validni!", "OK");
                }
            }
        }

        //Provjera unesenog datuma rezervacije do

        public async Task<bool> CheckRezervacijaDo(DateTime dateod,DateTime datedo)
        {
            TimeSpan brojDana = datedo - dateod;
            if (brojDana.Days >= 0)
                _provjera = true;
            if (datedo < DateTime.Now ||datedo<dateod)
                _provjera = false;
            return _provjera;
        }



    }
}
