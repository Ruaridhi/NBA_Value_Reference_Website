using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaPlayerValueApp.Models;
using Newtonsoft.Json;
// using Newtonsoft.Json.Linq.JObject;

namespace NbaPlayerValueApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        [HttpGet]
        public async Task<IndividualPlayerRecord> Get()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var responseTask = httpClient.GetAsync(".json");
            responseTask.Wait();

            IndividualPlayerRecord response = await GetFinalResponse(responseTask);

        //     List<YearRecord> response = await GetFinalResponse(responseTask);

        //     return response;
        // }

        // GET REGULAR SEASON PLAYER DATA
        [HttpGet("{playerId}")]
        public async Task<IndividualPlayerRecord> Get(string playerId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var url = ".json?orderBy=\"player_id\"&equalTo=\"" + playerId + "\"";
            var responseTask = httpClient.GetAsync(url);
            responseTask.Wait();

            IndividualPlayerRecord response = await GetFinalResponse(responseTask);

                string responseBody = await result.Content.ReadAsStringAsync();
                Dictionary<string, RSFullFirebaseModel> initialResponse = JsonConvert.DeserializeObject<Dictionary<string, RSFullFirebaseModel>>(responseBody);
                bool isfirstEntry = true;
                foreach (KeyValuePair<string, RSFullFirebaseModel> entry in initialResponse)
                {
                    if (isfirstEntry) {
                        finalResponse.name = entry.Value.name;
                        isfirstEntry = false;
                    }
                }
            }
            else //web api sent error response 
            { }
            return finalResponse;
        }

        [HttpGet("{teamAbb}/{year}")]
        public async Task<IndividualPlayerRecord> Get(string teamAbb, int year)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var url = ".json?orderBy=\"team_abbreviation\"&equalTo=\"" + teamAbb + "&orderBy=\"year\"&equalTo=" + year;
            var responseTask = httpClient.GetAsync(url);
            responseTask.Wait();

            IndividualPlayerRecord response = await GetFinalResponse(responseTask);

        //     return response;
        // }


        private async Task<IndividualPlayerRecord> GetFinalResponse(Task<HttpResponseMessage> responseTask) 
        {
            var result = await responseTask;
            IndividualPlayerRecord finalResponse = new IndividualPlayerRecord();
            if (result.IsSuccessStatusCode)
            {
                string responseBody = await result.Content.ReadAsStringAsync();
                var searchResults = JsonConvert.DeserializeObject<IndividualPlayerRecord>(responseBody);
                Console.WriteLine(searchResults);
                // JObject json = JObject.Parse(responseBody);
                // finalResponse.name = json.name;

                // Dictionary<string, IndividualPlayerRecord> initialResponse = JsonConvert.DeserializeObject<Dictionary<string, IndividualPlayerRecord>>(responseBody);
                // foreach (KeyValuePair<string, IndividualPlayerRecord> entry in initialResponse)
                // {
                //     finalResponse.Add(entry.Value);
                // }
            }
            else //web api sent error response 
            {

            }

            return finalResponse;

        }
    }
}