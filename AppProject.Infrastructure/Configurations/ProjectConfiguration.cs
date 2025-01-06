using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppProject.Infrastructure.Entities;

namespace AppProject.Infrastructure.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            builder.HasOne(p => p.Client)
                   .WithMany(c => c.Projects)
                   .HasForeignKey(p => p.ClientId);
        }
    }
}