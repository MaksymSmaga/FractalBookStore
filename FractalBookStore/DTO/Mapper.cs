using FractalBookStore.DataTransferObjects;

namespace FractalBookStore.DTO
{
    public static class Mapper
    {
        public static Book Map(BookDTO dto) => new Book(dto);
        public static BookDTO Map(Book domain) => domain._dto;

        public static Order Map(OrderDTO dto) => new Order(dto);
        public static OrderDTO Map(Order domain) => domain.dto;

        public static OrderItem Map(OrderItemDTO dto) => new OrderItem(dto);
        public static OrderItemDTO Map(OrderItem domain) => domain.dto;

    }
}
