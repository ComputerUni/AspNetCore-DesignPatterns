using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Decorator.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-213H3J8\\SQLEXPRESS;Database=DecoratorDesignPatternDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Notifier> Notifiers { get; set; }
    }
}
