using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;

namespace Tasken.API.Eventos.Aplicacao.Interface
{
    public interface IApplicationServicePalestrante
    {
        PalestranteDTO GetById(int id);

        Task<IEnumerable<PalestranteDTO>> GetAll();
        void Add(PalestranteDTO obj);
        void Update(PalestranteDTO obj);
        void Remove(PalestranteDTO obj);
        void Dispose();
        List<PalestranteDTO> ObterPorNome(string nome);
        List<PalestranteDTO> ObterPorEmail(string email);
        List<PalestranteDTO> ObterPorTelefone(string telefone);
    }
}
