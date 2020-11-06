using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositorioPalestranteEvento : IRepositorioBase <PalestranteEvento>
    {
        List<Palestrante> ObterPalestrantePorEventoID(int id);
        List<Evento> ObterEventoPorPalestranteID(int id);
    }
}
