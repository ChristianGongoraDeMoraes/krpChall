using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiNotaFiscalKrp.src.model
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public string Numeracao { get; set; } = "";
        public bool Status { get; set; } = true;
        public List<Produto> produtos { get; set; } = [];
    }
}