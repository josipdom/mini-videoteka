using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Zanr
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
    }
}