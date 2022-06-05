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
                        ShortDescription = "To many people, the word ‘geometry’ conjures up circles...",
                        Description = "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or "
                                     + "smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes."
                                     + "However, many phenomena in nature and science are anything but regular or smooth.For example, "
                                     + "a natural landscape may include bushes, trees, rugged mountains, and clouds,"
                                     + "which are far too intricate to be represented by classical geometric shapes",
                        Image = "~/images/ImgBook.webp",
                        Availble = true,
                        Price = 13.19m,
                    },
                    new BookDTO
                    {
                        Id = 2,
                        Isbn = "ISBN056458672",
                        Author = "Benoit Mandelbrot",
                        Title = "The Fractal Geometry Of Nature",
                        ShortDescription = "This Essay brings together a number of analyses...",
                        Description = "This Essay brings together a number of analyses in diverse sciences, and it "
                                    + "promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, "
                                    + "it reveals a totally new world of plastic beauty.",
                        Image = "~/images/FractalGeometry.jpg",
                        Availble = true,
                        Price = 19.13m,
                    },
                    new BookDTO
                    {
                        Id = 3,
                        Isbn = "ISBN0135555533",
                        Author = "Arthur Clarke",
                        Title = "The Colors Of Infinity",
                        ShortDescription = "A geometry able to include mountains and clouds now exists...",
                        Description = "A geometry able to include mountains and clouds now exists. I put it together in 1975, "
                                    + "but of course it incorporates numerous pieces that have been around for a very long time. "
                                    + "Like everything in science, this new geometry has very, very deep and long roots.",
                        Image = "~/images/TheColoursOfInfinity.jpg",
                        Availble = true,
                        Price = 14.98m,
                    },
                    new BookDTO
                    {
                        Id = 4,
                        Isbn = "ISBN0135555534",
                        Author = "Stephen Ornes",
                        Title = "Math Art: Truth, Beauty, and Equations",
                        ShortDescription = "The worlds of visual art and mathematics come together...",
                        Description = "The worlds of visual art and mathematics come together in this " +
                        "spectacular volume by award-winning writer Stephen Ornes. He explores the growing " +
                        "sensation of math art, presenting more than 80 pieces, including a crocheted, " +
                        "colorful representation of non-Euclidian geometry that looks like sea coral and " +
                        "a 65-ton, 28-foot-tall bronze sculpture covered in a space-filling curve. For each work, " +
                        "we get the artist’s story followed by accessible and thought-provoking explanations " +
                        "of the mathematical concept and equations behind the art. From 3D-printed objects " +
                        "that give real form to abstract mathematical theories, to mystic fractals, to Andy " +
                        "Warhol as a solution to the Traveling Salesman Problem, these artworks embody some " +
                        "of strangest, most beautiful relationships among numbers and across dimensions.",
                        Image = "~/images/MathArt.jpg",
                        Availble = true,
                        Price = 13.92m,
                    },
                    new BookDTO
                    {
                        Id = 5,
                        Isbn = "ISBN0135555535",
                        Author = "Ben Trube",
                        Title = "Math Coloring Book Fractals",
                        ShortDescription = "Created with custom designed computer programs...",
                        Description = "Created with custom designed computer programs, " +
                        "the MATH COLORING BOOK: FRACTALS features twenty distinctive fractals " +
                        "patterns that reveal the beauty of the world around us. Complete with a " +
                        "glossary of terms, this book will help you discover why fractals as so fascinating " +
                        "as you color and see a whole new way of looking at math. Lose yourself in these " +
                        "detailed images and create art worthy of framing!",
                        Image = "~/images/MathColoringBookFractals.jpg",
                        Availble = true,
                        Price = 17.84m,
                    },
                    new BookDTO
                    {
                        Id = 6,
                        Isbn = "ISBN0135555536",
                        Author = "Jason Lisle",
                        Title = "Fractals: The Secret Code of Creation",
                        ShortDescription = "What if mathematicians discovered a secret code embedded...",
                        Description = "What if mathematicians discovered a secret code embedded in math " +
                        "disclosing an amazing work of art hidden in the numbers? Just such a code of " +
                        "astounding beauty was discovered in the 1980s. The artworks displayed in this " +
                        "book have always existed, built into the numbers at creation. Dr. Lisle suggests " +
                        "that only the Christian worldview can make sense of this secret code. As such, " +
                        "the images in this book are a demonstration of the truth of that worldview.",
                        Image = "~/images/FractalsTheSecretCodeOfCreation.jpg",
                        Availble = true,
                        Price = 9.99m,
                    },

                    new BookDTO
                    {
                        Id = 7,
                        Isbn = "ISBN0135555538",
                        Author = "David P. Feldman",
                        Title = "Chaos and Fractals",
                        ShortDescription = "This book provides the reader with an elementary introduction...",
                        Description = "This book provides the reader with an elementary introduction to chaos" +
                        " and fractals, suitable for students with a background in elementary algebra, " +
                        "without assuming prior coursework in calculus or physics. It introduces the key " +
                        "phenomena of chaos - aperiodicity, sensitive dependence on initial conditions," +
                        "bifurcations - via simple iterated functions.Fractals are introduced as self - " +
                        "similar geometric objects and analyzed with the self - similarity and box - " +
                        "counting dimensions.After a brief discussion of power laws, subsequent chapters " +
                        "explore Julia Sets and the Mandelbrot Set.The last part of the book examines two " +
                        "- dimensional dynamical systems, strange attractors, cellular automata, " +
                        "and chaotic differential equations.",
                        Image = "~/images/ChaosAndFractals.jpg",
                        Availble = true,
                        Price = 42.28m,
                    },
                    new BookDTO
                    {
                        Id =8,
                        Isbn = "ISBN0135555539",
                        Author = "Kenneth Falconer",
                        Title = "Fractal Geometry",
                        ShortDescription = "An accessible introduction to fractals...",
                        Description = "An accessible introduction to fractals, useful as a text or reference. " +
                        "Part I is concerned with the general theory of fractals and their geometry, covering " +
                        "dimensions and their methods of calculation, plus the local form of fractals and their " +
                        "projections and intersections. Part II contains examples of fractals drawn from a wide " +
                        "variety of areas of mathematics and physics, including self-similar and self-affine sets, " +
                        "graphs of functions, examples from number theory and pure mathematics, dynamical systems, " +
                        "Julia sets, random fractals and some physical applications. Also contains many diagrams " +
                        "and illustrative examples, includes computer drawings of fractals, and shows how to produce " +
                        "further drawings for themselves.",
                        Image = "~/images/FractalGeometry.jpg",
                        Availble = true,
                        Price = 38.45m,
                    },
                    new BookDTO
                    {
                        Id = 9,
                        Isbn = "ISBN0135555540",
                        Author = "Heinz-Otto Peitgen",
                        Title = "The Beauty of Fractals",
                        ShortDescription = "Now approaching its tenth year...",
                        Description = "Now approaching its tenth year, this hugely successful book presents an " +
                         "unusual attempt to publicise the field of Complex Dynamics. The text was originally " +
                         "conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen " +
                         "in Europe and the United States, and describes the context and meaning of these " +
                         "fascinating images. A total of 184 illustrations - including 88 full-colour pictures " +
                         "of Julia sets - are suggestive of a coffee-table book. " +
                         "However, the invited contributions which round off the book lend the text the required " +
                         "formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - " +
                         "centred style, of his discovery of the fractals named after him and Adrien Douady " +
                         "explains the solved and unsolved problems relating to this amusingly complex set.",
                        Image = "~/images/BeautyOfFractalsBook.jpg",
                        Availble = true,
                        Price = 79.32m,
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
