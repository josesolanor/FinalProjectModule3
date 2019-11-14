using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using WalletCore.Entities;

namespace WalletCore.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        public DbSet<Balance> Balances { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {           
            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseSqlite("Filename=MyDatabase.db");
            return new ApplicationDBContext(builder.Options);
        }
    }
}
