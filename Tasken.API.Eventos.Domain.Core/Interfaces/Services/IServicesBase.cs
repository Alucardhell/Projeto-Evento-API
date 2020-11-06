using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Services
{
    public interface IServicesBase<TEntity> where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Deletar(TEntity obj);
        void Dispose();
    }
}
