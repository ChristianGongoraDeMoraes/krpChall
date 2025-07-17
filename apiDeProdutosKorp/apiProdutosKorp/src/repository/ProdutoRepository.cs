using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutosKorp.src.data;
using apiProdutosKorp.src.dto.Produtodto;
using apiProdutosKorp.src.interfaces;
using apiProdutosKorp.src.model;
using apiProdutosKorp.src.mapper;
using Microsoft.EntityFrameworkCore;
using apiProdutosKorp.src.dto.producerNotaFiscalProdutos;

namespace apiProdutosKorp.src.repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool?> baixarEstoques(ProducerProdutos req)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            foreach (var produto in req.Produtos)
            {
                var produtoAtual = await _context.Produtos.FirstOrDefaultAsync(x => x.Nome == produto.Nome);
                if (produtoAtual.QuantidadeEmEstoque - 1 < 0 || produtoAtual == null)
                {
                    await transaction.RollbackAsync();
                    return null;
                }

                produtoAtual.QuantidadeEmEstoque -= 1;
            }
            
            await transaction.CommitAsync();
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Produto>> findAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return produtos;
        }

        public async Task<Produto> save(ProdutoRequestDto req)
        {
            Produto produto = req.RequestToProduto();

            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        
    }
}