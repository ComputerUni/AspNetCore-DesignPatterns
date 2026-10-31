using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=DesignPattern2DB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
