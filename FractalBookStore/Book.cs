using FractalBookStore.DataTransferObjects;
using System;
using System.Text.RegularExpressions;

namespace FractalBookStore
{
    // To realize an entity of Business Logic
    // with help class Book.
    public class Book
    {
        private readonly BookDto _dto;
        public int Id => _dto.Id;
        public string Isbn
        {
            get => _dto.Isbn;
            set => _dto.Isbn = value;
        }
        public string Author
        {
            get => _dto.Author;
            set => _dto.Author = value?.Trim();
        }
        public string Title
        {
            get => _dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(value));

                _dto.Title = value.Trim();
            }

        }
        public string Description
        {
            get => _dto.Description;
            set => _dto.Description = value;
        }
        public decimal Price
        {
            get => _dto.Price;
            set => _dto.Price = value;
        }

        internal Book(BookDto dto)
        {
            _dto = dto;
        }
        public static bool TryFormatIsIsbn(string isbn, out string formatedIsbn)
        {
            if (isbn == null)
            {
                formatedIsbn = null;
                return false;
            }

            formatedIsbn = isbn.Replace("-", "")
                               .Replace(" ", "")
                               .ToUpper();

            return Regex.IsMatch(formatedIsbn, @"^ISBN\d{10}(\d{3})?$");
        }


        public static bool IsIsbn(string isbn) => TryFormatIsIsbn(isbn, out _);

        public  static class BookMapper
        {
            public static Book Map(BookDto dto) => new Book(dto);
            public static BookDto Map(Book domain) => domain._dto;

        }
    }
}
