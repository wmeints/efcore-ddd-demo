﻿// <auto-generated />
using System;
using Bakery.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bakery.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Bakery.Domain.Aggregates.CategoryAggregate.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bakery.Domain.Aggregates.PieAggregate.Pie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pies");
                });

            modelBuilder.Entity("Bakery.Domain.Aggregates.PieAggregate.Pie", b =>
                {
                    b.HasOne("Bakery.Domain.Aggregates.CategoryAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Bakery.Domain.Aggregates.PieAggregate.Ingredient", "Ingredients", b1 =>
                        {
                            b1.Property<Guid>("PieId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<bool>("IsAllergen")
                                .HasColumnType("bit");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<double>("RelativeAmount")
                                .HasColumnType("float");

                            b1.HasKey("PieId", "Id");

                            b1.ToTable("Ingredient");

                            b1.WithOwner()
                                .HasForeignKey("PieId");
                        });

                    b.OwnsOne("Bakery.Domain.Aggregates.PieAggregate.Portions", "Portions", b1 =>
                        {
                            b1.Property<Guid>("PieId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Maximum")
                                .HasColumnType("int");

                            b1.Property<int>("Minimum")
                                .HasColumnType("int");

                            b1.HasKey("PieId");

                            b1.ToTable("Pies");

                            b1.WithOwner()
                                .HasForeignKey("PieId");
                        });

                    b.Navigation("Ingredients");

                    b.Navigation("Portions");
                });
#pragma warning restore 612, 618
        }
    }
}
