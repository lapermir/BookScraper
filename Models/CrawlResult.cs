using BookCrawler.API.Models.Enums;

namespace BookCrawler.API.Models;

public class CrawlResult<T>
{
    public List<T> Items { get; set; } = new();
    public Status Status { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
}