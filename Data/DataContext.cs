using Microsoft.EntityFrameworkCore;

namespace Demo1.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FindMasProject>(entity => entity.HasNoKey());
        }
        //public DbSet<MasProject> MasProjects { get; set; }
        public DbSet<FindMasProject> FindMasProjects { get; set; }
    }
}
