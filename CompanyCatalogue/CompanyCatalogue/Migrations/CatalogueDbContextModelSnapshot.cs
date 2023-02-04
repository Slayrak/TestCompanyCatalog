﻿// <auto-generated />
using System;
using CompanyCatalogue.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyCatalogue.Migrations
{
    [DbContext(typeof(CatalogueDbContext))]
    partial class CatalogueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyCatalogue.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BossId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanyCatalogue.Models.Employee", b =>
                {
                    b.HasOne("CompanyCatalogue.Models.Employee", "Boss")
                        .WithMany("Subordinates")
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("CompanyCatalogue.Models.Employee", b =>
                {
                    b.Navigation("Subordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
