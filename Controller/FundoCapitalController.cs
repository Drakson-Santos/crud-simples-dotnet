using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Uniciv.Api.Models;
using Uniciv.Api.Repositories;

namespace Uniciv.Api.Controller
{
    public class FundoCapitalController : ControllerBase
    {
        private readonly IFundoCapitalRepository _fundoCapitalRepository;

        public FundoCapitalController(IFundoCapitalRepository fundoCapitalRepository)
        {
            _fundoCapitalRepository = fundoCapitalRepository;
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(_fundoCapitalRepository.ObterTodos());
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult BuscarFundo(Guid id)
        {
            var fundoCapital = _fundoCapitalRepository.ObterPorId(id);
            if (fundoCapital == null)
                return NotFound();

            return Ok(fundoCapital);
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult CadastrarFundo([FromBody] FundoCapital fundo)
        {
            _fundoCapitalRepository.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult AtualizarFundo(Guid id, [FromBody] FundoCapital fundo)
        {
            var fundoCapital = _fundoCapitalRepository.ObterPorId(id);
            if (fundoCapital == null)
                return NotFound();
            
            fundoCapital.Nome = fundo.Nome;
            fundoCapital.ValorAtual = fundo.ValorAtual;
            fundoCapital.ValorNecessario = fundo.ValorNecessario;
            fundoCapital.DataResgate = fundo.DataResgate;
            _fundoCapitalRepository.Atualizar(fundo);

            return Ok();
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundoCapital = _fundoCapitalRepository.ObterPorId(id);
            if (fundoCapital == null)
                return NotFound();
            
            _fundoCapitalRepository.Remover(fundoCapital);
            return Ok();
        }
    }}