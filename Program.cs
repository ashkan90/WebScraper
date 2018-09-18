using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Builders;
using WebScraper.Data;
using WebScraper.Workers;

namespace WebScraper
{
    class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter which city would you like to scrape information from: ");
                var craiglistCity = Console.ReadLine();

                Console.WriteLine("Please enter the craiglist category that you would like to scrape: ");
                var craiglistCategoryname = Console.ReadLine();

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"http://{craiglistCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craiglistCategoryname}");

                    ScrapeCriteria criteria = new ScrapeCriteriaBuilder()
                        .withData(content)
                        .withRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                        .withRegexOption(RegexOptions.ExplicitCapture)
                        .withPart(new ScrapeCriteriaPartsBuilder()
                            .withRegex(@">(.*?)</a>")
                            .withRegexOption(RegexOptions.Singleline)
                            .Build())
                        .withPart(new ScrapeCriteriaPartsBuilder()
                            .withRegex(@"href=\""(.*?)\""")
                            .withRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();
                    var scrapedElement = scraper.Scrape(criteria);
                    if (scrapedElement.Any())
                    {
                        foreach (var scrappedElement in scrapedElement)
                            Console.WriteLine(scrappedElement);             
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified scrape criteria.");
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
