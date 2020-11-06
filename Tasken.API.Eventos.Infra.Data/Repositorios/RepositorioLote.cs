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
    public class RepositorioLote : RepositorioBase<Lote>, IRepositorioLote
    {
        private readonly EventoContexto _eventoContexto;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositorioLote(EventoContexto eventoContexto, IConfiguration configuration) : base(eventoContexto)
        {
            _eventoContexto = eventoContexto;
            _configuration = configuration;
            _stringConexao = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Lote> ObterEntreDatas(DateTime dataInicio, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM lote (NOLOCK) " +
                    "WHERE DataInicio >= @DATAINI and DataFim <= @DATAFIM";
                query.AdicionarParametro("DATAINI", dataInicio);
                query.AdicionarParametro("DATAFIM", dataFim);
                query.Abrir();

                var listaLote = new List<Lote>();

                while (query.Proximo())
                {
                    listaLote.Add(new Lote()
                    {
                        Loteid = query.ObterInteiro("Loteid"),
                        Nome = query.ObterString("Nome"),
                        Preco = query.ObterFloat("Preco"),
                        DataInicio = query.ObterDateTime("DataInicio"),
                        DataFim = query.ObterDateTime("DataFim"),
                        Quantidade = query.ObterInteiro("Quantidade"),
                        EventoId = query.ObterInteiro("EventoId")
                    });
                }

                return listaLote ?? null;
            }

        }

        public List<Lote> ObterPorDataFim(DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM lote (NOLOCK) " +
                    "WHERE DataInicio >= GETDATE() AND DataFim <= @DATAFIM";
                query.AdicionarParametro("DATAFIM", dataFim);
                query.Abrir();

                var listaLote = new List<Lote>();

                while (query.Proximo())
                {
                    listaLote.Add(new Lote()
                    {
                        Loteid = query.ObterInteiro("Loteid"),
                        Nome = query.ObterString("Nome"),
                        Preco = query.ObterFloat("Preco"),
                        DataInicio = query.ObterDateTime("DataInicio"),
                        DataFim = query.ObterDateTime("DataFim"),
                        Quantidade = query.ObterInteiro("Quantidade"),
                        EventoId = query.ObterInteiro("EventoId")
                    });
                }

                return listaLote ?? null;
            }
        }

        public List<Lote> ObterPorDataInicio(DateTime dataInicio)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM lote (NOLOCK) " +
                    "WHERE DataInicio > @DATAINI";
                query.AdicionarParametro("DATAINI", dataInicio);
                query.Abrir();

                var listaLote = new List<Lote>();

                while (query.Proximo())
                {
                    listaLote.Add(new Lote()
                    {
                        Loteid = query.ObterInteiro("Loteid"),
                        Nome = query.ObterString("Nome"),
                        Preco = query.ObterFloat("Preco"),
                        DataInicio = query.ObterDateTime("DataInicio"),
                        DataFim = query.ObterDateTime("DataFim"),
                        Quantidade = query.ObterInteiro("Quantidade"),
                        EventoId = query.ObterInteiro("EventoId")
                    });
                }

                return listaLote ?? null;
            }
        }

        public List<Lote> ObterPorEvento(string eventoTema)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT E.Tema, L.Loteid, L.Nome, L.Preco, L.DataInicio, L.DataFim, L.Quantidade, L.EventoId FROM LOTE " +
                    "as L INNER JOIN EVENTO as E on L.EventoId = E.EventoId where E.Tema = @EVTEMA order by L.EventoId";
                query.AdicionarParametro("EVTEMA", eventoTema);
                query.Abrir();

                var listaLote = new List<Lote>();

                while (query.Proximo())
                {
                    listaLote.Add(new Lote()
                    {
                        Loteid = query.ObterInteiro("Loteid"),
                        Nome = query.ObterString("Nome"),
                        Preco = query.ObterFloat("Preco"),
                        DataInicio = query.ObterDateTime("DataInicio"),
                        DataFim = query.ObterDateTime("DataFim"),
                        Quantidade = query.ObterInteiro("Quantidade"),
                        EventoId = query.ObterInteiro("EventoId")
                    });
                }

                return listaLote ?? null;
            }
        }

        public List<Lote> ObterPorPreco(double precoMinimo, double precoMaximo)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM lote (NOLOCK) WHERE Preco BETWEEN @PRECOMI AND @PRECOMAX";
                query.AdicionarParametro("PRECOMI", precoMinimo);
                query.AdicionarParametro("PRECOMAX", precoMaximo);
                query.Abrir();

                var listaLote = new List<Lote>();

                while (query.Proximo())
                {
                    listaLote.Add(new Lote()
                    {
                        Loteid = query.ObterInteiro("Loteid"),
                        Nome = query.ObterString("Nome"),
                        Preco = query.ObterFloat("Preco"),
                        DataInicio = query.ObterDateTime("DataInicio"),
                        DataFim = query.ObterDateTime("DataFim"),
                        Quantidade = query.ObterInteiro("Quantidade"),
                        EventoId = query.ObterInteiro("EventoId")
                    });
                }

                return listaLote ?? null;
            }
        }
    }
}
