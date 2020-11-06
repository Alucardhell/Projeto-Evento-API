using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Aplicacao.Mapping
{
    public class MappingModels : Profile
    {
        public MappingModels()
        {
            #region Evento
            CreateMap<Evento, EventoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventoID)).ReverseMap();
            #endregion

            #region Palestrante
            CreateMap<Palestrante, PalestranteDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PalestranteId)).ReverseMap();
            #endregion

            #region PalestranteEvento
            CreateMap<PalestranteEvento, PalestranteEventoDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            #endregion

            #region Lote
            CreateMap<Lote, LoteDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Loteid)).ReverseMap();
            #endregion

            #region RedeSocial
            CreateMap<RedeSocial, RedeSocialDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RedeSocialId)).ReverseMap();
            #endregion

        }
    }
}
