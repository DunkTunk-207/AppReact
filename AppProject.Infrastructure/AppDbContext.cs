using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AppProject.Infrastructure.Entities;

namespace AppProject.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
             .ToTable("Clients")
             .HasKey(c => c.Id);
             
             modelBuilder.Entity<User>()
             .ToTable("Users")
             .HasKey(c => c.Id);

            modelBuilder.Entity<Project>()
            .ToTable("Projects")
            .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
            .HasMany(e => e.Projects)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.ClientId)
            .IsRequired();

            modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.ClientId);
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=AppProjectDB;Integrated Security=True;TrustServerCertificate=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
