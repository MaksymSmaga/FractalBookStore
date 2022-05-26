using FractalBookStore.DataTransferObjects;
using FractalBookStore.DTO;
using Microsoft.EntityFrameworkCore;
using FractalBookStore.Web;
using System;

namespace FractalBookStore.Data.EF
{
    public class StoreDBContext : DbContext
    {
        public DbSet<BookDTO> Books { get; set; }
        public DbSet<OrderItemDTO> OrderItems { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
                              : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuidBooks(modelBuilder);
            BuidOrderItems(modelBuilder);
            BuildOrders(modelBuilder);
        }

        public static void BuidBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDTO>(action =>
            {
                action.Property(dto => dto.Isbn)
                      .HasMaxLength(17)
                      .IsRequired();

                action.Property(dto => dto.Title)
                      .IsRequired();

                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasData(
                    new BookDTO
                    {
                        Id = 1,
                        Isbn = "ISBN0201038013",
                        Author = "D. Knuth",
                        Title = "Art Of Programming, Vol. 1",
                        Description = "This volume begins with basic programming concepts and techniques, then focuses more particularly on information structures-the representation of information inside a computer, the structural relationships between data elements and how to deal with them efficiently.",
                        Price = 7.19m,
                    },
                    new BookDTO
                    {
                        Id = 2,
                        Isbn = "ISBN0201485672",
                        Author = "M. Fowler",
                        Title = "Refactoring",
                        Description = "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community.",
                        Price = 12.45m,
                    },
                    new BookDTO
                    {
                        Id = 3,
                        Isbn = "ISBN0131101633",
                        Author = "B. W. Kernighan, D. M. Ritchie",
                        Title = "C Programming Language",
                        Description = "Known as the bible of C, this classic bestseller introduces the C programming language and illustrates algorithms, data structures, and programming techniques.",
                        Price = 14.98m,
                    }
                );
            });
        }

        public static void BuidOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDTO>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }

        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDTO>(action =>
            {
                action.Property(dto => dto.TotalCount)
                      .HasColumnType("Count")
                      .HasMaxLength(10);

                action.Property(dto => dto.TotalPrice)
                      .HasColumnType("Money");
            });
        }
    }
}
