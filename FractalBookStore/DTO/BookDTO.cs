namespace FractalBookStore.DataTransferObjects
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Availble { get; set; }
        public bool IsBestSell { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
