using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Aplicacao.DTO
{
    public class RedeSocialDTO : BaseDTO
    {
        public int RedeSocialId { get; set; }

        public string Nome { get; set; }

        public string Url { get; set; }

        public int? EventoId { get; set; }

        public int? PalestranteID { get; set; }
    }
}
