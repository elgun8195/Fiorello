using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web_Application.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="dont empty"),StringLength(10,ErrorMessage ="10dan yux olmaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "dont empty"), StringLength(50, ErrorMessage = "50dan yux olmaz")]
        public string  Desc { get; set; }
        public IEnumerable<Product> Products { get; set; }
       
    }
}
