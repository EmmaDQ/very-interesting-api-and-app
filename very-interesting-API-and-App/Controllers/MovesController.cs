using Microsoft.AspNetCore.Mvc;
using very_interesting_API_and_App.Models;

namespace very_interesting_API_and_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovesController : ControllerBase
    {
        public static List<MovieModel> Movies { get; set; } = new List<MovieModel>()
       {
           new MovieModel
            {
               Id = 1,
                Title = "Inception",
                Genre = "Science Fiction",
                ReleaseYear = 2010,
                ImageLink = "https://example.com/inception.jpg"
            },
            new MovieModel
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Genre = "Drama",
                ReleaseYear = 1994,
                ImageLink = "https://example.com/shawshank_redemption.jpg"
            },
            new MovieModel
            {
                Id = 3,
                Title = "The Godfather",
                Genre = "Crime",
                ReleaseYear = 1972,
                ImageLink = "https://example.com/godfather.jpg"
            },
            new MovieModel
            {
                Id = 4,
                Title = "The Dark Knight",
                Genre = "Action",
                ReleaseYear = 2008,
                ImageLink = "https://example.com/dark_knight.jpg"
            },
            new MovieModel
            {
                Id = 5,
                Title = "Pulp Fiction",
                Genre = "Crime",
                ReleaseYear = 1994,
                ImageLink = "https://example.com/pulp_fiction.jpg"
            },
            new MovieModel
            {
                Id = 6,
                Title = "Forrest Gump",
                Genre = "Drama",
                ReleaseYear = 1994,
                ImageLink = "https://example.com/forrest_gump.jpg"
            },
            new MovieModel
            {
                Id = 7,
                Title = "The Matrix",
                Genre = "Science Fiction",
                ReleaseYear = 1999,
                ImageLink = "https://example.com/matrix.jpg"
            },
            new MovieModel
            {
                Id = 8,
                Title = "Schindler's List",
                Genre = "Drama",
                ReleaseYear = 1993,
                ImageLink = "https://example.com/schindlers_list.jpg"
            },
            new MovieModel
            {
                Id = 9,
                Title = "Fight Club",
                Genre = "Drama",
                ReleaseYear = 1999,
                ImageLink = "https://example.com/fight_club.jpg"
            },
            new MovieModel
            {
                Id = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Genre = "Adventure",
                ReleaseYear = 2001,
                ImageLink = "https://example.com/lotr_fellowship.jpg"
            },
       };

        [HttpGet]
        public ActionResult<List<MovieModel>> Get()
        {
            if (Movies != null && Movies.Any())
            {
                return Ok(Movies);
            }

            return NotFound("Coud not find any movies =(");

        }

        [HttpGet("{id}")]
        public ActionResult<MovieModel> Get(int id)
        {
            MovieModel? movie = Movies.FirstOrDefault(m => m.Id == id);

            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound();

        }

        //[HttpPost]
        //public ActionResult Post(MovieModel movie)
        //{
        //    if (movie != null)
        //    {

        //    }
        //}

    }
}
