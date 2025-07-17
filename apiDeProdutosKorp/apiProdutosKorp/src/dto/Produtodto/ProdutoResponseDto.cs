using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutosKorp.src.dto.Produtodto
{
    public class ProdutoResponseDto
    {
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}