using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutosKorp.src.dto.Produtodto;
using apiProdutosKorp.src.model;

namespace apiProdutosKorp.src.mapper
{
    public static class ProdutoMapper
    {
        public static Produto RequestToProduto(this ProdutoRequestDto req)
        {
            return new Produto
            {
                Nome = req.Nome,
                Preco = req.Preco,
                QuantidadeEmEstoque = req.QuantidadeEmEstoque,
            };
        }
         
         public static ProdutoResponseDto ProdutoToResponse(this Produto req)
        {
            return new ProdutoResponseDto
            {
                Nome = req.Nome,
                Preco = req.Preco,
                QuantidadeEmEstoque = req.QuantidadeEmEstoque,
            };
        }
    }
}