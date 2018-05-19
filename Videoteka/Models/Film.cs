using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Required]
        public Zanr Zanr { get; set; }

        [Display(Name = "Zanr")]
        [Required]
        public byte ZanrId { get; set; }

        [Required]
        public DateTime DatumDodano { get; set; }

        [Required]
        [Display(Name = "Datum Izlaska")]
        public DateTime DatumIzlaska { get; set; }

        [Required]
        [Display(Name = "Broj Na Skladistu")]
        [Range(1, 20)]
        public byte BrojNaSkladistu { get; set; }
    }
}