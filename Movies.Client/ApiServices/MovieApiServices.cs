using Movies.Client.Models;

namespace Movies.Client.ApiServices;

public class MovieApiServices: IMovieApiServices
{
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        var movies = new List<Movie>()
        {
            new Movie()
            {

                Id = 1,
                Genre = "Drama",
                Title = "The Shawshank Redemption",
                Rating = "9.3",
                ImageUrl = "images/src",
                ReleaseDate = new DateTime(1994, 5, 5),
                Owner = "alice"

            }
        };
        return await Task.FromResult(movies);
    }

    public Task<Movie> GetMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> CreateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateMovie(Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }
}