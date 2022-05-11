namespace FractalBookStore
{
    // To describe the contract functional
    // of inheritanced and implemented BookRepositories.
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);
    }
}
