namespace Movie.API.Model;

public class Movie
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Rating { get; set; }
    public string ImageUrl { get; set; }
    public string Owner { get; set; }
    public DateTime releaseDate { get; set; }
}