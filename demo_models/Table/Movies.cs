using System.Collections.Generic;
namespace demo_models.Table
{
    public class Movies
    {
        public int Id { get; set; }
        public string movname { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public IEnumerable<Review> reviews { get; set; }

    }
}