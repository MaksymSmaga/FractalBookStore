using FractalBookStore.DTO;
using FractalBookStore.DTOFactory;

namespace FractalBookStore
{
    public class OrderItem
    {
        internal readonly OrderItemDTO dto;

        public int BookId => dto.BookId;

        public int Count
        {
            get { return dto.Count; }
            set
            {
                OrderItemDTOFactory.ThrowIfInvalidCount(value);

                dto.Count = value;
            }
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        internal OrderItem(OrderItemDTO dto)
        {
            this.dto = dto;
        }
    }
}
