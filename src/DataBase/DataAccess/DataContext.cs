﻿using DataBase.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class DataContext : DbContext {
    public DbSet<NewsEntity> Partners { get; set; }

    public DataContext() {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Server=localhost;Database=MyDatabase;Trusted_Connection=True;");
    }
}