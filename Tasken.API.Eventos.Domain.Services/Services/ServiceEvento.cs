using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServiceEvento : ServiceBase<Evento>, IServicesEvento
    {
        private readonly IRepositorioEvento _repositoriEvento;

        public ServiceEvento(IRepositorioEvento repositoriEvento) : base(repositoriEvento)
        {
            _repositoriEvento = repositoriEvento;
        }

        public Evento ObterPorTema(string tema)
        {
            return _repositoriEvento.ObterPorTema(tema);
        }

        List<Evento> IServicesEvento.ObterEntreData(DateTime dataInicio, DateTime dataFim)
        {
            return _repositoriEvento.ObterEntreData(dataInicio, dataFim);
        }

        List<Evento> IServicesEvento.ObterPorData(DateTime data)
        {
            return _repositoriEvento.ObterPorData(data);
        }
    }
}
