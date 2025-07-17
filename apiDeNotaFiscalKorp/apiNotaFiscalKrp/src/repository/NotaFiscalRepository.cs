using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.controller;
using apiNotaFiscalKrp.src.data;
using apiNotaFiscalKrp.src.dto.notafiscaldto;
using apiNotaFiscalKrp.src.interfaces;
using apiNotaFiscalKrp.src.mapper;
using apiNotaFiscalKrp.src.model;
using Microsoft.EntityFrameworkCore;

namespace apiNotaFiscalKrp.src.repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ApplicationDbContext _context;
        public NotaFiscalRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<NotaFiscal> save(NotaFiscalRequestDto req)
        {
            var notaFiscal = req.RequestToNotaFiscal();

            await _context.NotaFiscal.AddAsync(notaFiscal);

            foreach (var produto in notaFiscal.produtos)
            {
                produto.NotaFiscal = notaFiscal;
                await _context.Produtos.AddAsync(produto);
            }

            await _context.SaveChangesAsync();
            return notaFiscal;
        }

        public async Task<List<NotaFiscal>> getAll()
        {
            var notasFiscais = await _context.NotaFiscal.Include(x => x.produtos).ToListAsync();
            return notasFiscais;
        }

        public async Task<NotaFiscal?> imprimir(string numeracao)
        {
            var notaFiscal = await _context.NotaFiscal.Include(x => x.produtos).FirstOrDefaultAsync(x => x.Numeracao == numeracao);
            if (notaFiscal == null) return null;
            if (notaFiscal.Status == false) return null;

            using var transaction = await _context.Database.BeginTransactionAsync();

            HttpClient http = new HttpClient();

            var estoque = await http.PutAsJsonAsync("http://localhost:5127/api/Produto", new { Produtos = notaFiscal.produtos });
            if ((!estoque.IsSuccessStatusCode) || estoque == null)
            {
                await transaction.RollbackAsync();
                return null;
            }
            notaFiscal.Status = false;

            await transaction.CommitAsync();
            await _context.SaveChangesAsync();

            return notaFiscal;            
        }
    }
}