using FractalBookStore.DataTransferObjects;
using System;
using System.Text.RegularExpressions;

namespace FractalBookStore.DTOFactory
{
    public static class BookDTOFactory
    {
        public static BookDTO Create(string isbn,
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
            return new BookDTO
            {
                Isbn = isbn,
                Author = author?.Trim(),
                Title = title,
                Description = description?.Trim(),
                Price = price,

            };
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
