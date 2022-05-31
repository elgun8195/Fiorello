using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello_Web_Application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
