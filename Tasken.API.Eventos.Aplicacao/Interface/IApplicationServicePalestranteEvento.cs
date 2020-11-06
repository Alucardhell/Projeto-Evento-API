using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;

namespace Tasken.API.Eventos.Aplicacao.Interface
{
    public interface IApplicationServicePalestranteEvento
    {
        PalestranteEventoDTO GetById(int id);
        IEnumerable<PalestranteEventoDTO> GetAll();
        void Add(PalestranteEventoDTO obj);
        void Update(PalestranteEventoDTO obj);
        void Remove(PalestranteEventoDTO obj);
        void Dispose();
        List<PalestranteDTO> ObterPalestrantePorEventoID(int id);
        List<EventoDTO> ObterEventoPorPalestranteID(int id);
    }
}
