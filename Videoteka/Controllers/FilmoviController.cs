using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class FilmoviController : Controller
    {
        public ViewResult Index()
        {
            var filmovi = GetFilmovi();

            return View(filmovi);    
        }

        private IEnumerable<Film> GetFilmovi()
        {
            return new List<Film>
            {
                new Film { Id = 1, Naziv = "Avatar" },
                new Film { Id = 2, Naziv = "Contact" }
            };
        }
        // GET: Filmovi/Random
        public ActionResult Random()
        {
            var film = new Film() { Naziv = "Spiderman" };
            var kupci = new List<Kupac>
            {
                new Kupac { Naziv = "Kupac 1" },
                new Kupac { Naziv = "Kupac 2" }

            };

            var viewModel = new RandomFilmViewModel
            {
                Film = film,
                Kupci = kupci
            };

            return View(viewModel);
        }

    }
}