using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_models.Table;
using Microsoft.EntityFrameworkCore;

namespace demo_web.Data.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext context;

        public MoviesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Movies> GetMovie(int id)
        {
            return await context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movies>> GetMovies()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task PostReviews(Review review)
        {
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }
    }
}