using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.Dtos
{
    public class KupacDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje '{0}' je obavezno.")]
        [StringLength(255)]
        public string Naziv { get; set; }

        public bool PretplacenNaNewsletter { get; set; }

        [Required(ErrorMessage = "Polje '{0}' je obavezno.")]
        public byte TipClanstvaId { get; set; }

        public TipClanstvaDto TipClanstva { get; set; }


        //[Min18GodinaAkoSiClan]
        public DateTime? DatumRodenja { get; set; }
    }
}