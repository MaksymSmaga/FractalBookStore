using FractalBookStore.DTO;

namespace FractalBookStore.Mappers
{
    public static class OrderMapper
    {
        public static Order Map(OrderDTO dto) => new Order(dto);

        public static OrderDTO Map(Order domain) => domain.dto;
    }
}
