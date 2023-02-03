using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> opts)
            : base(opts) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Boss)
                .WithMany(x => x.Subordinates)
                .HasForeignKey(x => x.BossId);
        }

    }
}
