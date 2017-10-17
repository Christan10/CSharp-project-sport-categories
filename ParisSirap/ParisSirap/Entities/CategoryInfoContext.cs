using Microsoft.EntityFrameworkCore;

namespace ParisSirap.Entities
{
    public class CategoryInfoContext : DbContext
    {
        public CategoryInfoContext(DbContextOptions<CategoryInfoContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
