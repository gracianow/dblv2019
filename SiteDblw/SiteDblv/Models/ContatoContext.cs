using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteDblv.Models
{
    public class ContatoContext : DbContext
    {
        public ContatoContext()
            : base("name=DadosDbContext")
        {
        }

        public DbSet<ContatoViewModel> Contatos { get; set; }
    }
}