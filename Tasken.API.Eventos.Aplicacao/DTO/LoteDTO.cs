using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Aplicacao.DTO
{
    public class LoteDTO : BaseDTO
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }

        public int EventoId { get; set; }
    }
}
