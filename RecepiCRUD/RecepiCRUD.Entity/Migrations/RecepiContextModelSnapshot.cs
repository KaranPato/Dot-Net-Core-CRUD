﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecepiCRUD.Entity;

namespace RecepiCRUD.Entity.Migrations
{
    [DbContext(typeof(RecepiContext))]
    partial class RecepiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecepiCRUD.Entity.Recepi", b =>
                {
                    b.Property<int>("RecepiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecepiDesc");

                    b.Property<string>("RecepiImage");

                    b.Property<string>("RecepiName");

                    b.HasKey("RecepiId");

                    b.ToTable("Recepies");
                });
#pragma warning restore 612, 618
        }
    }
}
