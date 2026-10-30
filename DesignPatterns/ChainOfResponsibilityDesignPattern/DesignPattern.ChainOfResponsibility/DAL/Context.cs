using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=DesignPattern1Db;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
