using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraper.Data;

namespace WebScraper.Workers
{
    class Scraper
    {
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<string> scrappedElement = new List<string>();

            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOptions);
            foreach (Match match in matches)
            {
                if (!scrapeCriteria.parts.Any())
                {
                    scrappedElement.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeCriteria.parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);
                        if (matchedPart.Success)
                        {
                            scrappedElement.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return scrappedElement;

        }
    }
}
