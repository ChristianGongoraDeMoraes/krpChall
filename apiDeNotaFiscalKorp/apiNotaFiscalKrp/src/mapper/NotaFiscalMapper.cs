using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.dto.notafiscaldto;
using apiNotaFiscalKrp.src.dto.produtodto;
using apiNotaFiscalKrp.src.model;

namespace apiNotaFiscalKrp.src.mapper
{
    public static class NotaFiscalMapper
    {
        public static NotaFiscal RequestToNotaFiscal(this NotaFiscalRequestDto req)
        {
            var produtosEdited = req.produtos.Select(x => x.RequestToProduto()).ToList();
            return new NotaFiscal
            {
                Numeracao = req.Numeracao,
                produtos = produtosEdited
            };
        }
        public static Produto RequestToProduto(this ProdutoRequestDto req)
        {
            return new Produto
            {
                Nome = req.Nome,
                Preco = req.Preco
            };
        }
    }
}