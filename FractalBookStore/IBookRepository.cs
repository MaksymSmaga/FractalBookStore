namespace FractalBookStore
{
    // To describe the contract functional
    // of inheritanced and implemented BookRepositories.
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string titlePart);

        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);

        Book GetById(int id);
    }
}
