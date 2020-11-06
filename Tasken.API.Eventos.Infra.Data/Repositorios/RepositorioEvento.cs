using AcessoFacilSqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Infra.Data.Contexto;

namespace Tasken.API.Eventos.Infra.Data.Repositorios
{
    public class RepositorioEvento : RepositorioBase<Evento>, IRepositorioEvento
    {
        private readonly EventoContexto _eventoContexto;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositorioEvento(EventoContexto eventoContexto, IConfiguration configuration) : base(eventoContexto)
        {
            _eventoContexto = eventoContexto;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Evento> ObterEntreData(DateTime dataInicio, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM EVENTO (NOLOCK) " +
                               "WHERE DataEvento BETWEEN @DATAINI AND @DATAFIM ";
                query.AdicionarParametro("DATAINI", dataInicio);
                query.AdicionarParametro("DATAFIM", dataFim);
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

        public List<Evento> ObterPorData(DateTime data)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM EVENTO (NOLOCK) " +
               "WHERE DataEvento = @DATA";
                query.AdicionarParametro("DATA", data);
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

        public Evento ObterPorTema(string tema)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM EVENTO (NOLOCK) " +
               "WHERE Tema = @TEMA";
                query.AdicionarParametro("TEMA", tema);
                query.Abrir();

                query.Proximo();
                if (query.RetornouDados())
                {
                    return new Evento()
                    {
                        EventoID = query.ObterInteiro("EventoId"),
                        Local = query.ObterString("Local", true),
                        DataEvento = query.ObterDateTime("DataEvento"),
                        Tema = query.ObterString("Tema", true),
                        QtdPessoas = query.ObterInteiro("QtdPessoas"),
                        ImagemUrl = query.ObterString("ImagemUrl", true),
                        Telefone = query.ObterString("Telefone", true)
                    };
                }

                return null;
            }
        }
    }
}
