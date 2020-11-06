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
    public class RepositorioRedeSocial : RepositorioBase<RedeSocial>, IRepositorioRedeSocial
    {
        private readonly EventoContexto _eventoContexto;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositorioRedeSocial(EventoContexto eventoContexto, IConfiguration configuration) : base (eventoContexto)
        {
            _eventoContexto = eventoContexto;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<RedeSocial> ObterPorEventoID(int id)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT RedeSocialId, Nome, Url, EventoId FROM RedeSocial (NOLOCK) WHERE EventoId = @EVID";
                query.AdicionarParametro("EVID", id);
                query.Abrir();

                var listaRedeSocial = new List<RedeSocial>();

                while (query.Proximo())
                {
                    listaRedeSocial.Add(new RedeSocial()
                    {
                        RedeSocialId = query.ObterInteiro("RedeSocialId"),
                        Nome = query.ObterString("Nome"),
                        Url = query.ObterString("Url"),
                        EventoId = query.ObterInteiro("EventoId")
                    }); ;
                }

                return listaRedeSocial ?? null;
            }
        }


        public List<RedeSocial> ObterPorPalestranteID(int id)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT RedeSocialId, Nome, Url, PalestranteID FROM RedeSocial (NOLOCK) WHERE PalestranteID = @PAID";
                query.AdicionarParametro("PAID", id);
                query.Abrir();

                var listaRedeSocial = new List<RedeSocial>();

                while (query.Proximo())
                {
                    listaRedeSocial.Add(new RedeSocial()
                    {
                        RedeSocialId = query.ObterInteiro("RedeSocialId"),
                        Nome = query.ObterString("Nome"),
                        Url = query.ObterString("Url"),
                        PalestranteID = query.ObterInteiro("PalestranteID")
                    }); ;
                }

                return listaRedeSocial ?? null;
            }
        }

    }
}
