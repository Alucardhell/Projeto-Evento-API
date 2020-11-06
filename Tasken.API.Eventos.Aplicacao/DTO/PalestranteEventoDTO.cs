using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Aplicacao.DTO
{
    public class PalestranteEventoDTO : BaseDTO
    {
        public int Id { get; set; }

        public int PalestranteId { get; set; }

        public int EventoId { get; set; }
    }
}
