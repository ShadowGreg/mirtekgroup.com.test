using DataBase.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class DataContext: DbContext {
    public DbSet<NewsEntity> News { get; set; }

    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<NewsEntity>()
            .HasIndex(n => n.Title)
            .IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql(
            "Server=192.168.50.40;Port=5432;Database=default_db;User Id=postgres;Password=example;",
            b => b.MigrationsAssembly("WebApp"));
    }
}