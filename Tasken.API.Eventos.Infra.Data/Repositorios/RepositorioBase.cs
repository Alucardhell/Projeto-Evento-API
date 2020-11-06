using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Infra.Data.Contexto;

namespace Tasken.API.Eventos.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly EventoContexto _eventoContexto;

        public RepositorioBase(EventoContexto eventoContexto)
        {
            _eventoContexto = eventoContexto;
        }

        public void Dispose()
        {
            _eventoContexto.Dispose();
        }
        public void Adicionar(TEntity obj)
        {
            _eventoContexto.Add(obj);
            _eventoContexto.SaveChanges();
        }

        public void Alterar(TEntity obj)
        {
            _eventoContexto.Update(obj);
            _eventoContexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _eventoContexto.SaveChanges();
        }

        public void Deletar(TEntity obj)
        {
            _eventoContexto.Remove(obj);
            _eventoContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return _eventoContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _eventoContexto.Set<TEntity>().AsNoTracking().ToList();
        }
    }
}
