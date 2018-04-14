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
        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
        public bool PretplacenNaNewsletter { get; set; }
        public TipClanstva TipClanstva { get; set; }
        public byte TipClanstvaId { get; set; }
    }
}