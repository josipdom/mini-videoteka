using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;
using System.Data.Entity;
using Videoteka.Migrations;
using System.Data.Entity.Validation;

namespace Videoteka.Controllers
{
    public class FilmoviController : Controller
    {
        private ApplicationDbContext _context;

        public FilmoviController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole(NazivRole.UpravljanjeFilmovima))
                return View("Index");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = NazivRole.UpravljanjeFilmovima)]
        public ViewResult Novi()
        {
            var zanrovi = _context.Zanrovi.ToList();

            var viewModel = new FilmFormaViewModel
            {
                Zanrovi = zanrovi
            };

            return View("FilmForma", viewModel);
        }

        public ActionResult Uredi(int id)
        {
            var film = _context.Filmovi.SingleOrDefault(c => c.Id == id);

            if (film == null)
                return HttpNotFound();

            var viewModel = new FilmFormaViewModel(film)
            {
                Zanrovi = _context.Zanrovi.ToList()
            };

            return View("FilmForma", viewModel);
        }

        public ActionResult Detalji(int id)
        {
            var film = _context.Filmovi.Include(m => m.Zanr).SingleOrDefault(m => m.Id == id);
            
                     if (film == null)
                        return HttpNotFound();
            return View(film);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Spremi(Film film)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FilmFormaViewModel(film)
                {
                    Zanrovi = _context.Zanrovi.ToList()
                };

                return View("FilmForma", viewModel);
            }

            if (film.Id == 0)
            {
                film.DatumDodano = DateTime.Now;
                _context.Filmovi.Add(film);
            }
            else
            {
                var movieInDb = _context.Filmovi.Single(m => m.Id == film.Id);
                movieInDb.Naziv = film.Naziv;
                movieInDb.ZanrId = film.ZanrId;
                movieInDb.BrojNaSkladistu = film.BrojNaSkladistu;
                movieInDb.DatumIzlaska = film.DatumIzlaska;
            }

                _context.SaveChanges();

            return RedirectToAction("Index", "Filmovi");
        }

    }
}