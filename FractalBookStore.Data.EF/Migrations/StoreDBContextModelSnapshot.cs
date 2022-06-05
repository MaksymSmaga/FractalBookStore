﻿// <auto-generated />
using FractalBookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FractalBookStore.Data.EF.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    partial class StoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("Availble")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

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
                            Availble = true,
                            Description = "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes.However, many phenomena in nature and science are anything but regular or smooth.For example, a natural landscape may include bushes, trees, rugged mountains, and clouds,which are far too intricate to be represented by classical geometric shapes",
                            Image = "~/images/ImgBook.webp",
                            Isbn = "ISBN1211031013",
                            Price = 13.19m,
                            ShortDescription = "To many people, the word ‘geometry’ conjures up circles...",
                            Title = "Fractals: a very short introduction"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Benoit Mandelbrot",
                            Availble = true,
                            Description = "This Essay brings together a number of analyses in diverse sciences, and it promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, it reveals a totally new world of plastic beauty.",
                            Image = "~/images/FractalGeometry.jpg",
                            Isbn = "ISBN056458672",
                            Price = 19.13m,
                            ShortDescription = "This Essay brings together a number of analyses...",
                            Title = "The Fractal Geometry Of Nature"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Arthur Clarke",
                            Availble = true,
                            Description = "A geometry able to include mountains and clouds now exists. I put it together in 1975, but of course it incorporates numerous pieces that have been around for a very long time. Like everything in science, this new geometry has very, very deep and long roots.",
                            Image = "~/images/TheColoursOfInfinity.jpg",
                            Isbn = "ISBN0135555533",
                            Price = 14.98m,
                            ShortDescription = "A geometry able to include mountains and clouds now exists...",
                            Title = "The Colors Of Infinity"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Stephen Ornes",
                            Availble = true,
                            Description = "The worlds of visual art and mathematics come together in this spectacular volume by award-winning writer Stephen Ornes. He explores the growing sensation of math art, presenting more than 80 pieces, including a crocheted, colorful representation of non-Euclidian geometry that looks like sea coral and a 65-ton, 28-foot-tall bronze sculpture covered in a space-filling curve. For each work, we get the artist’s story followed by accessible and thought-provoking explanations of the mathematical concept and equations behind the art. From 3D-printed objects that give real form to abstract mathematical theories, to mystic fractals, to Andy Warhol as a solution to the Traveling Salesman Problem, these artworks embody some of strangest, most beautiful relationships among numbers and across dimensions.",
                            Image = "~/images/MathArt.jpg",
                            Isbn = "ISBN0135555534",
                            Price = 13.92m,
                            ShortDescription = "The worlds of visual art and mathematics come together...",
                            Title = "Math Art: Truth, Beauty, and Equations"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Ben Trube",
                            Availble = true,
                            Description = "Created with custom designed computer programs, the MATH COLORING BOOK: FRACTALS features twenty distinctive fractals patterns that reveal the beauty of the world around us. Complete with a glossary of terms, this book will help you discover why fractals as so fascinating as you color and see a whole new way of looking at math. Lose yourself in these detailed images and create art worthy of framing!",
                            Image = "~/images/MathColoringBookFractals.jpg",
                            Isbn = "ISBN0135555535",
                            Price = 17.84m,
                            ShortDescription = "Created with custom designed computer programs...",
                            Title = "Math Coloring Book Fractals"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Jason Lisle",
                            Availble = true,
                            Description = "What if mathematicians discovered a secret code embedded in math disclosing an amazing work of art hidden in the numbers? Just such a code of astounding beauty was discovered in the 1980s. The artworks displayed in this book have always existed, built into the numbers at creation. Dr. Lisle suggests that only the Christian worldview can make sense of this secret code. As such, the images in this book are a demonstration of the truth of that worldview.",
                            Image = "~/images/FractalsTheSecretCodeOfCreation.jpg",
                            Isbn = "ISBN0135555536",
                            Price = 9.99m,
                            ShortDescription = "What if mathematicians discovered a secret code embedded...",
                            Title = "Fractals: The Secret Code of Creation"
                        },
                        new
                        {
                            Id = 7,
                            Author = "David P. Feldman",
                            Availble = true,
                            Description = "This book provides the reader with an elementary introduction to chaos and fractals, suitable for students with a background in elementary algebra, without assuming prior coursework in calculus or physics. It introduces the key phenomena of chaos - aperiodicity, sensitive dependence on initial conditions,bifurcations - via simple iterated functions.Fractals are introduced as self - similar geometric objects and analyzed with the self - similarity and box - counting dimensions.After a brief discussion of power laws, subsequent chapters explore Julia Sets and the Mandelbrot Set.The last part of the book examines two - dimensional dynamical systems, strange attractors, cellular automata, and chaotic differential equations.",
                            Image = "~/images/ChaosAndFractals.jpg",
                            Isbn = "ISBN0135555538",
                            Price = 42.28m,
                            ShortDescription = "This book provides the reader with an elementary introduction...",
                            Title = "Chaos and Fractals"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Kenneth Falconer",
                            Availble = true,
                            Description = "An accessible introduction to fractals, useful as a text or reference. Part I is concerned with the general theory of fractals and their geometry, covering dimensions and their methods of calculation, plus the local form of fractals and their projections and intersections. Part II contains examples of fractals drawn from a wide variety of areas of mathematics and physics, including self-similar and self-affine sets, graphs of functions, examples from number theory and pure mathematics, dynamical systems, Julia sets, random fractals and some physical applications. Also contains many diagrams and illustrative examples, includes computer drawings of fractals, and shows how to produce further drawings for themselves.",
                            Image = "~/images/FractalGeometry.jpg",
                            Isbn = "ISBN0135555539",
                            Price = 38.45m,
                            ShortDescription = "An accessible introduction to fractals...",
                            Title = "Fractal Geometry"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Heinz-Otto Peitgen",
                            Availble = true,
                            Description = "Now approaching its tenth year, this hugely successful book presents an unusual attempt to publicise the field of Complex Dynamics. The text was originally conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen in Europe and the United States, and describes the context and meaning of these fascinating images. A total of 184 illustrations - including 88 full-colour pictures of Julia sets - are suggestive of a coffee-table book. However, the invited contributions which round off the book lend the text the required formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - centred style, of his discovery of the fractals named after him and Adrien Douady explains the solved and unsolved problems relating to this amusingly complex set.",
                            Image = "~/images/BeautyOfFractalsBook.jpg",
                            Isbn = "ISBN0135555540",
                            Price = 79.32m,
                            ShortDescription = "Now approaching its tenth year...",
                            Title = "The Beauty of Fractals"
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
