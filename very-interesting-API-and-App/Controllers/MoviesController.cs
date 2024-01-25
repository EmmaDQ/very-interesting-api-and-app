using Microsoft.AspNetCore.Mvc;
using very_interesting_API_and_App.Models;

namespace very_interesting_API_and_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        public static List<MovieModel> Movies { get; set; } = new List<MovieModel>()
       {
           new MovieModel
            {
               Id = 1,
                Title = "Inception",
                Genre = "Science Fiction",
                ReleaseYear = 2010,
                ImageLink = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg"
            },
            new MovieModel
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Genre = "Drama",
                ReleaseYear = 1994,
                ImageLink = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.fruugo.se%2Fthe-shawshank-redemption-movie-poster-print-27-x-40%2Fp-8933449-19257485%3Flanguage%3Den&psig=AOvVaw2F5j8qyb9fThII2yuc6GBW&ust=1706252890135000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLCEocD994MDFQAAAAAdAAAAABAD"
            },
            new MovieModel
            {
                Id = 3,
                Title = "The Godfather",
                Genre = "Crime",
                ReleaseYear = 1972,
                ImageLink = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
            },
            new MovieModel
            {
                Id = 4,
                Title = "The Dark Knight",
                Genre = "Action",
                ReleaseYear = 2008,
                ImageLink = "https://static.posters.cz/image/1300/poster/the-dark-knight-trilogy-batman-i198201.jpg"
            },
            new MovieModel
            {
                Id = 5,
                Title = "Pulp Fiction",
                Genre = "Crime",
                ReleaseYear = 1994,
                ImageLink = "https://m.media-amazon.com/images/I/718LfFW+tIL._AC_UF1000,1000_QL80_.jpg"
            },
            new MovieModel
            {
                Id = 6,
                Title = "Forrest Gump",
                Genre = "Drama",
                ReleaseYear = 1994,
                ImageLink = "https://m.media-amazon.com/images/I/71CuAt3ey+L._AC_UF894,1000_QL80_.jpg"
            },
            new MovieModel
            {
                Id = 7,
                Title = "The Matrix",
                Genre = "Science Fiction",
                ReleaseYear = 1999,
                ImageLink = "https://m.media-amazon.com/images/I/91SZzvt+w4L.jpg"
            },
            new MovieModel
            {
                Id = 8,
                Title = "Schindler's List",
                Genre = "Drama",
                ReleaseYear = 1993,
                ImageLink = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg"
            },
            new MovieModel
            {
                Id = 9,
                Title = "Fight Club",
                Genre = "Drama",
                ReleaseYear = 1999,
                ImageLink = "https://m.media-amazon.com/images/I/61IgtYrLF5L._AC_UF1000,1000_QL80_.jpg"
            },
            new MovieModel
            {
                Id = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Genre = "Adventure",
                ReleaseYear = 2001,
                ImageLink = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FRINGS-FELLOWSHIP-MOVIE-POSTER-ORIGINAL%2Fdp%2FB008KPE6K2&psig=AOvVaw3VbNukQr5TWWDqZnMqLUjw&ust=1706253164478000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCMju78D-94MDFQAAAAAdAAAAABAD"
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

        [HttpPost]
        public ActionResult Post(MovieModel movie)
        {

            if (movie != null)
            {
                Movies.Add(movie);
                return Ok("The new movie has been added!");
            }

            if (movie == null || string.IsNullOrEmpty(movie.Title))
            {
                return BadRequest("Could not add the new movie. Check your JSON and try again!");
            }

            return BadRequest("Could not add the new movie. Check your JSON and try again!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MovieModel? found = Movies.FirstOrDefault(f => f.Id == id);

            if (found != null)
            {
                Movies.Remove(found);
                return Ok("The movie has been deleted!");
            }

            return BadRequest("Could not add the new movie. Check your JSON and try again!");

        }

        [HttpPut]
        public ActionResult Put(MovieModel movie)
        {
            MovieModel updated = new MovieModel();

            updated.Id = movie.Id;
            updated.Title = movie.Title;
            updated.Genre = movie.Genre;
            updated.ReleaseYear = movie.ReleaseYear;
            updated.ImageLink = movie.ImageLink;

            MovieModel? existing = Movies.FirstOrDefault(e => e.Id == movie.Id);

            if (existing != null)
            {
                Movies.Remove(existing);
                Movies.Add(updated);
                return Ok($"The movie {existing.Title} has been updated and is now: Title: {updated.Title}, Genre: {updated.Genre}, Releaseyear: {updated.ReleaseYear}!");
            }

            return BadRequest("Sorry, could not find any movie with that id! Please try again.");
        }

    }
}
