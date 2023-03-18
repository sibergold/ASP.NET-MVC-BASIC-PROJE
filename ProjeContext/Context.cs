using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using OOP_Projesi.Entity;


namespace OOP_Projesi.ProjeContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OMER\\SQLEXPRESS;database=DbNewOopCore;integrated security=true;Trust Server Certificate=true");
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entity.Product> Products { get; set; }


    }
}
