using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Videoteka.Models
{
    public class TipClanstva
    {
        [Required]
        public string Naziv { get; set; }
        public byte Id { get; set; }
        public short PristojbaZaPrijavu { get; set; }
        public byte TrajanjeMjeseci { get; set; }
        public byte Popust { get; set; }

        public static readonly byte Nepoznato = 0;
        public static readonly byte PlatiOdmah = 1;
    }
}