using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServicePalestranteEvento : ServiceBase<PalestranteEvento> , IServicesPalestranteEvento
    {
        private readonly IRepositorioPalestranteEvento _repositorioPalestranteEvento;

        public ServicePalestranteEvento(IRepositorioPalestranteEvento repositorioPalestranteEvento) : base (repositorioPalestranteEvento)
        {
            _repositorioPalestranteEvento = repositorioPalestranteEvento;
        }

        public List<Evento> ObterEventoPorPalestranteID(int id)
        {
            return _repositorioPalestranteEvento.ObterEventoPorPalestranteID(id);
        }

        public List<Palestrante> ObterPalestrantePorEventoID(int id)
        {
            return _repositorioPalestranteEvento.ObterPalestrantePorEventoID(id);
        }
    }
}
