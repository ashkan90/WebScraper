using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraper.Data
{
    class ScrapeCriteria
    {
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOptions { get; set; }
        public List<ScrapeCriteriaParts> parts { get; set; }

        public ScrapeCriteria()
        {
            parts = new List<ScrapeCriteriaParts>();
        }

    }
}
