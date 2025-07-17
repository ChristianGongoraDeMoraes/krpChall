using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.dto.notafiscaldto;
using apiNotaFiscalKrp.src.interfaces;
using apiNotaFiscalKrp.src.model;
using apiNotaFiscalKrp.src.repository;
using Microsoft.AspNetCore.Mvc;

namespace apiNotaFiscalKrp.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotaFiscal>>> getAll()
        {
            var notasFiscais = await _notaFiscalRepository.getAll();
            return Ok(notasFiscais);
        }

        [HttpPost]
        public async Task<ActionResult<NotaFiscal>> save([FromBody] NotaFiscalRequestDto req)
        {
            if (!ModelState.IsValid) return BadRequest();

            var notaFiscal = await _notaFiscalRepository.save(req);
            if (notaFiscal == null) return BadRequest();

            return Ok(notaFiscal);
        }

        [HttpPut("/{numeracao}")]
        public async Task<ActionResult<NotaFiscal>> imprimir([FromRoute] string numeracao)
        {
            var notaFiscal = await _notaFiscalRepository.imprimir(numeracao);
            if (notaFiscal == null) return BadRequest();

            return Ok(notaFiscal);
        }
    }
}