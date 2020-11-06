using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Aplicacao.Services
{
    public class ApplicationServiceEvento : IApplicationServiceEvento
    {
        private readonly IServicesEvento _serviceEvento;
        private readonly IMapper _mapper;

        public ApplicationServiceEvento(IServicesEvento serviceEvento, IMapper mapper)
        {
            _serviceEvento = serviceEvento;
            _mapper = mapper;
        }

        public void Add(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);
            _serviceEvento.Adicionar(objEntity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventoDTO>> GetAll()
        {
            var objEntity = _serviceEvento.ObterTodos();
            return _mapper.Map<IEnumerable<EventoDTO>>(objEntity);
        }

        public EventoDTO GetById(int id)
        {
            var objEntity = _serviceEvento.ObterPorId(id);
            return _mapper.Map<EventoDTO>(objEntity);
        }

        public List<EventoDTO> ObterEntreData(DateTime dataInicio, DateTime dataFim)
        {
            var objEntity = _serviceEvento.ObterEntreData(dataInicio, dataFim);
            return _mapper.Map<List<EventoDTO>>(objEntity);
        }

        public List<EventoDTO> ObterPorData(DateTime data)
        {
            var objEntity = _serviceEvento.ObterPorData(data);
            return _mapper.Map<List<EventoDTO>>(objEntity);
        }

        public EventoDTO ObterPorTema(string tema)
        {
            var objEntity = _serviceEvento.ObterPorTema(tema);
            return _mapper.Map<EventoDTO>(objEntity);
        }

        public void Remove(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);
            _serviceEvento.Deletar(objEntity);
        }

        public void Update(EventoDTO obj)
        {
            var objEntity = _mapper.Map<Evento>(obj);
            _serviceEvento.Alterar(objEntity);
        }
    }
}
