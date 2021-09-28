﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBContactManager.Models;

namespace SBContactManager.Migrations
{
    [DbContext(typeof(ContactContext))]
    [Migration("20210926152330_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SBContactManager.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "W",
                            Name = "Work"
                        },
                        new
                        {
                            CategoryId = "F",
                            Name = "Friend"
                        },
                        new
                        {
                            CategoryId = "R",
                            Name = "Relative"
                        });
                });

            modelBuilder.Entity("SBContactManager.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Phone")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("ContactId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            CategoryId = "W",
                            Email = "bradpitt@hotmail.com",
                            FirstName = "Brad",
                            LastName = "Pitt",
                            Phone = 5559876543L
                        },
                        new
                        {
                            ContactId = 2,
                            CategoryId = "F",
                            Email = "David@hotmail.com",
                            FirstName = "David",
                            LastName = "Becham",
                            Phone = 5554567890L
                        },
                        new
                        {
                            ContactId = 3,
                            CategoryId = "R",
                            Email = "Christiano@hotmail.com",
                            FirstName = "Christiano",
                            LastName = "Ronaldo",
                            Phone = 5551234597L
                        });
                });

            modelBuilder.Entity("SBContactManager.Models.Contact", b =>
                {
                    b.HasOne("SBContactManager.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
