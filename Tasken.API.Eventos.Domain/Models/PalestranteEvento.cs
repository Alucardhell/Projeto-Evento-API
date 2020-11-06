using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain.Models
{
    public class PalestranteEvento
    {
        public int Id { get; set; }

        public int PalestranteId { get; set; }

        public int EventoId { get; set; }

    }
}
