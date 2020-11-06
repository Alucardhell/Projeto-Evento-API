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
    public class ApplicationServiceRedeSocial : IApplicationServiceRedeSocial
    {
        private readonly IServicesRedeSocial _serviceRedeSocial;
        private readonly IMapper _mapper;

        public ApplicationServiceRedeSocial(IServicesRedeSocial serviceRedeSocial, IMapper mapper)
        {
            _serviceRedeSocial = serviceRedeSocial;
            _mapper = mapper;
        }

        public void Add(RedeSocialDTO obj)
        {
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _serviceRedeSocial.Adicionar(objEntity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RedeSocialDTO> GetAll()
        {
            var objEntity = _serviceRedeSocial.ObterTodos();
            return _mapper.Map<IEnumerable<RedeSocialDTO>>(objEntity);
        }

        public RedeSocialDTO GetById(int id)
        {
            var objEntity = _serviceRedeSocial.ObterPorId(id);
            return _mapper.Map<RedeSocialDTO>(objEntity);
        }

        public List<RedeSocialDTO> ObterPorEventoID(int id)
        {
            var objEntity = _serviceRedeSocial.ObterPorEventoID(id);
            return _mapper.Map<List<RedeSocialDTO>>(objEntity);
        }

        public List<RedeSocialDTO> ObterPorPalestranteID(int id)
        {
            var objEntity = _serviceRedeSocial.ObterPorPalestranteID(id);
            return _mapper.Map<List<RedeSocialDTO>>(objEntity);
        }

        public void Remove(RedeSocialDTO obj)
        {
            
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _serviceRedeSocial.Deletar(objEntity);
        }

        public void Update(RedeSocialDTO obj)
        {
            
            var objEntity = _mapper.Map<RedeSocial>(obj);
            _serviceRedeSocial.Alterar(objEntity);
        }
    }
}
