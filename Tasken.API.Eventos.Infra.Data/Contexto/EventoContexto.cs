using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Infra.Data.Contexto
{

    public class EventoContexto : DbContext
    {
        public EventoContexto()
        {
           
        }

        public EventoContexto(DbContextOptions<EventoContexto> options) : base(options)
        {
        }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
    }
}
