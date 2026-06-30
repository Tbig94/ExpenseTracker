using ExpenseTrackerApi.Application.Common.Interfaces;
using ExpenseTrackerApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTrackerApi.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IConfiguration _config;

    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Expenses)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder
          //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ExpenseTrackerDB;MultipleActiveResultSets=true;TrustServerCertificate=true;Trusted_Connection=True")
          .UseSqlServer(_config.GetConnectionString("DefaultConnection"))
            .UseSeeding(async (context, _) =>
            {
                context.Set<Category>().Add(new Category { Name = "Élelmiszer" });
                context.Set<Category>().Add(new Category { Name = "Közlekedés" });
                context.Set<Category>().Add(new Category { Name = "Számlák" });
                context.Set<Category>().Add(new Category { Name = "Szórakozás" });
                context.Set<Category>().Add(new Category { Name = "Egészség" });
                context.Set<Category>().Add(new Category { Name = "Egyéb" });
                context.SaveChanges();
            });
}
