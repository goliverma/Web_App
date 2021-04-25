using System.Collections.Generic;
using System.Threading.Tasks;
using demo_models.Table;

namespace demo_web.Data.Repository
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movies>> GetMovies();
        Task<Movies> GetMovie(int id);
        Task PostReviews(Review review);
    }
}