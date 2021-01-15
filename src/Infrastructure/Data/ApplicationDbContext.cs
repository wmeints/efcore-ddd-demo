namespace Bakery.Infrastructure.Data
{
    using System;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new PieEntityTypeConfiguration());
        }
    }
}
