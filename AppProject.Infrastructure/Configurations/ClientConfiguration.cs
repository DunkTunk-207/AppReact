using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppProject.Infrastructure.Entities;

namespace AppProject.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            
            builder.HasMany(e => e.Projects)
                   .WithOne(e => e.Client)
                   .HasForeignKey(e => e.ClientId)
                   .IsRequired();
        }
    }
}