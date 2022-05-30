using FractalBookStore.DataTransferObjects;

namespace FractalBookStore.Mappers
{
    public static class BookMapper
    {
        public static Book Map(BookDTO dto) => new Book(dto);
        public static BookDTO Map(Book domain) => domain._dto;
    }
}
