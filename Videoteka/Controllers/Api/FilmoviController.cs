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
    public class FilmoviController : ApiController
    {
        private ApplicationDbContext _context;

        public FilmoviController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<FilmDto> GetFilmovi(string query = null)
        {
            var filmoviQuery = _context.Filmovi
               .Include(m => m.Zanr)
               .Where(m => m.BrojDostupnih > 0);

            if (!string.IsNullOrWhiteSpace(query))
                filmoviQuery = filmoviQuery.Where(m => m.Naziv.Contains(query));

            return filmoviQuery
               .ToList()
               .Select(Mapper.Map<Film, FilmDto>);
        }

        public IHttpActionResult GetFilm(int id)
        {
            var film = _context.Filmovi.SingleOrDefault(c => c.Id == id);

            if (film == null)
                return NotFound();

            return Ok(Mapper.Map<Film, FilmDto>(film));
        }

        [HttpPost]
        public IHttpActionResult IzradiFilm(FilmDto filmDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var film = Mapper.Map<FilmDto, Film>(filmDto);
            _context.Filmovi.Add(film);
            _context.SaveChanges();

            filmDto.Id = film.Id;
            return Created(new Uri(Request.RequestUri + "/" + film.Id), filmDto);
        }

        [HttpPut]
        public IHttpActionResult AzurirajFilm(int id, FilmDto filmDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var filmUDb = _context.Filmovi.SingleOrDefault(c => c.Id == id);

            if (filmUDb == null)
                return NotFound();

            Mapper.Map(filmDto, filmUDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult IzbrisiFilm(int id)
        {
            var filmUDb = _context.Filmovi.SingleOrDefault(c => c.Id == id);

            if (filmUDb == null)
                return NotFound();

            _context.Filmovi.Remove(filmUDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
