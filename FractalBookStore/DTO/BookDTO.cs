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
        public bool Availble{ get; set; }
        public decimal Price { get; set; }
    }
}
