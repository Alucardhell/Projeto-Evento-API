using Microsoft.AspNetCore.Http;
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
    public class LoteController : ControllerBase
    {
        private readonly IApplicationServiceLote _applicationServiceLote;

        public LoteController(IApplicationServiceLote applicationServiceLote)
        {
            _applicationServiceLote = applicationServiceLote;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var lotes = _applicationServiceLote.GetAll();
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetAll - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try { 
            var lotes = _applicationServiceLote.GetById(id);
            return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetById - Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LoteDTO model)
        {
            try
            {

            _applicationServiceLote.Add(model);
            return Ok("Lote cadastrado com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Post - Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LoteDTO model)
        {
            try
            {

            _applicationServiceLote.Update(model);
            return Ok("Lote alterado com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Put - Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] LoteDTO model)
        {
            try
            {
            _applicationServiceLote.Remove(model);
            return Ok("Lote excluído com sucesso.");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Delete - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetEntreDatas")]
        public async Task<ActionResult> GetEntreDatas(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var lotes = _applicationServiceLote.ObterEntreDatas(dataInicio, dataFim);
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetById - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPorDataFim")]
        public async Task<ActionResult> GetPorDataFim(DateTime dataFim)
        {
            try
            {
                var lotes = _applicationServiceLote.ObterPorDataFim(dataFim);
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorDataFim - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPorDataInicio")]
        public async Task<ActionResult> GetPorDataInicio(DateTime dataInicio)
        {
            try
            {
                var lotes = _applicationServiceLote.ObterPorDataInicio(dataInicio);
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorDataInicio - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPorEvento")]
        public async Task<ActionResult> GetPorEvento(string eventoTema)
        {
            try
            {
                var lotes = _applicationServiceLote.ObterPorEvento(eventoTema);
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorEvento - Erro: {ex.Message}");
            }
        }


        [HttpGet("GetPorPreco")]
        public async Task<ActionResult> GetPorPreco(double precoMinimo, double precoMaximo)
        {
            try
            {
                var lotes = _applicationServiceLote.ObterPorPreco(precoMinimo, precoMaximo);
                return Ok(lotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorPreco - Erro: {ex.Message}");
            }
        }

    }
}
