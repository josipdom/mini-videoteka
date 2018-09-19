using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using Videoteka.Dtos;
using Videoteka.Models;

namespace Videoteka.Controllers.Api
{
    public class NovaPosudbaController : ApiController
    {
        private ApplicationDbContext _context;

        public NovaPosudbaController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NovaPosudbaDto novaPosudba)
        {
            var kupac = _context.Kupci.Single(
                c => c.Id == novaPosudba.KupacId);

            var filmovi = _context.Filmovi.Where(
                m => novaPosudba.FilmIds.Contains(m.Id)).ToList();

            foreach (var film in filmovi)
            {
                if (film.BrojDostupnih == 0)
                    return BadRequest("Film nije dostupan.");

                film.BrojDostupnih--;

                var posudba = new Posudba
                {
                    Kupac = kupac,
                    Film = film,
                    DatumNajma = DateTime.Now
                };

                _context.Posudbe.Add(posudba);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

            return Ok();
        }
    }
}