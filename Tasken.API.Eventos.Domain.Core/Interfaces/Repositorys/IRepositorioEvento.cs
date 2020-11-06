using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositorioEvento : IRepositorioBase<Evento>
    {
        Evento ObterPorTema(string tema);
        List<Evento> ObterPorData(DateTime data);
        List<Evento> ObterEntreData(DateTime dataInicio, DateTime dataFim);
    }
}
