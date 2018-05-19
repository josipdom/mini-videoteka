using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Videoteka.Models;
using System.Data.Entity;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class KupciController : Controller
    {
        private ApplicationDbContext _context;

        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Novi()
        {
            var tipoviClanstva = _context.TipoviClanstva.ToList();
            var viewModel = new KupacFormaViewModel
            {
                Kupac = new Kupac(),
                TipoviClanstva = tipoviClanstva
            };
            return View("KupacForma", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Spremi(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KupacFormaViewModel
                {
                    Kupac = kupac,
                    TipoviClanstva = _context.TipoviClanstva.ToList()
                };
                return View("KupacForma", viewModel);
            }

            if (kupac.Id == 0)
                _context.Kupci.Add(kupac);
            else
            {
                var kupacUDb = _context.Kupci.Single(c => c.Id == kupac.Id);
                kupacUDb.Naziv = kupac.Naziv;
                kupacUDb.DatumRodenja = kupac.DatumRodenja;
                kupacUDb.TipClanstvaId = kupac.TipClanstvaId;
                kupacUDb.PretplacenNaNewsletter = kupac.PretplacenNaNewsletter;

            }

            //_context.Kupci.Add(kupac);
            _context.SaveChanges();

            return RedirectToAction("Index", "Kupci");
        }

        public ActionResult Uredi(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupac == null)
                return HttpNotFound();

            var viewModel = new KupacFormaViewModel
            {
                Kupac = kupac,
                TipoviClanstva = _context.TipoviClanstva.ToList()
            };
            return View("KupacForma", viewModel);
        }

        public ViewResult Index()
        {
            var kupci = _context.Kupci.Include(c => c.TipClanstva).ToList();

            return View(kupci);
        }

        public ActionResult Detalji(int id)
        {
            var kupac = _context.Kupci.Include(c => c.TipClanstva).SingleOrDefault(c => c.Id == id);

            if (kupac == null)
                return HttpNotFound();

            return View(kupac);
        }
   }
} 