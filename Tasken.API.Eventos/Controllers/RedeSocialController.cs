using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Domain;

namespace Tasken.API.Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedeSocialController : ControllerBase
    {

        private readonly IApplicationServiceRedeSocial _applicationServiceRedeSocial;

        public RedeSocialController(IApplicationServiceRedeSocial applicationServiceRedeSocial)
        {
            _applicationServiceRedeSocial = applicationServiceRedeSocial;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var redeSocial = _applicationServiceRedeSocial.GetAll();
            return Ok(redeSocial);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var redeSocial = _applicationServiceRedeSocial.GetById(id);
            return Ok(redeSocial);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RedeSocialDTO model)
        {
            _applicationServiceRedeSocial.Add(model);
            return Ok("Rede Social adicionada com sucesso.");
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RedeSocialDTO model)
        {
            _applicationServiceRedeSocial.Update(model);
            return Ok("Rede Social alterada com sucesso.");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] RedeSocialDTO model)
        {
            _applicationServiceRedeSocial.Remove(model);
            return Ok("Rede Social excluída com sucesso.");
        }

        [HttpGet("GetPorPalestranteID")]
        public async Task<ActionResult> GetPorPalestranteID(int palestranteId)
        {
            var redeSocial = _applicationServiceRedeSocial.ObterPorPalestranteID(palestranteId);
            return Ok(redeSocial);
        }

        [HttpGet("GetPorEventoID")]
        public async Task<ActionResult> GetPorEventoID(int EventoId)
        {
            var redeSocial = _applicationServiceRedeSocial.ObterPorEventoID(EventoId);
            return Ok(redeSocial);
        }

    }
}
