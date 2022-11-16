using System.ComponentModel.DataAnnotations;

namespace BookLibrary_API.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool IsAvailable { get; set; }
}

public class BookDTO
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }
}