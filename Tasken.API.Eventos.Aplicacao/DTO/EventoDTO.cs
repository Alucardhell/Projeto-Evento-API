﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tasken.API.Eventos.Aplicacao.DTO
{
    public class EventoDTO : BaseDTO
    {
        public int EventoID { get; set; }
        public string Local { get; set; }

        public DateTime DataEvento { get; set; }

        public string Tema { get; set; }

        public int QtdPessoas { get; set; }

        public string ImagemUrl { get; set; }

        public string Telefone { get; set; }
    }
}
