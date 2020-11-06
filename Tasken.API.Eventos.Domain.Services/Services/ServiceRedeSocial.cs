using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServiceRedeSocial : ServiceBase<RedeSocial>, IServicesRedeSocial
    {
        private readonly IRepositorioRedeSocial _repositorioRedeSocial;

        public ServiceRedeSocial(IRepositorioRedeSocial repositorioRedeSocial) : base (repositorioRedeSocial)
        {
            _repositorioRedeSocial = repositorioRedeSocial;
        }

        public List<RedeSocial> ObterPorEventoID(int id)
        {
            return _repositorioRedeSocial.ObterPorEventoID(id);
        }

        public List<RedeSocial> ObterPorPalestranteID(int id)
        {
            return _repositorioRedeSocial.ObterPorPalestranteID(id);
        }
    }
}
