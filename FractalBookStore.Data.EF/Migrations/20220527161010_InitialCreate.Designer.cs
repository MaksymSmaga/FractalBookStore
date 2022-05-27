﻿// <auto-generated />
using FractalBookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FractalBookStore.Data.EF.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20220527161010_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FractalBookStore.DTO.OrderDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TotalCount")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("Money");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FractalBookStore.DTO.OrderItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FractalBookStore.DataTransferObjects.BookDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Kenneth Falconer",
                            Description = "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes.However, many phenomena in nature and science are anything but regular or smooth.For example, a natural landscape may include bushes, trees, rugged mountains, and clouds,which are far too intricate to be represented by classical geometric shapes",
                            Isbn = "ISBN1211031013",
                            Price = 13.19m,
                            Title = "Fractals: a very short introduction"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Benoit Mandelbrot",
                            Description = "This Essay brings together a number of analyses in diverse sciences, and it promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, it reveals a totally new world of plastic beauty.",
                            Isbn = "ISBN056458672",
                            Price = 19.13m,
                            Title = "The Fractal Geometry Of Nature"
                        },
                        new
                        {
                            Id = 3,
                            Author = "The Fractal Geometry Of Nature",
                            Description = "A geometry able to include mountains and clouds now exists. I put it together in 1975, but of course it incorporates numerous pieces that have been around for a very long time. Like everything in science, this new geometry has very, very deep and long roots.",
                            Isbn = "ISBN0135555533",
                            Price = 14.98m,
                            Title = "Arthur Clarke"
                        });
                });

            modelBuilder.Entity("FractalBookStore.DTO.OrderItemDTO", b =>
                {
                    b.HasOne("FractalBookStore.DTO.OrderDTO", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FractalBookStore.DTO.OrderDTO", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
