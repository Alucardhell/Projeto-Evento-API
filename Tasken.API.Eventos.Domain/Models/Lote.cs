using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Domain
{
    public class Lote
    {
        public int Loteid { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }

        public int EventoId { get; set; }

    }
}
