namespace Fiorello_Web_Application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Category Category { get; set; }
    }
}
