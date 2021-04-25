using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo_models.Table;
using demo_web.Data.Repository;
using demo_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace demo_web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository context;

        public MoviesController(IMoviesRepository context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            var data1 = await context.GetMovies();
            List<MoviesDisplayModel> movies = new List<MoviesDisplayModel>();
            foreach(var item in data1)
            {
                movies.Add(new MoviesDisplayModel{Id = item.Id, movname = item.movname,
                Price=item.Price,
                Quantity = item.Quantity, 
                Photo = item.Photo,
                reviews = item.reviews});
            }
            return View(movies);
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> Detail(int id)
        {
            var Movie = await context.GetMovie(id);
            var mov = new MoviesDisplayModel{
                Id=Movie.Id,
                movname = Movie.movname,
                Price = Movie.Price,
                Photo = Movie.Photo,
                Quantity = Movie.Quantity,
                reviews = Movie.reviews
            };
            return View(mov);
        }
        [HttpPost]
        public async Task<IActionResult> SendReview(Review review, float rating,int moviid)
        {
            var data = new Review{
                datepost = DateTime.Now,
                accountid = Convert.ToInt32(this.HttpContext.Session.GetString("UserId")),
                movId = moviid,
                rating = rating,
                Content = review.Content
            };
            await context.PostReviews(data);
            return RedirectToAction("GetAction");
        }
    }
}