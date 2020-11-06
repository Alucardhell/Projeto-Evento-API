using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Services
{
    public interface IServicesPalestrante : IServicesBase<Palestrante>
    {
        List<Palestrante> ObterPorNome(string nome);
        List<Palestrante> ObterPorEmail(string email);
        List<Palestrante> ObterPorTelefone(string telefone);
    }
}
