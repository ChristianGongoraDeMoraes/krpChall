using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNotaFiscalKrp.src.dto.produtodto
{
    public class ProdutoRequestDto
    {
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
    }
}