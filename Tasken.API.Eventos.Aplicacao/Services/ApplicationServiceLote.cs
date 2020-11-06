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
    public class ApplicationServiceLote : IApplicationServiceLote
    {
        private readonly IServicesLote _serviceLote;
        private readonly IMapper _mapper;

        public ApplicationServiceLote(IServicesLote serviceLote, IMapper mapper)
        {
            _serviceLote = serviceLote;
            _mapper = mapper;
        }

        public void Add(LoteDTO obj)
        {
            var objEntity = _mapper.Map<Lote>(obj);
            _serviceLote.Adicionar(objEntity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoteDTO> GetAll()
        {
            var objEntity = _serviceLote.ObterTodos();
            return _mapper.Map<IEnumerable<LoteDTO>>(objEntity);
        }

        public LoteDTO GetById(int id)
        {
            var objEntity = _serviceLote.ObterPorId(id);
            return _mapper.Map<LoteDTO>(objEntity);
        }

        public List<LoteDTO> ObterEntreDatas(DateTime dataInicio, DateTime dataFim)
        {
            var objEntity = _serviceLote.ObterEntreDatas(dataInicio, dataFim);
            return _mapper.Map<List<LoteDTO>>(objEntity);
        }

        public List<LoteDTO> ObterPorDataFim(DateTime dataFim)
        {
            var objEntity = _serviceLote.ObterPorDataFim(dataFim);
            return _mapper.Map<List<LoteDTO>>(objEntity);
        }

        public List<LoteDTO> ObterPorDataInicio(DateTime dataInicio)
        {
            var objEntity = _serviceLote.ObterPorDataInicio(dataInicio);
            return _mapper.Map<List<LoteDTO>>(objEntity);
        }

        public List<LoteDTO> ObterPorEvento(string eventoTema)
        {
            var objEntity = _serviceLote.ObterPorEvento(eventoTema);
            return _mapper.Map<List<LoteDTO>>(objEntity);
        }

        public List<LoteDTO> ObterPorPreco(double precoMinimo, double precoMaximo)
        {
            var objEntity = _serviceLote.ObterPorPreco(precoMinimo, precoMaximo);
            return _mapper.Map<List<LoteDTO>>(objEntity);
        }

        public void Remove(LoteDTO obj)
        {
            var objEntity = _mapper.Map<Lote>(obj);
            _serviceLote.Deletar(objEntity);
        }

        public void Update(LoteDTO obj)
        {           
            var objEntity = _mapper.Map<Lote>(obj);
            _serviceLote.Alterar(objEntity);
        }
    }
}
