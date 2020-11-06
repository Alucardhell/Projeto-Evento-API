using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;

namespace Tasken.API.Eventos.Aplicacao.Interface
{
    public interface IApplicationServiceRedeSocial
    {
        RedeSocialDTO GetById(int id);
        IEnumerable<RedeSocialDTO> GetAll();
        void Add(RedeSocialDTO obj);
        void Update(RedeSocialDTO obj);
        void Remove(RedeSocialDTO obj);
        void Dispose();
        List<RedeSocialDTO> ObterPorPalestranteID(int id);
        List<RedeSocialDTO> ObterPorEventoID(int id);
    }
}
