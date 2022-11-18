using BookScraper.API.Models;
using BookScraper.API.Models.Enums;
using HtmlAgilityPack;

namespace BookScraper.API.Services;
public static class Scraper
{
    private static string site { get; set; } = "https://openlibrary.org";
    private static string url { get; set; } = "https://openlibrary.org/search?mode=everything&q=";
    private static List<Book> booksList { get; set; } = new();

    private static HtmlWeb web = new();

    public static Result<Book> Search(string bookToSearch)
    {
        Result<Book> output = new();

        HtmlDocument doc = web.Load($"{url}={bookToSearch}");

        var titles = doc.DocumentNode.SelectNodes("//h3[@class='booktitle']");
        var links = doc.DocumentNode.SelectNodes("//a[@class='results']");

        var titlesLinks = titles.Zip(links, (t, l) => new { Title = t, Link = l });

        if (titlesLinks.Count() == 0)
        {
            output.Messages.Add("Book Not Found!");
            output.Status = Status.NotFound;
        }

        int counter = 1;
        foreach (var item in titlesLinks)
        {
            if (!item.Link.Attributes["href"].Value.Contains("authors"))
            {
                var book = new Book()
                {
                    Id = counter,
                    Title = item.Title.InnerText.Trim(),
                    URL = site + item.Link.Attributes["href"].Value
                };

                output.Items.Add(book);
                counter++;

            }
        }
        output.Messages.Add($"Found {titlesLinks.Count()} books.");
        output.Status = Status.Success;
        return output;
    }
}