using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Required]
        public byte ZanrId { get; set; }

        public ZanrDto Zanr { get; set; }

        public DateTime DatumDodano { get; set; }

        public DateTime DatumIzlaska { get; set; }

        [Range(1, 20)]
        public byte BrojNaSkladistu { get; set; }
    }
}