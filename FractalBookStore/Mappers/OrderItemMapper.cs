using FractalBookStore.DTO;

namespace FractalBookStore.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItem Map(OrderItemDTO dto) => new OrderItem(dto);

        public static OrderItemDTO Map(OrderItem domain) => domain.dto;
    }
}
