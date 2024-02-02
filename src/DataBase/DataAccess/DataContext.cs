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
            @"Server=147.45.107.184;Port=5432;Database=default_db;User Id=gen_user;Password=\\MoqZ0_EY)3{u;");
    }
}