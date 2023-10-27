using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace TwelveFactorApp
{
    [Route("[controller]")]
    [ApiController]
    public class RegexCheckController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegexCheckResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CheckAgainstRegex([FromBody] RegexCheckRequest request)
        {
            IList<string> matches = new List<string>();

            try
            {
                Regex.ValueMatchEnumerator matchEnumerator = Regex.EnumerateMatches(request.Input, request.Regex);
                foreach (ValueMatch match in matchEnumerator)
                {
                    matches.Add(request.Input.Substring(match.Index, match.Length));
                }
            }
            catch (RegexParseException e)
            {
                return BadRequest($"Failed to parse regular expression: {e.Message}");
            }

            return Ok(new RegexCheckResponse(matches));
        }
    }
}
