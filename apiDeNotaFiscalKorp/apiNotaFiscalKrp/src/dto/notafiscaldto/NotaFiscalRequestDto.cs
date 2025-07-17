using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.dto.produtodto;
using apiNotaFiscalKrp.src.model;

namespace apiNotaFiscalKrp.src.dto.notafiscaldto
{
    public class NotaFiscalRequestDto
    {
        [Required]
        public string Numeracao { get; set; } = "";
        public bool Status { get; set; } = true;
        [Required]
        public List<ProdutoRequestDto> produtos { get; set; }
    }
}