﻿// <auto-generated />
using System;
using JobPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JobPortal.Migrations
{
    [DbContext(typeof(RestContext))]
    [Migration("20211107135610_rename")]
    partial class rename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("JobPortal.Data.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicantName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTimeUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("offerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("offerId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobPortal.Data.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationTimeUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("JobPortal.Data.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationTimeUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("JobPortal.Data.Entities.Application", b =>
                {
                    b.HasOne("JobPortal.Data.Entities.Offer", "offer")
                        .WithMany()
                        .HasForeignKey("offerId");

                    b.Navigation("offer");
                });

            modelBuilder.Entity("JobPortal.Data.Entities.Response", b =>
                {
                    b.HasOne("JobPortal.Data.Entities.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Application");
                });
#pragma warning restore 612, 618
        }
    }
}
