using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutosKorp.src.dto.Produtodto;
using apiProdutosKorp.src.interfaces;
using Microsoft.AspNetCore.Mvc;
using apiProdutosKorp.src.mapper;
using apiProdutosKorp.src.dto.producerNotaFiscalProdutos;

namespace apiProdutosKorp.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoResponseDto>> saveProduto([FromBody] ProdutoRequestDto req)
        {
            if (!ModelState.IsValid) return BadRequest();

            var produto = await _produtoRepository.save(req);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoResponseDto>>> getAllProdutos()
        {
            var produtos = await _produtoRepository.findAll();
            return Ok(produtos.Select(x => x.ProdutoToResponse()));
        }

        [HttpPut]
        public async Task<ActionResult> baixarEstoque([FromBody] ProducerProdutos produtos)
        {
            var produto = await _produtoRepository.baixarEstoques(produtos);
            if (produto == null) return BadRequest();

            return Ok();
        }
    }
}