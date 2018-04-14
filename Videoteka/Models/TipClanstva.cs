using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class TipClanstva
    {
        public byte Id { get; set; }
        public short PristojbaZaPrijavu { get; set; }
        public byte TrajanjeMjeseci { get; set; }
        public byte Popust { get; set; }
    }
}