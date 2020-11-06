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
    public class ApplicationServicePalestrante : IApplicationServicePalestrante
    {
        private readonly IServicesPalestrante _servicePalestrante;
        private readonly IMapper _mapper;

        public ApplicationServicePalestrante(IServicesPalestrante servicePalestrante, IMapper mapper)
        {
            _servicePalestrante = servicePalestrante;
            _mapper = mapper;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Add(PalestranteDTO obj)
        {
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicePalestrante.Adicionar(objEntity);
        }

        public async Task<IEnumerable<PalestranteDTO>> GetAll()
        {
            var objEntity = _servicePalestrante.ObterTodos();
            return _mapper.Map<IEnumerable<PalestranteDTO>>(objEntity);
        }

        public PalestranteDTO GetById(int id)
        {
            var objEntity = _servicePalestrante.ObterPorId(id);
            return _mapper.Map<PalestranteDTO>(objEntity);
        }

        public void Remove(PalestranteDTO obj)
        {
            
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicePalestrante.Deletar(objEntity);
        }

        public void Update(PalestranteDTO obj)
        {           
            var objEntity = _mapper.Map<Palestrante>(obj);
            _servicePalestrante.Alterar(objEntity);
        }

        public List<PalestranteDTO> ObterPorNome(string nome)
        {
            var objEntity = _servicePalestrante.ObterPorNome(nome);
            return _mapper.Map<List<PalestranteDTO>>(objEntity);
        }

        public List<PalestranteDTO> ObterPorEmail(string email)
        {
            var objEntity = _servicePalestrante.ObterPorEmail(email);
            return _mapper.Map<List<PalestranteDTO>>(objEntity);
        }

        public List<PalestranteDTO> ObterPorTelefone(string telefone)
        {
            var objEntity = _servicePalestrante.ObterPorTelefone(telefone);
            return _mapper.Map<List<PalestranteDTO>>(objEntity);
        }
    }
}
