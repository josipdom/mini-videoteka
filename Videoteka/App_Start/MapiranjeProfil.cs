using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Videoteka.Models;
using Videoteka.Dtos;

namespace Videoteka.App_Start
{
    public class MapiranjeProfil : Profile
    {
        public MapiranjeProfil()
        {
            // Domena do Dto
            Mapper.CreateMap<Kupac, KupacDto>();
            Mapper.CreateMap<Film, FilmDto>();
            Mapper.CreateMap<TipClanstva, TipClanstvaDto>();
            Mapper.CreateMap<Zanr, ZanrDto>();

            // Dto do Domena
            Mapper.CreateMap<KupacDto, Kupac>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<FilmDto, Film>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}