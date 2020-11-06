using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServicePalestrante : ServiceBase<Palestrante>, IServicesPalestrante
    {
        private readonly IRepositorioPalestrante _repositoriPalestrante;

        public ServicePalestrante(IRepositorioPalestrante repositoriPalestrante) : base(repositoriPalestrante)
        {
            _repositoriPalestrante = repositoriPalestrante;
        }

        public List<Palestrante> ObterPorEmail(string email)
        {
            return _repositoriPalestrante.ObterPorEmail(email);
        }

        public List<Palestrante> ObterPorNome(string nome)
        {
            return _repositoriPalestrante.ObterPorNome(nome);
        }

        public List<Palestrante> ObterPorTelefone(string telefone)
        {
            return _repositoriPalestrante.ObterPorTelefone(telefone);
        }
    }
}
