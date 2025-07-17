using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutosKorp.src.model;
using Microsoft.EntityFrameworkCore;

namespace apiProdutosKorp.src.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
       : base(dbContextOptions)
        {

        }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}