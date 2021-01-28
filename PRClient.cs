using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserGroupSample
{
    public static class PRClient
    {
        public static string AccessToken { get; set; }
        public async static Task<Iterations> GetPullRequestIterations(string baseUrl)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", AccessToken);
            var result = await client.GetAsync($"{baseUrl}/iterations");
            Console.WriteLine(result.StatusCode);
            var stringResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Iterations>(stringResult);
        }

        public async static Task SetPrStatus(string baseUrl, int iteration, string status)
        {

            var url = $"{baseUrl}/iterations/{iteration}/statuses?api-version=6.0-preview.1";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", AccessToken);
            var body = new StatusUpdate()
            {
                State = status,
                Description = "continuous-integration/ticketNumber",
                Context = new Context()
                {
                    Name = "ticketNumber",
                    Genre = "continuous-integration"
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            await client.PostAsync(url, content);

        }
    }
}
