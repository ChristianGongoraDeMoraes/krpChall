using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.dto.notafiscaldto;
using apiNotaFiscalKrp.src.model;

namespace apiNotaFiscalKrp.src.interfaces
{
    public interface INotaFiscalRepository
    {
        Task<NotaFiscal> save(NotaFiscalRequestDto notaFiscalRequestDto);
        Task<List<NotaFiscal>> getAll();
        Task<NotaFiscal?> imprimir(string numeracao);
    }
}