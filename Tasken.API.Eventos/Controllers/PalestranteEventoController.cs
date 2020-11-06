using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Domain.Models;

namespace Tasken.API.Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PalestranteEventoController : ControllerBase
    {

        private readonly IApplicationServicePalestranteEvento _applicationServicePalestranteEvento;

        public PalestranteEventoController(IApplicationServicePalestranteEvento applicationServicePalestranteEvento)
        {
            _applicationServicePalestranteEvento = applicationServicePalestranteEvento;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {

            var palestranteEvento = _applicationServicePalestranteEvento.GetAll();
            return Ok(palestranteEvento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetAll - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {

            var palestranteEvento = _applicationServicePalestranteEvento.GetById(id);
            return Ok(palestranteEvento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Get - Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PalestranteEventoDTO model)
        {
            try
            {

            _applicationServicePalestranteEvento.Add(model);
            return Ok("PalestranteEvento adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Post - Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PalestranteEventoDTO model)
        {
            try
            {

            _applicationServicePalestranteEvento.Update(model);
            return Ok("PalestranteEvento alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Put - Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] PalestranteEventoDTO model)
        {
            try
            {

            _applicationServicePalestranteEvento.Remove(model);
            return Ok("PalestranteEvento excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Delete - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetEventoPorPalestranteID")]
        public async Task<ActionResult> GetEventoPorPalestranteID(int idPalestrante)
        {
            try
            {

                var palestranteEvento = _applicationServicePalestranteEvento.ObterEventoPorPalestranteID(idPalestrante);
                return Ok(palestranteEvento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetEventoPorPalestranteID - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPalestrantePorEventoID")]
        public async Task<ActionResult> GetPalestrantePorEventoID(int idEvento)
        {
            try
            {

                var palestranteEvento = _applicationServicePalestranteEvento.ObterPalestrantePorEventoID(idEvento);
                return Ok(palestranteEvento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetEventoPorPalestranteID - Erro: {ex.Message}");
            }
        }
    }
}
