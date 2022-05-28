using FractalBookStore.DataTransferObjects;
using FractalBookStore.DTO;
using Microsoft.EntityFrameworkCore;

namespace FractalBookStore.Data.EF
{   // Add-Migration InitialCreate -Project FractalBookStore.Data.EF -StartupProject FractalBookStore.Web
    // Update-Database -Project FractalBookStore.Data.EF -StartupProject FractalBookStore.Web
    // Add-Migration FullTextSearch -Project FractalBookStore.Data.EF -StartupProject FractalBookStore.Web
    #region
    //migrationBuilder.Sql("CREATE FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction:true);
    //migrationBuilder.Sql("CREATE FULLTEXT INDEX ON Books(Title) KEY INDEX PK_Books WITH STOPLIST=SYSTEM", suppressTransaction: true);

    //migrationBuilder.Sql("DROP FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction: true);
    //migrationBuilder.Sql("DROP FULLTEXT INDEX ON Books(Title) KEY INDEX PK_Books WITH STOPLIST=SYSTEM", suppressTransaction: true);
    #endregion
    // Update-Database -Project FractalBookStore.Data.EF -StartupProject FractalBookStore.Web
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
                        Isbn = "ISBN1211031013",
                        Author = "Kenneth Falconer",
                        Title = "Fractals: a very short introduction",
                        Description = "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or "
                                     + "smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes."
                                     + "However, many phenomena in nature and science are anything but regular or smooth.For example, "
                                     + "a natural landscape may include bushes, trees, rugged mountains, and clouds,"
                                     + "which are far too intricate to be represented by classical geometric shapes",
                        Price = 13.19m,
                    },
                    new BookDTO
                    {
                        Id = 2,
                        Isbn = "ISBN056458672",
                        Author = "Benoit Mandelbrot",
                        Title = "The Fractal Geometry Of Nature",
                        Description = "This Essay brings together a number of analyses in diverse sciences, and it "
                                    + "promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, "
                                    + "it reveals a totally new world of plastic beauty.",
                        Price = 19.13m,
                    },
                    new BookDTO
                    {
                        Id = 3,
                        Isbn = "ISBN0135555533",
                        Author = "Arthur Clarke",
                        Title = "The Fractal Geometry Of Nature",
                        Description = "A geometry able to include mountains and clouds now exists. I put it together in 1975, "
                                    + "but of course it incorporates numerous pieces that have been around for a very long time. "
                                    + "Like everything in science, this new geometry has very, very deep and long roots.",
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
                      .HasMaxLength(10);

                action.Property(dto => dto.TotalPrice)
                      .HasColumnType("Money");
            });
        }
    }
}
