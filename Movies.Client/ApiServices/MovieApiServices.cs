using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;

namespace Movies.Client.ApiServices;

public class MovieApiServices: IMovieApiServices
{
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        // need to installl Identity model to get token
        //get token from dentity server
        // send request with protected API by using token in header
        var clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
        {
            Address = "https://localhost:5005/connect/token",
            ClientId = "movieClient",
            ClientSecret = "secret",
            Scope = "movieApi"
        };
        var httpClient = new HttpClient();
        var discoveryDocumentAsync = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5005");
        if (discoveryDocumentAsync.IsError) return null;
        var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
        if (token.IsError) return null;
        var client = new HttpClient();
        client.SetBearerToken(token.AccessToken);
        var response = await client.GetAsync("https://localhost:5008/api/Movie");
        // response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var movies = JsonConvert.DeserializeObject<List<Movie>>(content);
        return movies;

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