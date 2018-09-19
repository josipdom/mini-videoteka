using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoteka.Dtos
{
    public class NovaPosudbaDto
    {
        public int KupacId { get; set; }
        public List<int> FilmIds { get; set; }
    }
}