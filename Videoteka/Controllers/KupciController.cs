using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Videoteka.Models;

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
        public ViewResult Index()
        {
            var kupci = _context.Kupci.ToList();

            return View(kupci);
        }

        public ActionResult Detalji(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupac == null)
                return HttpNotFound();

            return View(kupac);
        }
   }
} 