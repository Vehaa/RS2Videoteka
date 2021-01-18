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

namespace Videoteka.MobileApp.ViewModels
{
    public class PocetnaViewModel
    {
        private readonly APIService _filmService = new APIService("Film");
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _ocjeneService = new APIService("Ocjena");


        public ObservableCollection<Film> PreporuceniFilmovi { get; set; } = new ObservableCollection<Film>();


        public PocetnaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            PreporuceniFilmovi.Clear();

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
