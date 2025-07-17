using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutosKorp.src.dto.Produtodto
{
    public class ProdutoRequestDto
    {
        [Required]
        public string Nome { get; set; } = "";
        
        [Required]
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}