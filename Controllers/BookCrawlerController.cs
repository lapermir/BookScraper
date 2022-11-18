using BookScraper.API.Models;
using Microsoft.AspNetCore.Mvc;
using BookScraper.API.Services;

namespace BookScraper.API.Controller;

[ApiController]
[Route("[controller]")]
public class BookScraperController : ControllerBase
{
    [HttpGet("Index")]
    public List<Book> Index(string bookToSearch)
    {
        Result<Book> output = new();
        output = Scraper.Search(bookToSearch);

        return output.Items;
    }
}
