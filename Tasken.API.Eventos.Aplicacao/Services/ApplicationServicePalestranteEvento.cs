using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Aplicacao.Services
{
    public class ApplicationServicePalestranteEvento : IApplicationServicePalestranteEvento
    {
        private readonly IServicesPalestranteEvento _servicePalestranteEvento;
        private readonly IMapper _mapper;

        public ApplicationServicePalestranteEvento(IServicesPalestranteEvento servicePalestranteEvento, IMapper mapper)
        {
            _servicePalestranteEvento = servicePalestranteEvento;
            _mapper = mapper;
        }

        public void Add(PalestranteEventoDTO obj)
        {
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicePalestranteEvento.Adicionar(objEntity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PalestranteEventoDTO> GetAll()
        {
            var objEntity = _servicePalestranteEvento.ObterTodos();
            return _mapper.Map<IEnumerable<PalestranteEventoDTO>>(objEntity);
        }

        public PalestranteEventoDTO GetById(int id)
        {
            var objEntity = _servicePalestranteEvento.ObterPorId(id);
            return _mapper.Map<PalestranteEventoDTO>(objEntity);
        }

        public List<EventoDTO> ObterEventoPorPalestranteID(int id)
        {
            var objEntity = _servicePalestranteEvento.ObterEventoPorPalestranteID(id);
            return _mapper.Map<List<EventoDTO>>(objEntity);
        }

        public List<PalestranteDTO> ObterPalestrantePorEventoID(int id)
        {
            var objEntity = _servicePalestranteEvento.ObterPalestrantePorEventoID(id);
            return _mapper.Map<List<PalestranteDTO>>(objEntity);
        }

        public void Remove(PalestranteEventoDTO obj)
        {
            
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicePalestranteEvento.Deletar(objEntity);
        }

        public void Update(PalestranteEventoDTO obj)
        {         
            var objEntity = _mapper.Map<PalestranteEvento>(obj);
            _servicePalestranteEvento.Alterar(objEntity);
        }
    }
}
