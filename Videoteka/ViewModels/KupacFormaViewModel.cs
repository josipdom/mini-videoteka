using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class KupacFormaViewModel
    {
        public IEnumerable<TipClanstva> TipoviClanstva { get; set; }
        public Kupac Kupac { get; set; }
    }
}