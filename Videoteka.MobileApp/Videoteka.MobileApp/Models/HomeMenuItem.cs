using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.MobileApp.Models
{
    public enum MenuItemType
    {
        KorisnickiProfil,
        Poruke,
        MojeRezervacije,
        Filmovi,
        OdjaviSe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string IconSource { get; set; }

    }
}
