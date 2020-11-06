using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain
{
    public class Palestrante
    {
        public int PalestranteId { get; set; }
        public string Nome { get; set; }

        public string ImagemUrl { get; set; }

        public string Telefone { get; set; }

        public string Minicurriculo { get; set; }

        public string Email { get; set; }

    }
}
