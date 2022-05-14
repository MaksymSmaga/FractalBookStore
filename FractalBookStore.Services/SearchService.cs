namespace FractalBookStore.Services
{
    public class SearchService
    {
        private readonly IBookRepository _bookRepository;

        public SearchService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return _bookRepository.GetAllByIsbn(query);
            else
                return _bookRepository.GetAllByTitleOrAuthor(query);
        }
    } 
}
