using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Kupac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje '{0}' je obavezno.")]
        [StringLength(255)]
        [Display(Name = "Ime i Prezime")]
        public string Naziv { get; set; }

        public bool PretplacenNaNewsletter { get; set; }

        public TipClanstva TipClanstva { get; set; }

        [Required(ErrorMessage = "Polje '{0}' je obavezno.")]
        [Display(Name = "Tip Clanstva")]
        public byte TipClanstvaId { get; set; }

        [Display(Name = "Datum Rodenja")]
        [Min18GodinaAkoSiClan]
        public DateTime? DatumRodenja { get; set; }
    }
}