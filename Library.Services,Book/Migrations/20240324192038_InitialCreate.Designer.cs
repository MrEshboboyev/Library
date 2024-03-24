﻿// <auto-generated />
using Library.Services_Book.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Services_Book.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240324192038_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Services_Book.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "A story about the American Dream.",
                            Genre = "Classic",
                            Language = "English",
                            Name = "The Great Gatsby",
                            Rating = 4.5,
                            Size = 250
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Harper Lee",
                            Description = "A powerful story of racial injustice and the loss of innocence.",
                            Genre = "Fiction",
                            Language = "English",
                            Name = "To Kill a Mockingbird",
                            Rating = 4.7999999999999998,
                            Size = 320
                        },
                        new
                        {
                            BookId = 3,
                            Author = "George Orwell",
                            Description = "A dystopian social science fiction novel.",
                            Genre = "Dystopian",
                            Language = "English",
                            Name = "1984",
                            Rating = 4.7000000000000002,
                            Size = 328
                        },
                        new
                        {
                            BookId = 4,
                            Author = "Jane Austen",
                            Description = "A romantic novel of manners.",
                            Genre = "Romance",
                            Language = "English",
                            Name = "Pride and Prejudice",
                            Rating = 4.5999999999999996,
                            Size = 432
                        },
                        new
                        {
                            BookId = 5,
                            Author = "J.D. Salinger",
                            Description = "A novel about teenage angst and alienation.",
                            Genre = "Literary Fiction",
                            Language = "English",
                            Name = "The Catcher in the Rye",
                            Rating = 4.4000000000000004,
                            Size = 277
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
