using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;

namespace Tasken.API.Eventos.Aplicacao.Interface
{
    public interface IApplicationServiceLote
    {
        LoteDTO GetById(int id);
        IEnumerable<LoteDTO> GetAll();
        void Add(LoteDTO obj);
        void Update(LoteDTO obj);
        void Remove(LoteDTO obj);
        void Dispose();
        List<LoteDTO> ObterPorEvento(string eventoTema);
        List<LoteDTO> ObterPorPreco(double precoMinimo, double precoMaximo);
        List<LoteDTO> ObterPorDataInicio(DateTime dataInicio);
        List<LoteDTO> ObterPorDataFim(DateTime dataFim);
        List<LoteDTO> ObterEntreDatas(DateTime dataInicio, DateTime dataFim);
    }
}
