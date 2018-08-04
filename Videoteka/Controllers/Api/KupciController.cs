using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Videoteka.Dtos;
using Videoteka.Models;

namespace Videoteka.Controllers.Api
{
    public class KupciController : ApiController
    {
        private ApplicationDbContext _context;
        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        //GET / api/kupci
        public IHttpActionResult GetKupci()
        {
            var kupacDtos = _context.Kupci
                .Include(c => c.TipClanstva)
                .ToList()
                .Select(Mapper.Map<Kupac, KupacDto>);

            return Ok(kupacDtos);
        }

        // GET /api/kupci/1
        public IHttpActionResult GetKupac(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupac == null)
                return NotFound();

            return Ok(Mapper.Map<Kupac, KupacDto>(kupac));
        }

        //POST /api/kupci
        [HttpPost]
        public IHttpActionResult IzradiKupac(KupacDto kupacDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var kupac = Mapper.Map<KupacDto, Kupac>(kupacDto);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();

            kupacDto.Id = kupac.Id;

            return Created(new Uri(Request.RequestUri + "/" + kupac.Id), kupacDto);
        }

        // PUT /api/kupci/1
        [HttpPut]
        public IHttpActionResult AzurirajKupac(int id, KupacDto kupacDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var kupacUDb = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupacUDb == null)
                return NotFound();

            Mapper.Map(kupacDto, kupacUDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/kupci/1
        [HttpDelete]
        public IHttpActionResult ObrisiKupac(int id)
        {
            var kupacUDb = _context.Kupci.SingleOrDefault(c => c.Id == id);

            if (kupacUDb == null)
                return NotFound();

            _context.Kupci.Remove(kupacUDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
