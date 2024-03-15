using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Domain.Models; // Include a comment indicating the namespace is for domain models

namespace Equinox.Infra.Data.Mappings
{    
    // The CustomerMap class implements the IEntityTypeConfiguration interface for the Customer model
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        // The Configure method is called by the EntityFrameworkCore framework to configure the Customer model
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Set the column name for the Id property to "Id"
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            // Configure the Name property to be of type varchar(100), with a maximum length of 100 characters, and required
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            // Configure the Email property to be of type varchar(100), with a maximum length of 100 characters, and required
            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();   
        }
    }
}
