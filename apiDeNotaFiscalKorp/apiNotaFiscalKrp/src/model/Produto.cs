using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiNotaFiscalKrp.src.model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal Preco { get; set; }
        [JsonIgnore]
        public NotaFiscal NotaFiscal { get; set; }
    }
}