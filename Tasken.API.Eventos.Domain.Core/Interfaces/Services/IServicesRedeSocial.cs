using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Services
{
    public interface IServicesRedeSocial : IServicesBase<RedeSocial>
    {
        List<RedeSocial> ObterPorPalestranteID(int id);
        List<RedeSocial> ObterPorEventoID(int id);
    }
}
