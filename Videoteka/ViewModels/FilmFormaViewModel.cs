using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class FilmFormaViewModel
    {
        public IEnumerable<Zanr> Zanrovi { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Display(Name = "Žanr")]
        [Required]
        public byte? ZanrId { get; set; }

        [Display(Name = "Datum Izlaska")]
        [Required]
        public DateTime? DatumIzlaska { get; set; }

        [Display(Name = "Broj Na Skladištu")]
        [Range(1, 20)]
        [Required]
        public byte? BrojNaSkladistu { get; set; }

        public string Naslov

        {
            get
            {
                return Id != 0 ? "Uredi Film" : "Novi Film";
            }
        }

        public FilmFormaViewModel()
        {
            Id = 0;
        }

        public FilmFormaViewModel(Film film)
        {
            Id = film.Id;
            Naziv = film.Naziv;
            DatumIzlaska = film.DatumIzlaska;
            BrojNaSkladistu = film.BrojNaSkladistu;
            ZanrId = film.ZanrId;
        }
    }
}