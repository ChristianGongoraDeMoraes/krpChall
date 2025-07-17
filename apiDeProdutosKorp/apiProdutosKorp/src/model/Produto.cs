using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutosKorp.src.model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}