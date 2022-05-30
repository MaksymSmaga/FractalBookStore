using Microsoft.EntityFrameworkCore.Migrations;

namespace FractalBookStore.Data.EF.Migrations
{
    public partial class InitialCreate : Migration
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
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
                columns: new[] { "Id", "Author", "Description", "Isbn", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Kenneth Falconer", "To many people, the word ‘geometry’ conjures up circles, cubes, cylinders, and other regular or smooth objects.Familiar artefacts, such as buildings, furniture, or cars, make wide use of such shapes.However, many phenomena in nature and science are anything but regular or smooth.For example, a natural landscape may include bushes, trees, rugged mountains, and clouds,which are far too intricate to be represented by classical geometric shapes", "ISBN1211031013", 13.19m, "Fractals: a very short introduction" },
                    { 2, "Benoit Mandelbrot", "This Essay brings together a number of analyses in diverse sciences, and it promotes a new mathematical and philosophical synthesis.Thus, it serves as both a casebook and a manifesto. Furthermore, it reveals a totally new world of plastic beauty.", "ISBN056458672", 19.13m, "The Fractal Geometry Of Nature" },
                    { 3, "Arthur Clarke", "A geometry able to include mountains and clouds now exists. I put it together in 1975, but of course it incorporates numerous pieces that have been around for a very long time. Like everything in science, this new geometry has very, very deep and long roots.", "ISBN0135555533", 14.98m, "The Colors Of Infinity" },
                    { 4, "Stephen Ornes", "The worlds of visual art and mathematics come together in this spectacular volume by award-winning writer Stephen Ornes. He explores the growing sensation of math art, presenting more than 80 pieces, including a crocheted, colorful representation of non-Euclidian geometry that looks like sea coral and a 65-ton, 28-foot-tall bronze sculpture covered in a space-filling curve. For each work, we get the artist’s story followed by accessible and thought-provoking explanations of the mathematical concept and equations behind the art. From 3D-printed objects that give real form to abstract mathematical theories, to mystic fractals, to Andy Warhol as a solution to the Traveling Salesman Problem, these artworks embody some of strangest, most beautiful relationships among numbers and across dimensions.", "ISBN0135555534", 13.92m, "Math Art: Truth, Beauty, and Equations" },
                    { 5, "Ben Trube", "Created with custom designed computer programs, the MATH COLORING BOOK: FRACTALS features twenty distinctive fractals patterns that reveal the beauty of the world around us. Complete with a glossary of terms, this book will help you discover why fractals as so fascinating as you color and see a whole new way of looking at math. Lose yourself in these detailed images and create art worthy of framing!", "ISBN0135555535", 17.84m, "Math Coloring Book Fractals" },
                    { 6, "Jason Lisle", "What if mathematicians discovered a secret code embedded in math disclosing an amazing work of art hidden in the numbers? Just such a code of astounding beauty was discovered in the 1980s. The artworks displayed in this book have always existed, built into the numbers at creation. Dr. Lisle suggests that only the Christian worldview can make sense of this secret code. As such, the images in this book are a demonstration of the truth of that worldview.", "ISBN0135555536", 9.99m, "Fractals: The Secret Code of Creation" },
                    { 7, "Shu Tang Liu", "The book focuses on fractal control and applications in various fields. Fractal phenomena occur in nonlinear models, and since the behaviors depicted by fractals need to be controlled in practical applications, an understanding of fractal control is necessary. This book introduces readers to Julia set fractals and Mandelbrot set fractals in a range of models, such as physical systems, biological systems and SIRS models, and discusses controllers designed to control these fractals. Further, it demonstrates how the fractal dimension can be calculated in order to describe the complexity of various systems.Offering a comprehensive and systematic overview of the practical issues in fractal control, this book is a valuable resource for readers interested in practical solutions in fractal control. It will also appeal to researchers, engineers, and graduate students in fields of fractal control and applications, as well as chaos control and applications.", "ISBN0135555537", 143.09m, "Fractals: The Secret Code of Creation" },
                    { 8, "David P. Feldman", "This book provides the reader with an elementary introduction to chaos and fractals, suitable for students with a background in elementary algebra, without assuming prior coursework in calculus or physics. It introduces the key phenomena of chaos - aperiodicity, sensitive dependence on initial conditions,bifurcations - via simple iterated functions.Fractals are introduced as self - similar geometric objects and analyzed with the self - similarity and box - counting dimensions.After a brief discussion of power laws, subsequent chapters explore Julia Sets and the Mandelbrot Set.The last part of the book examines two - dimensional dynamical systems, strange attractors, cellular automata, and chaotic differential equations.", "ISBN0135555538", 42.28m, "Chaos and Fractals" },
                    { 9, "Kenneth Falconer", "An accessible introduction to fractals, useful as a text or reference. Part I is concerned with the general theory of fractals and their geometry, covering dimensions and their methods of calculation, plus the local form of fractals and their projections and intersections. Part II contains examples of fractals drawn from a wide variety of areas of mathematics and physics, including self-similar and self-affine sets, graphs of functions, examples from number theory and pure mathematics, dynamical systems, Julia sets, random fractals and some physical applications. Also contains many diagrams and illustrative examples, includes computer drawings of fractals, and shows how to produce further drawings for themselves.", "ISBN0135555539", 38.45m, "Fractal Geometry" },
                    { 10, "Heinz-Otto Peitgen", "Now approaching its tenth year, this hugely successful book presents an unusual attempt to publicise the field of Complex Dynamics. The text was originally conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen in Europe and the United States, and describes the context and meaning of these fascinating images. A total of 184 illustrations - including 88 full-colour pictures of Julia sets - are suggestive of a coffee-table book. However, the invited contributions which round off the book lend the text the required formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - centred style, of his discovery of the fractals named after him and Adrien Douady explains the solved and unsolved problems relating to this amusingly complex set.", "ISBN0135555540", 79.32m, "The Beauty of Fractals" }
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
