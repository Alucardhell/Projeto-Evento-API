using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositorioRedeSocial : IRepositorioBase<RedeSocial>
    {
        List<RedeSocial> ObterPorPalestranteID(int id);
        List<RedeSocial> ObterPorEventoID(int id);
    }
}
