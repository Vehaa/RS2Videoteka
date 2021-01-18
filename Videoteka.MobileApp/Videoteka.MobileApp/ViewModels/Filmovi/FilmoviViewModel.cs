using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videoteka.MobileApp.Helper;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Xamarin.Forms;

namespace Videoteka.MobileApp.ViewModels.Filmovi
{
    public class FilmoviViewModel:BaseViewModel
    {
        private readonly APIService _filmService = new APIService("Film");
        private readonly APIService _zanroviService = new APIService("Zanr");
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _ocjeneService = new APIService("Ocjena");


        public ObservableCollection<Film> FilmoviList { get; set; } = new ObservableCollection<Film>();
        public ObservableCollection<Film> PreporuceniFilmovi { get; set; } = new ObservableCollection<Film>();
        public ObservableCollection<Zanr> Zanrovi { get; set; } = new ObservableCollection<Zanr>();

        public FilmoviViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        Zanr _selectedZanr = null;

        public Zanr SelectedZanr
        {
            get { return _selectedZanr; }
            set
            {
                SetProperty(ref _selectedZanr, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (Zanrovi.Count == 0)
            {
                var zanroviFilmovaList = await _zanroviService.Get<List<Zanr>>(null);

                foreach (var zanr in zanroviFilmovaList)
                {
                    Zanrovi.Add(zanr);
                }
            }

            FilmSearchRequest search = new FilmSearchRequest();

            if(SelectedZanr != null)
            {
                search.ZanrId = _selectedZanr.ZanrId;
            }
            search.Dostupan = true;

            var list = await _filmService.Get<IEnumerable<Film>>(search);
            FilmoviList.Clear();
            PreporuceniFilmovi.Clear();

            foreach (var film in list)
            {
                FilmoviList.Add(film);
                
            }
            

            // RECOMMENDER - Filmovi su prikazani po najvecoj prosjecnoj ocjeni

            FilmSearchRequest filmSearch = new FilmSearchRequest();
            filmSearch.Dostupan = true;
            OcjenaSearchRequest ocjenaSearch = new OcjenaSearchRequest();
            var ocjene = await _ocjeneService.Get<List<Model.Models.Ocjena>>(null);
            var sviFilmovi = await _filmService.Get<List<Model.Models.Film>>(filmSearch);
            RezervacijaFilmaSearchRequest rSearch = new RezervacijaFilmaSearchRequest
            {
                Otkazana = false
            };
            var sveRezervacije = await _rezervacijeService.Get<List<Model.Models.RezervacijaFilma>>(rSearch);

            List<Model.Models.Film> filmovi = new List<Model.Models.Film>();
            foreach (var f in sviFilmovi)
            {
                int brojac = 0;
                double suma = 0;
                double prosjek = 0;

                foreach (var r in sveRezervacije)
                {
                    
                    if (f.FilmId == r.FilmId)
                    {
                        foreach (var o in ocjene)
                        {
                            if (r.RezervacijaFilmaId == o.RezervacijaFilmaId)
                            {
                                brojac++;
                                suma += o.Ocjena1;
                            }
                        }
                    }
                }
                prosjek = suma / brojac;
                f.ProsjecnaOcjena = prosjek;
                filmovi.Add(f);
                
            }
            var result = filmovi.OrderByDescending(x => x.ProsjecnaOcjena).ToList();

            foreach (var item in result)
            {
                PreporuceniFilmovi.Add(item);
            }

        }
    }
}
