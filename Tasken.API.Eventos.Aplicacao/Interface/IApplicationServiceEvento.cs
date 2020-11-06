using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;

namespace Tasken.API.Eventos.Aplicacao.Interface
{
    public interface IApplicationServiceEvento
    {
        EventoDTO GetById(int id);
        Task<IEnumerable<EventoDTO>> GetAll();
        void Add(EventoDTO obj);
        void Update(EventoDTO obj);
        void Remove(EventoDTO obj);
        void Dispose();
        List<EventoDTO> ObterEntreData(DateTime dataInicio, DateTime dataFim);
        List<EventoDTO> ObterPorData(DateTime data);
        EventoDTO ObterPorTema(string tema);
    }
}
