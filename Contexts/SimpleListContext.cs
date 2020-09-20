using System;
using Microsoft.EntityFrameworkCore;
using SimpleListApi.Models;

namespace SimpleListApi.Contexts
{
  public class SimpleListContext : DbContext
  {
    public SimpleListContext(DbContextOptions<SimpleListContext> options) : base(options) { }

    /// <summary>
    /// Configurate data source.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    /// <summary>
    /// Create seed data.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<LineItem>()
        .HasOne<Category>(item => item.Category)
        .WithMany(category => category.LineItems)
        .HasForeignKey(item => item.CategoryId);

      var electronics = new Category("Electronics");
      var clothing = new Category("Clothing");
      var kitchen = new Category("Kitchen");

      modelBuilder.Entity<Category>()
        .HasData(
          electronics,
          clothing,
          kitchen
        );

      modelBuilder.Entity<LineItem>()
        .HasData(
          new LineItem("TV", 2000, electronics.Id),
          new LineItem("Playstation", 400, electronics.Id),
          new LineItem("Stereo", 1600, electronics.Id),
          new LineItem("Shirts", 1100, clothing.Id),
          new LineItem("Jeans", 1100, clothing.Id),
          new LineItem("Pots and Pans", 3000, kitchen.Id),
          new LineItem("Flatware", 500, kitchen.Id),
          new LineItem("Knife Set", 500, kitchen.Id),
          new LineItem("Mics", 1000, kitchen.Id)
        );

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

  }
}