using Microsoft.EntityFrameworkCore;

namespace Pagination.Model
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseNpgsql("host=localhost; port=5432; database=Pagination; username=postgres; password=postgrespw");

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Pagination.Model.Seed.Seed(modelBuilder).SeedDb();


        }
        public DbSet<Product> Products { get; set; }
     

    }
}

