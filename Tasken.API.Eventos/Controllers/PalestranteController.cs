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
    public class PalestranteController : ControllerBase
    {

        private readonly IApplicationServicePalestrante _applicationServicePalestrante;

        public PalestranteController(IApplicationServicePalestrante applicationServicePalestrante)
        {
            _applicationServicePalestrante = applicationServicePalestrante;
        }


        [HttpGet]
        public ActionResult GetAll(int id)
        {
            try
            {
                var palestrante = _applicationServicePalestrante.GetAll();
                return Ok(palestrante);
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
            var palestrante = _applicationServicePalestrante.GetById(id);
            return Ok(palestrante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetById - Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PalestranteDTO model)
        {
            try
            {

            _applicationServicePalestrante.Add(model);
            return Ok("Palestrante cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Post - Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PalestranteDTO model)
        {
            try
            {

            _applicationServicePalestrante.Update(model);
            return Ok("Palestrante alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Put - Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] PalestranteDTO model)
        {
            try
            {

            _applicationServicePalestrante.Remove(model);
            return Ok("Palestrante excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - Delete - Erro: {ex.Message}");
            }
        }


        [HttpGet("GetPorNome")]
        public async Task<ActionResult> GetPorNome(string nome)
        {
            try
            {
                var palestrante = _applicationServicePalestrante.ObterPorNome(nome);
                return Ok(palestrante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorNome - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPorEmail")]
        public async Task<ActionResult> GetPorEmail(string email)
        {
            try
            {
                var palestrante = _applicationServicePalestrante.ObterPorEmail(email);
                return Ok(palestrante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorEmail - Erro: {ex.Message}");
            }
        }

        [HttpGet("GetPorTelefone")]
        public async Task<ActionResult> GetPorTelefone(string telefone)
        {
            try
            {
                var palestrante = _applicationServicePalestrante.ObterPorTelefone(telefone);
                return Ok(palestrante);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro no banco - GetPorTelefone - Erro: {ex.Message}");
            }
        }

    }
}
