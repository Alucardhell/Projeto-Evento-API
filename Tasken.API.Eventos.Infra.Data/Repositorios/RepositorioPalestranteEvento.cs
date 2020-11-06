using AcessoFacilSqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Models;
using Tasken.API.Eventos.Infra.Data.Contexto;

namespace Tasken.API.Eventos.Infra.Data.Repositorios
{
    public class RepositorioPalestranteEvento : RepositorioBase<PalestranteEvento>, IRepositorioPalestranteEvento
    {

        private readonly EventoContexto _eventoContexto;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositorioPalestranteEvento(EventoContexto eventoContexto, IConfiguration configuration) : base(eventoContexto)
        {
            _eventoContexto = eventoContexto;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Evento> ObterEventoPorPalestranteID(int id)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "Select * from Evento where EventoId in (select EventoId from PalestranteEvento where PalestranteId = @ID)";
                query.AdicionarParametro("ID", id);
                query.Abrir();

                var listaEventos = new List<Evento>();

                while (query.Proximo())
                {
                    listaEventos.Add(new Evento()
                    {
                        EventoID = query.ObterInteiro("EventoId"),
                        Local = query.ObterString("Local"),
                        DataEvento = query.ObterDateTime("DataEvento"),
                        Tema = query.ObterString("Tema"),
                        QtdPessoas = query.ObterInteiro("QtdPessoas"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterString("Telefone")
                    });
                }

                return listaEventos ?? null;
            }
        }

        public List<Palestrante> ObterPalestrantePorEventoID(int id)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "Select * from Palestrante where PalestranteID in (select PalestranteId from PalestranteEvento where EventoId = @ID)";
                query.AdicionarParametro("ID", id);
                query.Abrir();

                var listaPalestrantes = new List<Palestrante>();

                while (query.Proximo())
                {
                    listaPalestrantes.Add(new Palestrante()
                    {
                        PalestranteId = query.ObterInteiro("PalestranteId"),
                        Nome = query.ObterString("Nome"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterString("Telefone"),
                        Minicurriculo = query.ObterString("Minicurriculo"),
                        Email = query.ObterString("Email")
                    });
                }

                return listaPalestrantes ?? null;
            }
        }
    }
}