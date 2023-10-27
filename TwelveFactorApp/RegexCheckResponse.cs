using System.Text.RegularExpressions;

namespace TwelveFactorApp
{
    public class RegexCheckResponse
    {
        public IEnumerable<string> Matches { get; set; }

        public RegexCheckResponse() 
        {
            Matches = new List<string>();
        }

        public RegexCheckResponse(IEnumerable<string> matches)
        {
            Matches = matches;
        }
    }
}
