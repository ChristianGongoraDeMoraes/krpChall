using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutosKorp.src.dto.producerNotaFiscalProdutos
{
    public class ProducerProdutos
    {
        public List<ProducerProdutosDto> Produtos { get; set; }
    }
    public class ProducerProdutosDto
    { 
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
    }
}
