using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pagination.Model.Seed
{
    public class Seed
    {
        private readonly ModelBuilder modelBuilder;
        public Seed(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void SeedDb()
        {
            for (int i = 1; i < 50000; i++)
            {
                modelBuilder.Entity<Product>().HasData(
                   new Product()
                   {
                       Id = i,
                       Name = $"Product{i}",
                       Price = i
                   }
               );
            }

        }

    }

}
