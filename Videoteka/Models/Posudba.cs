using System;
using System.ComponentModel.DataAnnotations;
namespace Videoteka.Models
{
    public class Posudba
    {
        public int Id { get; set; }
        [Required]
        public Kupac Kupac { get; set; }
        [Required]
        public Film Film { get; set; }
        public DateTime DatumNajma { get; set; }
        public DateTime? DatumPovratka { get; set; }
    }
}