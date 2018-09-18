using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraper.Data;

namespace WebScraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaParts> _parts;

        public ScrapeCriteriaBuilder()
        {
            setDefault();
        }

        private void setDefault()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaParts>();
        }

        public ScrapeCriteriaBuilder withData(string data)
        {
            _data = data;
            return this;
        }

        public ScrapeCriteriaBuilder withRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaBuilder withRegexOption(RegexOptions rOption)
        {
            _regexOption = rOption;
            return this;
        }

        public ScrapeCriteriaBuilder withPart(ScrapeCriteriaParts part)
        {
            _parts.Add(part);
            return this;
        }

        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrape = new ScrapeCriteria {
                Data = _data,
                Regex = _regex,
                RegexOptions = _regexOption,
                parts = _parts
            };

            return scrape;
        }
    }
}
