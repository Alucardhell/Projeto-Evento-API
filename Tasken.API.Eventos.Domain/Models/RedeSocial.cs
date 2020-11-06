using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain
{
    public class RedeSocial
    {
        public int RedeSocialId { get; set; }

        public string Nome { get; set; }

        public string Url { get; set; }

        public int? EventoId { get; set; }

        public int? PalestranteID { get; set; }
    }
}
