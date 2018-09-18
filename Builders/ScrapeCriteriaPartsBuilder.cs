using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraper.Data;

namespace WebScraper.Builders
{
    class ScrapeCriteriaPartsBuilder
    {
        private string _regex;
        private RegexOptions _regexOption;

        public ScrapeCriteriaPartsBuilder()
        {
            setDefault();
        }

        private void setDefault()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }

        public ScrapeCriteriaPartsBuilder withRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaPartsBuilder withRegexOption(RegexOptions rOption)
        {
            _regexOption = rOption;
            return this;
        }

        public ScrapeCriteriaParts Build()
        {
            ScrapeCriteriaParts part = new ScrapeCriteriaParts
            {
                Regex = _regex,
                RegexOption = _regexOption
            };
            return part;
        }
    }
}
