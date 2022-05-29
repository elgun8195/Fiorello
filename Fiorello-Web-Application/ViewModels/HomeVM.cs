using Fiorello_Web_Application.Models;
using System.Collections;
using System.Collections.Generic;

namespace Fiorello_Web_Application.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider>    Slider { get; set; }
        public PageIntro PageIntro { get; set; }
        public Bio Bio { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
