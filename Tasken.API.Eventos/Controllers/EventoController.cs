using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasken.API.Eventos.Aplicacao.DTO;
using Tasken.API.Eventos.Aplicacao.Interface;
using Tasken.API.Eventos.Domain;
using Tasken.API.Eventos.Domain.Core.Interfaces.Repositorys;
using Tasken.API.Eventos.Domain.Core.Interfaces.Services;
using Tasken.API.Eventos.Domain.Services.Services;
using Tasken.API.Eventos.Infra.Data.Repositorios;

namespace Tasken.API.Eventos
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IApplicationServiceEvento _applicationServiceEvento;

        public EventoController(IApplicationServiceEvento applicationServiceEvento)
        {
            _applicationServiceEvento = applicationServiceEvento;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {

            var eventos = _applicationServiceEvento.GetAll();
            return Ok(eventos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetAll - Erro: {ex.Message}");
            }
        }


        [HttpGet, Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var eventos = _applicationServiceEvento.GetById(id);
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetById - Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventoDTO model)
        {
            try
            {

                _applicationServiceEvento.Add(model);

                return Ok("Evento cadastrado com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Post - Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EventoDTO model)
        {
            try
            {

                _applicationServiceEvento.Update(model);
                return Ok("Evento alterado com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Put - Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] EventoDTO model)
        {
            try
            {

                _applicationServiceEvento.Remove(model);
                return Ok("Evento excluído com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Delete - Erro: {ex.Message}");
            }
        }


        [HttpGet, Route("GetPorData")]
        public async Task<ActionResult> GetPorData([FromQuery] DateTime data)
        {
            try
            {
                var eventos = _applicationServiceEvento.ObterPorData(data);
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorData - Erro: {ex.Message}");
            }
        }

        [HttpGet, Route("GetEntreData")]
        public async Task<ActionResult> GetEntreData([FromQuery] DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var eventos = _applicationServiceEvento.ObterEntreData(dataInicio, dataFim);
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorData - Erro: {ex.Message}");
            }
        }

        [HttpGet, Route("GetPorTema")]
        public async Task<ActionResult> GetPorTema([FromQuery] string tema)
        {
            try
            {
                var eventos = _applicationServiceEvento.ObterPorTema(tema);
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorTema - Erro: {ex.Message}");
            }
        }

    }
}
