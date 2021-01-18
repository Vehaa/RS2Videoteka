using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videoteka.MobileApp.Views;
using Videoteka.MobileApp.Views.Filmovi;
using Videoteka.MobileApp.Views.Klijenti;
using Videoteka.Model.Requests;
using Videoteka.Model.Util;
using Xamarin.Forms;

namespace Videoteka.MobileApp.ViewModels.Klijenti
{
    public class LoginViewModel:BaseViewModel
    {

        private readonly APIService _serviceKlijent = new APIService("Klijent");
        public int KlijentID;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(() => Register());

        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public void Register()
        {
           Application.Current.MainPage = new RegistrationPage();

        }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                await _serviceKlijent.Get<List<dynamic>>(null);
                KlijentSearchRequest klijentSearch = new KlijentSearchRequest();
                klijentSearch.UserName = APIService.Username;
                klijentSearch.Status = true;

                var korisnici = await _serviceKlijent.Get<List<Model.Models.Klijent>>(klijentSearch);

                if (korisnici.Count > 0)
                {
                    var k = korisnici.FirstOrDefault();
                    string pwHash = GenerateHash(k.LozinkaSalt, APIService.Password);
                    
                    if (k.UserName == klijentSearch.UserName && k.Status==true && k.LozinkaHash==pwHash)
                    {
                        KlijentID = k.KlijentId;
                        Application.Current.MainPage = new MainPage(KlijentID);
                    }
                    else
                        throw new Exception("Unos nije ispravan");
                }
                else
                    throw new Exception("User ne postoji");

            }
            catch (Exception ex)
            {
                string msg = "";
                if (ex.InnerException != null)
                    msg = ex.InnerException.ToString() + " - ";
                await Application.Current.MainPage.DisplayAlert("Greška", msg + ex.Message, "OK");
            }
        }


        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
