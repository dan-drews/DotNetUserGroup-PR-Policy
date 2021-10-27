using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserGroupSample.Controllers
{
    [ApiController]
    public class PullRequestController : ControllerBase
    {

        [HttpPost]
        [Route("PullRequest/Created")]
        public async Task Post(PullRequestPayload body)
        {
            var prTitle = body.Resource.Title;
            await ValidatePrTitle(body.Resource.Url, prTitle);
        }

        [HttpPost]
        [Route("PullRequest/Updated")]
        public async Task Updated(PRUpdated body)
        {
            var prTitle = body.Resource.Title;
            await ValidatePrTitle(body.Resource.Url, prTitle);
        }

        private static async Task ValidatePrTitle(string baseUrl, string prTitle)
        {
            var iterations = await PRClient.GetPullRequestIterations(baseUrl);
            string pattern = @"ado-\d+ ";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (r.IsMatch(prTitle))
            {
                await PRClient.SetPrStatus(baseUrl, iterations.Count, "succeeded");
            }
            else
            {
                await PRClient.SetPrStatus(baseUrl, iterations.Count, "failed");
            }
        }
    }
}
