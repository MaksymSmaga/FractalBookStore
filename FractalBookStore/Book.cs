using FractalBookStore.DataTransferObjects;
using FractalBookStore.DTOFactory;
using System;
namespace FractalBookStore
{
    public class Book
    {
        internal readonly BookDTO _dto;

        public int Id => _dto.Id;
        public string Isbn
        {
            get => _dto.Isbn;
            set
            {
                if (BookDTOFactory.TryFormatedIsbn(value, out string formatedIsbn))
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
        public string Brief
        {
            get => _dto.ShortDescription;
            set => _dto.ShortDescription = value;
        }
        public string Description
        {
            get => _dto.Description;
            set => _dto.Description = value;
        }
        public string Image
        {
            get => _dto.Image;
            set => _dto.Image = value;
        }
        public bool Available
        {
            get => _dto.Availble;
            set => _dto.Availble = value;
        }
        public bool IsBestSell
        {
            get => _dto.IsBestSell;
            set => _dto.IsBestSell = value;
        }
        public decimal Price
        {
            get => _dto.Price;
            set => _dto.Price = value;
        }
        public decimal Discount
        {
            get => _dto.Discount;
            set => _dto.Discount = value;
        }

        public decimal Shipping
        {
            get => _dto.Shipping;
            set => _dto.Shipping = value;
        }

        public decimal TotalPrice
        {
            get => _dto.TotalPrice;
            set => _dto.TotalPrice = _dto.Price * (100 - _dto.Discount / 100) + _dto.Shipping;
        }

        public Book(BookDTO dto)
        {
            _dto = dto;
        }
    }
}
