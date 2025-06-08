using Firewatch.Abrigos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Firewatch.Abrigos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }
    }
}
