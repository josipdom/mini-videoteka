using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class RandomFilmViewModel
    {
        public Film Film { get; set; }
        public List<Kupac> Kupci { get; set; }
    }
}