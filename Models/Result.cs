using BookScraper.API.Models.Enums;

namespace BookScraper.API.Models;

public class Result<T>
{
    public List<T> Items { get; set; } = new();
    public Status Status { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
}