using Microsoft.EntityFrameworkCore.Migrations;

namespace FractalBookStore.Data.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availble = table.Column<bool>(type: "bit", nullable: false),
                    IsBestSell = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    Shipping = table.Column<decimal>(type: "money", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Availble", "Description", "Discount", "Image", "IsBestSell", "Isbn", "Price", "Shipping", "ShortDescription", "Title", "TotalPrice" },
                values: new object[,]
                {
                    { 1, "Kenneth Falconer", true, "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes.However, many phenomena in nature and science are anything but regular or smooth.For example, a natural landscape may include bushes, trees, rugged mountains, and clouds,which are far too intricate to be represented by classical geometric shapes", 20.0m, "/images/FractalsAVeryShortIntroduction.jpg", true, "ISBN1211031013", 13.19m, 0.0m, "To many people, the word ‘geometry’ conjures up circles...", "Fractals: a very short introduction", 10.552m },
                    { 2, "Benoit Mandelbrot", true, "This Essay brings together a number of analyses in diverse sciences, and it promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, it reveals a totally new world of plastic beauty.", 13.0m, "/images/FractalGeometry.jpg", true, "ISBN056458672", 19.13m, 34.0m, "This Essay brings together a number of analyses...", "The Fractal Geometry Of Nature", 45.4753m },
                    { 3, "Arthur Clarke", false, "A geometry able to include mountains and clouds now exists. I put it together in 1975, but of course it incorporates numerous pieces that have been around for a very long time. Like everything in science, this new geometry has very, very deep and long roots.", 0.0m, "/images/TheColoursOfInfinity.jpg", true, "ISBN0135555533", 14.98m, 23.0m, "A geometry able to include mountains and clouds now exists...", "The Colors Of Infinity", 36.0326m },
                    { 4, "Stephen Ornes", true, "The worlds of visual art and mathematics come together in this spectacular volume by award-winning writer Stephen Ornes. He explores the growing sensation of math art, presenting more than 80 pieces, including a crocheted, colorful representation of non-Euclidian geometry that looks like sea coral and a 65-ton, 28-foot-tall bronze sculpture covered in a space-filling curve. For each work, we get the artist’s story followed by accessible and thought-provoking explanations of the mathematical concept and equations behind the art. From 3D-printed objects that give real form to abstract mathematical theories, to mystic fractals, to Andy Warhol as a solution to the Traveling Salesman Problem, these artworks embody some of strangest, most beautiful relationships among numbers and across dimensions.", 20.0m, "/images/MathArt.jpg", true, "ISBN0135555534", 13.92m, 100.0m, "The worlds of visual art and mathematics come together...", "Math Art: Truth, Beauty, and Equations", 111.136m },
                    { 5, "Ben Trube", true, "Created with custom designed computer programs, the MATH COLORING BOOK: FRACTALS features twenty distinctive fractals patterns that reveal the beauty of the world around us. Complete with a glossary of terms, this book will help you discover why fractals as so fascinating as you color and see a whole new way of looking at math. Lose yourself in these detailed images and create art worthy of framing!", 0.0m, "/images/MathColoringBookFractals.jpg", false, "ISBN0135555535", 17.84m, 1.23m, "Created with custom designed computer programs...", "Math Coloring Book Fractals", 19.070m },
                    { 6, "Jason Lisle", true, "What if mathematicians discovered a secret code embedded in math disclosing an amazing work of art hidden in the numbers? Just such a code of astounding beauty was discovered in the 1980s. The artworks displayed in this book have always existed, built into the numbers at creation. Dr. Lisle suggests that only the Christian worldview can make sense of this secret code. As such, the images in this book are a demonstration of the truth of that worldview.", 0.0m, "/images/FractalsTheSecretCodeOfCreation.jpg", false, "ISBN0135555536", 9.99m, 0.0m, "What if mathematicians discovered a secret code embedded...", "Fractals: The Secret Code of Creation", 9.990m },
                    { 7, "David P. Feldman", true, "This book provides the reader with an elementary introduction to chaos and fractals, suitable for students with a background in elementary algebra, without assuming prior coursework in calculus or physics. It introduces the key phenomena of chaos - aperiodicity, sensitive dependence on initial conditions,bifurcations - via simple iterated functions.Fractals are introduced as self - similar geometric objects and analyzed with the self - similarity and box - counting dimensions.After a brief discussion of power laws, subsequent chapters explore Julia Sets and the Mandelbrot Set.The last part of the book examines two - dimensional dynamical systems, strange attractors, cellular automata, and chaotic differential equations.", 50.0m, "/images/ChaosAndFractals.jpg", false, "ISBN0135555538", 42.28m, 0.0m, "This book provides the reader with an elementary introduction...", "Chaos and Fractals", 21.140m },
                    { 8, "Kenneth Falconer", true, "An accessible introduction to fractals, useful as a text or reference. Part I is concerned with the general theory of fractals and their geometry, covering dimensions and their methods of calculation, plus the local form of fractals and their projections and intersections. Part II contains examples of fractals drawn from a wide variety of areas of mathematics and physics, including self-similar and self-affine sets, graphs of functions, examples from number theory and pure mathematics, dynamical systems, Julia sets, random fractals and some physical applications. Also contains many diagrams and illustrative examples, includes computer drawings of fractals, and shows how to produce further drawings for themselves.", 5.0m, "/images/FractalGeometry.jpg", false, "ISBN0135555539", 38.45m, 0.0m, "An accessible introduction to fractals...", "Fractal Geometry", 36.5275m },
                    { 9, "Heinz-Otto Peitgen", true, "Now approaching its tenth year, this hugely successful book presents an unusual attempt to publicise the field of Complex Dynamics. The text was originally conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen in Europe and the United States, and describes the context and meaning of these fascinating images. A total of 184 illustrations - including 88 full-colour pictures of Julia sets - are suggestive of a coffee-table book. However, the invited contributions which round off the book lend the text the required formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - centred style, of his discovery of the fractals named after him and Adrien Douady explains the solved and unsolved problems relating to this amusingly complex set.", 33.0m, "/images/BeautyOfFractalsBook.jpg", false, "ISBN0135555540", 79.32m, 125.0m, "Now approaching its tenth year...", "The Beauty of Fractals", 178.1444m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
