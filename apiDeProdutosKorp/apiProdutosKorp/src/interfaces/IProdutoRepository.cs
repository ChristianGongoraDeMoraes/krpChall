using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutosKorp.src.dto.producerNotaFiscalProdutos;
using apiProdutosKorp.src.dto.Produtodto;
using apiProdutosKorp.src.model;

namespace apiProdutosKorp.src.interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> save(ProdutoRequestDto req);
        Task<List<Produto>> findAll();
        Task<bool?> baixarEstoques(ProducerProdutos req);  
    }
}