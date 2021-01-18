using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Xamarin.Forms;


namespace Videoteka.MobileApp.ViewModels.Rezervacije
{
    public class RezervacijaDetaljiViewModel:BaseViewModel
    {
        private readonly APIService _ocjeneService = new APIService("Ocjena");
        private readonly APIService _klijentiService = new APIService("Klijent");
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _porukeService = new APIService("Poruka");
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");

        public RezervacijaDetaljiViewModel()
        {

        }


        public async Task OtkaziRezervaciju()
        {
            TimeSpan timeSpan = rezervacijaFilma.RezervacijaOd - DateTime.Now;
            //Moguće otkazati rezervaciju samo 2 dana prije početka rezervacije

            if (timeSpan.Days >= 2)
            {
                _provjera = true;
                RezervacijaFilmaUpsertRequest request = new RezervacijaFilmaUpsertRequest()
                {
                    RezervacijaFilmaId = rezervacijaFilma.RezervacijaFilmaId,
                    FilmId = rezervacijaFilma.FilmId,
                    DatumKreiranja = rezervacijaFilma.DatumKreiranja,
                    Iznos = rezervacijaFilma.Iznos,
                    RezervacijaOd = rezervacijaFilma.RezervacijaOd,
                    RezervacijaDo = rezervacijaFilma.RezervacijaDo,
                    IznosSaPopustom = rezervacijaFilma.IznosSaPopustom,
                    KlijentId = rezervacijaFilma.KlijentId,
                    RacunId = rezervacijaFilma.RacunId,
                    Opis = rezervacijaFilma.Opis,
                    Popust = rezervacijaFilma.Popust,
                    Otkazana = true
                };

                try
                {
                    var entity = await _rezervacijeService.Update<Model.Models.RezervacijaFilma>(rezervacijaFilma.RezervacijaFilmaId, request);

                    if (entity != null)
                    {
                        KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest();

                        //Slanje poruke samo korisnicima sa ulogom "Uposlenik"
                        List<string> uloge = new List<string>();
                        uloge.Add("Uposlenik");

                        korisniciSearch.Status = true;
                        korisniciSearch.uloge = uloge;

                        var korisnici = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);


                        foreach (var korisnik in korisnici)
                        {

                            var klijent = await _klijentiService.GetById<Model.Models.Klijent>(rezervacijaFilma.KlijentId);
                            var uposlenik = await _korisniciService.GetById<Model.Models.Korisnici>(korisnik.KorisnikId);

                            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest
                            {
                                RezervacijaFilmaId = rezervacijaFilma.RezervacijaFilmaId,
                                KlijentId = rezervacijaFilma.KlijentId,
                                UposlenikId = korisnik.KorisnikId,
                                DatumVrijeme = DateTime.Now,
                                Naslov = "Rezervacija otkazana",
                                Procitano = false,
                                Posiljaoc = "Uposlenik",
                                Sadrzaj = "Pozdrav " + uposlenik.Ime + " " + uposlenik.Prezime + ", \n"
                                         + " Rezervacija klijenta " + klijent.Ime + " " + klijent.Prezime
                                         + " kreirana dana " + rezervacijaFilma.DatumKreiranja.ToShortDateString()
                                         + " je otkazana."
                            };

                            //Slanje poruke za uposlenika sa UposlenikID
                            await _porukeService.Insert<Model.Models.Poruka>(porukaUpsert);
                        }


                    }

                }
                catch (Exception ex)
                {

                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

                }
            }
            else
            {
                _provjera = false;
                await Application.Current.MainPage.DisplayAlert("Greška", "Nije moguće otkazati rezervaciju koja počinje za manje od dva dana", "OK");
            }

        }

        public RezervacijaFilma rezervacijaFilma { get; set; }

        bool _provjera = false;
        public bool Provjera
        {
            get { return _provjera; }
            set { SetProperty(ref _provjera, value); }
        }
        public OcjenaUpsertRequest novaOcjena { get; set; } = new OcjenaUpsertRequest();

        public async Task DodajOcjenu(int RezervacijaID, float ocjena)
        {
            novaOcjena.Ocjena1 = (int)ocjena;
            novaOcjena.DatumEvidentiranja = DateTime.Now;
            novaOcjena.RezervacijaFilmaId = RezervacijaID;

            try
            {
                var entity = await _ocjeneService.Insert<Model.Models.Ocjena>(novaOcjena);
                var rezervacija = await _rezervacijeService.GetById<Model.Models.RezervacijaFilma>(RezervacijaID);

                if (entity != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste ocijenili rezervaciju", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");


            }
        }


    }
}
