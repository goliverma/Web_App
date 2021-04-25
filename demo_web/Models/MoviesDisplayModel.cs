using System.Collections;
using System.Collections.Generic;
using demo_models.Table;

namespace demo_web.Models
{
    public class MoviesDisplayModel
    {
        public int Id { get; set; }
        public string movname { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public IEnumerable<Review> reviews { get; set; }
        public Review review { get; set; }
    }
}