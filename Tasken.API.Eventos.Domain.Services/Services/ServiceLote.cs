using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;

namespace Tasken.API.Eventos.Domain.Services.Services
{
    public class ServiceLote : ServiceBase<Lote>, IServicesLote
    {
        private readonly IRepositorioLote _repositorioLote;

        public ServiceLote(IRepositorioLote repositorioLote) : base(repositorioLote)
        {
            _repositorioLote = repositorioLote;
        }

        public List<Lote> ObterEntreDatas(DateTime dataInicio, DateTime dataFim)
        {
            return _repositorioLote.ObterEntreDatas(dataInicio, dataFim);
        }

        public List<Lote> ObterPorDataFim(DateTime dataFim)
        {
            return _repositorioLote.ObterPorDataFim(dataFim);
        }

        public List<Lote> ObterPorDataInicio(DateTime dataInicio)
        {
            return _repositorioLote.ObterPorDataInicio(dataInicio);
        }

        public List<Lote> ObterPorEvento(string eventoTema)
        {
            return _repositorioLote.ObterPorEvento(eventoTema);
        }

        public List<Lote> ObterPorPreco(double precoMinimo, double precoMaximo)
        {
            return _repositorioLote.ObterPorPreco(precoMinimo, precoMaximo);
        }
    }
}
