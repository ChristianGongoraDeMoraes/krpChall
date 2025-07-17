using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNotaFiscalKrp.src.model;
using Microsoft.EntityFrameworkCore;

namespace apiNotaFiscalKrp.src.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
       : base(dbContextOptions)
        {

        }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}