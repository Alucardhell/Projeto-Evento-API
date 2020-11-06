using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositorioPalestrante : IRepositorioBase<Palestrante>
    {
        List<Palestrante> ObterPorNome(string nome);
        List<Palestrante> ObterPorEmail(string email);
        List<Palestrante> ObterPorTelefone(string telefone);
    }
}
