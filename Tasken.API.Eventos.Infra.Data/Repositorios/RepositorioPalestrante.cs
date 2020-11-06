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
    public class RepositorioPalestrante : RepositorioBase<Palestrante>, IRepositorioPalestrante
    {
        private readonly EventoContexto _eventoContexto;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositorioPalestrante(EventoContexto eventoContexto, IConfiguration configuration) : base (eventoContexto)
        {
            _eventoContexto = eventoContexto;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Palestrante> ObterPorEmail(string email)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM Palestrante (NOLOCK) WHERE Email = @EMAIL";
                query.AdicionarParametro("EMAIL", email);
                query.Abrir();

                var listaPalestrante = new List<Palestrante>();

                while (query.Proximo())
                {
                    listaPalestrante.Add(new Palestrante()
                    {
                        PalestranteId = query.ObterInteiro("PalestranteId"),
                        Nome = query.ObterString("Nome"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterString("Telefone"),
                        Minicurriculo = query.ObterString("Minicurriculo"),
                        Email = query.ObterString("Email"),
                    });
                }

                return listaPalestrante ?? null;
            }
        }

        public List<Palestrante> ObterPorNome(string nome)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM Palestrante (NOLOCK) WHERE Nome = @NOME";
                query.AdicionarParametro("NOME", nome);
                query.Abrir();

                var listaPalestrante = new List<Palestrante>();

                while (query.Proximo())
                {
                    listaPalestrante.Add(new Palestrante()
                    {
                        PalestranteId = query.ObterInteiro("PalestranteId"),
                        Nome = query.ObterString("Nome"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterString("Telefone"),
                        Minicurriculo = query.ObterString("Minicurriculo"),
                        Email = query.ObterString("Email"),
                    });
                }

                return listaPalestrante ?? null;
            }
        }

        public List<Palestrante> ObterPorTelefone(string telefone)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT * FROM Palestrante (NOLOCK) WHERE Telefone = @TELEFONE";
                query.AdicionarParametro("TELEFONE", telefone);
                query.Abrir();

                var listaPalestrante = new List<Palestrante>();

                while (query.Proximo())
                {
                    listaPalestrante.Add(new Palestrante()
                    {
                        PalestranteId = query.ObterInteiro("PalestranteId"),
                        Nome = query.ObterString("Nome"),
                        ImagemUrl = query.ObterString("ImagemUrl"),
                        Telefone = query.ObterString("Telefone"),
                        Minicurriculo = query.ObterString("Minicurriculo"),
                        Email = query.ObterString("Email"),
                    });
                }

                return listaPalestrante ?? null;
            }
        }
    }
}
