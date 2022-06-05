using Microsoft.EntityFrameworkCore.Migrations;

namespace FractalBookStore.Data.EF.Migrations
{
    public partial class AddImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "~/images/ImgBook.webp");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "~/images/FractalGeometry.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "~/images/TheColoursOfInfinity.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "~/images/MathArt.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "~/images/MathColoringBookFractals.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "~/images/FractalsTheSecretCodeOfCreation.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "David P. Feldman", "This book provides the reader with an elementary introduction to chaos and fractals, suitable for students with a background in elementary algebra, without assuming prior coursework in calculus or physics. It introduces the key phenomena of chaos - aperiodicity, sensitive dependence on initial conditions,bifurcations - via simple iterated functions.Fractals are introduced as self - similar geometric objects and analyzed with the self - similarity and box - counting dimensions.After a brief discussion of power laws, subsequent chapters explore Julia Sets and the Mandelbrot Set.The last part of the book examines two - dimensional dynamical systems, strange attractors, cellular automata, and chaotic differential equations.", "~/images/ChaosAndFractals.jpg", "ISBN0135555538", 42.28m, "This book provides the reader with an elementary introduction...", "Chaos and Fractals" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "Kenneth Falconer", "An accessible introduction to fractals, useful as a text or reference. Part I is concerned with the general theory of fractals and their geometry, covering dimensions and their methods of calculation, plus the local form of fractals and their projections and intersections. Part II contains examples of fractals drawn from a wide variety of areas of mathematics and physics, including self-similar and self-affine sets, graphs of functions, examples from number theory and pure mathematics, dynamical systems, Julia sets, random fractals and some physical applications. Also contains many diagrams and illustrative examples, includes computer drawings of fractals, and shows how to produce further drawings for themselves.", "~/images/FractalGeometry.jpg", "ISBN0135555539", 38.45m, "An accessible introduction to fractals...", "Fractal Geometry" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "Heinz-Otto Peitgen", "Now approaching its tenth year, this hugely successful book presents an unusual attempt to publicise the field of Complex Dynamics. The text was originally conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen in Europe and the United States, and describes the context and meaning of these fascinating images. A total of 184 illustrations - including 88 full-colour pictures of Julia sets - are suggestive of a coffee-table book. However, the invited contributions which round off the book lend the text the required formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - centred style, of his discovery of the fractals named after him and Adrien Douady explains the solved and unsolved problems relating to this amusingly complex set.", "~/images/BeautyOfFractalsBook.jpg", "ISBN0135555540", 79.32m, "Now approaching its tenth year...", "The Beauty of Fractals" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "Shu Tang Liu", "The book focuses on fractal control and applications in various fields. Fractal phenomena occur in nonlinear models, and since the behaviors depicted by fractals need to be controlled in practical applications, an understanding of fractal control is necessary. This book introduces readers to Julia set fractals and Mandelbrot set fractals in a range of models, such as physical systems, biological systems and SIRS models, and discusses controllers designed to control these fractals. Further, it demonstrates how the fractal dimension can be calculated in order to describe the complexity of various systems.Offering a comprehensive and systematic overview of the practical issues in fractal control, this book is a valuable resource for readers interested in practical solutions in fractal control. It will also appeal to researchers, engineers, and graduate students in fields of fractal control and applications, as well as chaos control and applications.", "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg", "ISBN0135555537", 143.09m, "The book focuses on fractal control and applications...", "Fractals: The Secret Code of Creation" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "David P. Feldman", "This book provides the reader with an elementary introduction to chaos and fractals, suitable for students with a background in elementary algebra, without assuming prior coursework in calculus or physics. It introduces the key phenomena of chaos - aperiodicity, sensitive dependence on initial conditions,bifurcations - via simple iterated functions.Fractals are introduced as self - similar geometric objects and analyzed with the self - similarity and box - counting dimensions.After a brief discussion of power laws, subsequent chapters explore Julia Sets and the Mandelbrot Set.The last part of the book examines two - dimensional dynamical systems, strange attractors, cellular automata, and chaotic differential equations.", "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg", "ISBN0135555538", 42.28m, "This book provides the reader with an elementary introduction...", "Chaos and Fractals" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { "Kenneth Falconer", "An accessible introduction to fractals, useful as a text or reference. Part I is concerned with the general theory of fractals and their geometry, covering dimensions and their methods of calculation, plus the local form of fractals and their projections and intersections. Part II contains examples of fractals drawn from a wide variety of areas of mathematics and physics, including self-similar and self-affine sets, graphs of functions, examples from number theory and pure mathematics, dynamical systems, Julia sets, random fractals and some physical applications. Also contains many diagrams and illustrative examples, includes computer drawings of fractals, and shows how to produce further drawings for themselves.", "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg", "ISBN0135555539", 38.45m, "An accessible introduction to fractals...", "Fractal Geometry" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Availble", "Description", "Image", "Isbn", "Price", "ShortDescription", "Title" },
                values: new object[] { 10, "Heinz-Otto Peitgen", true, "Now approaching its tenth year, this hugely successful book presents an unusual attempt to publicise the field of Complex Dynamics. The text was originally conceived as a supplemented catalogue to the exhibition \"Frontiers of Chaos\", seen in Europe and the United States, and describes the context and meaning of these fascinating images. A total of 184 illustrations - including 88 full-colour pictures of Julia sets - are suggestive of a coffee-table book. However, the invited contributions which round off the book lend the text the required formality.Benoit Mandelbrot gives a very personal account, in his idiosyncratic self - centred style, of his discovery of the fractals named after him and Adrien Douady explains the solved and unsolved problems relating to this amusingly complex set.", "https://images-na.ssl-images-amazon.com/images/I/4134nzlpaDL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg", "ISBN0135555540", 79.32m, "Now approaching its tenth year...", "The Beauty of Fractals" });
        }
    }
}
