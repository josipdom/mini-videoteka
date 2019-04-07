using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;
using System.Data.Entity;

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
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = NazivRole.UpravljanjeFilmovima)]
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
                film.BrojDostupnih = film.BrojNaSkladistu;
                _context.Filmovi.Add(film);
            }
            else
            {
                var filmDb = _context.Filmovi.Single(m => m.Id == film.Id);
                filmDb.Naziv = film.Naziv;
                filmDb.ZanrId = film.ZanrId;
                filmDb.BrojNaSkladistu = film.BrojNaSkladistu;
                filmDb.DatumIzlaska = film.DatumIzlaska;
                film.BrojDostupnih = film.BrojNaSkladistu;
            }

                _context.SaveChanges();

            return RedirectToAction("Index", "Filmovi");
        }

    }
}