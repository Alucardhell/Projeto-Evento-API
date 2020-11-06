using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServicesBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositoriBase;

        public ServiceBase(IRepositorioBase<TEntity> repositoriBase)
        {
            _repositoriBase = repositoriBase;
        }

        public void Adicionar(TEntity obj)
        {
            _repositoriBase.Adicionar(obj);
        }

        public void Alterar(TEntity obj)
        {
            _repositoriBase.Alterar(obj);
        }

        public void Deletar(TEntity obj)
        {
            _repositoriBase.Deletar(obj);
        }

        public void Dispose()
        {
            _repositoriBase.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            return _repositoriBase.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositoriBase.ObterTodos();
        }
    }
}
