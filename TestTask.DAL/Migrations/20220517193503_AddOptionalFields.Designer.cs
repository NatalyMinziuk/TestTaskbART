﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.DAL;

#nullable disable

namespace TestTask.DAL.Migrations
{
    [DbContext(typeof(TestTaskDBContext))]
    [Migration("20220517193503_AddOptionalFields")]
    partial class AddOptionalFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestTask.DAL.Enteties.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IncidentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Contact", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Incident", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Account", b =>
                {
                    b.HasOne("TestTask.DAL.Enteties.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Contact", b =>
                {
                    b.HasOne("TestTask.DAL.Enteties.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("TestTask.DAL.Enteties.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
