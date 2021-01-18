using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnici");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;
        private int? _korisnikId=null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                string username = txtUsername.Text;

                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest();
                korisniciSearch.UserName = APIService.Username;
                korisniciSearch.Status = true;

                var korisnici = await _service.Get<List<Model.Models.Korisnici>>(korisniciSearch);


                var k = korisnici.FirstOrDefault();
                if (k == null)
                {
                    throw new Exception("Unos nije ispravan!");
                }
                if(k!=null && k.Status == false)
                {
                    throw new Exception("Vaš profil nije aktivan!");
                }
                else
                {
                    _korisnikId = k.KorisnikId;
                    string pwHash = GenerateHash(k.LozinkaSalt, APIService.Password);

                    // && k.LozinkaHash == pwHash
                    if (k.UserName == korisniciSearch.UserName )
                    {
                        this.Visible = false;

                        KorisniciUlogeSearchRequest korisniciUlogeSearch = new KorisniciUlogeSearchRequest()
                        {
                            KorisnikId = k.KorisnikId
                        };

                        //Dobavljanje svih uloga od korisnika
                        //inicijalizacija labele uloge logiranog korisnika
                        var uloge = await _korisniciUlogeService.Get<List<Model.Models.KorisniciUloge>>(korisniciUlogeSearch);
                        foreach (var uloga in uloge)
                        {
                            if (uloga.Uloga.Naziv == "Administrator")
                            {
                                ulogaAdmin = true;
                            }
                            else if (uloga.Uloga.Naziv == "Menadžer")
                            {
                                ulogaMenadzer = true;
                            }
                            else
                            {
                                ulogaUposlenik = true;
                            }

                        }


                        frmIndex frm = new frmIndex((int)_korisnikId, ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
                        frm.Show();
                    }
                    else
                        throw new Exception("Unos nije ispravan");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Authentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateHash(string salt, string password)
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
