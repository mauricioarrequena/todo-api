using Microsoft.EntityFrameworkCore;
using MyTaskApi.Domain;
using Task = MyTaskApi.Domain.Task;

namespace MyTaskApi.Persistence;
public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Task> Tasks {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Task>()
      .Property(t => t.Title)
      .IsRequired()
      .HasMaxLength(100);
    }


}