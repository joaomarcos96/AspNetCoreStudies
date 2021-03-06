﻿// <auto-generated />
using System;
using AspNetCoreStudies.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AspNetCoreStudies.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200524151341_UpdateUpdatedAtAndDeletedAtPropertiesToBeNullable")]
    partial class UpdateUpdatedAtAndDeletedAtPropertiesToBeNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AspNetCoreStudies.Api.Features.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("content")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnName("deleted_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("pk_articles");

                    b.ToTable("articles");
                });
#pragma warning restore 612, 618
        }
    }
}
