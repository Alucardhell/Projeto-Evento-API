﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Core.Interfaces.Services
{
    public interface IServicesLote : IServicesBase<Lote>
    {
        List<Lote> ObterPorEvento(string eventoTema);
        List<Lote> ObterPorPreco(double precoMinimo, double precoMaximo);
        List<Lote> ObterPorDataInicio(DateTime dataInicio);
        List<Lote> ObterPorDataFim(DateTime dataFim);
        List<Lote> ObterEntreDatas(DateTime dataInicio, DateTime dataFim);
    }
}
