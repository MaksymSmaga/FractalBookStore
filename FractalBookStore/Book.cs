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
            set
            {
                if (TryFormatedIsbn(value, out string formatedIsbn))
                    _dto.Isbn = formatedIsbn;
                else
                    throw new ArgumentException(nameof(Isbn));
            }
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
        public static class BookMapper
        {
            public static Book Map(BookDto dto) => new Book(dto);
            public static BookDto Map(Book domain) => domain._dto;

        }

        public static class DtoFactory
        {
            public static BookDto Create(string isbn,
                                          string author,
                                          string title,
                                          string description,
                                          decimal price)
            {
                if (TryFormatedIsbn(isbn, out string formatedIsbn))
                    isbn = formatedIsbn;
                else
                    throw new ArgumentException(nameof(isbn));

                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException(nameof(title));
                return new BookDto
                {
                    Isbn = isbn,
                    Author = author?.Trim(),
                    Title = title,
                    Description = description?.Trim(),
                    Price = price,

                };
            }
           
        }
        public static bool TryFormatedIsbn(string isbn, out string formatedIsbn)
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

        public static bool IsIsbn(string isbn) => TryFormatedIsbn(isbn, out _);   
    }
}
