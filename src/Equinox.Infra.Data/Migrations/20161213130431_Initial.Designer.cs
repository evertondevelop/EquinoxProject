using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Equinox.Domain.Models;

namespace Equinox.Infra.Data.Migrations
{
    [DbContext(typeof(EquinoxContext))]
    [Migration("20161213130431_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0")
                .HasAnnotation("Relational:ValueGenerationStrategy", RelationalValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Equinox.Domain.Models.Customer", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                b.Property<DateTime>("BirthDate");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100); // corrected the max length to 100

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                b.HasKey("Id");

                b.ToTable("Customers");
            });
        }
    }
}
