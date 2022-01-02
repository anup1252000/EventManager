using Microsoft.EntityFrameworkCore.Design;

namespace Ceremonies.Events.Infrastructure
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
       
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Events;User ID=sa;Password=Abc1234#");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
