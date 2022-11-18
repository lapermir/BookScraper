using BookCrawler.API.Models;
using Microsoft.AspNetCore.Mvc;
using BookCrawler.API.Services;

namespace BookCrawler.API.Controller;

[ApiController]
[Route("[controller]")]
public class BookCrawlerController : ControllerBase
{
    [HttpGet("Index")]
    public List<Book> Index(string bookToSearch)
    {
        CrawlResult<Book> output = new();
        output = Crawler.Search(bookToSearch);

        return output.Items;
    }
}
