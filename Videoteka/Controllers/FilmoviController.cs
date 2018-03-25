using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class FilmoviController : Controller
    {
        // GET: Filmovi/Random
        public ActionResult Random()
        {
            var film = new Film() { Naziv = "Spiderman" };
            return View(film);
        }
    }
}