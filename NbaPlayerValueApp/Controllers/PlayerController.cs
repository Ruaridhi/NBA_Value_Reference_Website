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
        // GET REGULAR SEASON PLAYER DATA
        [HttpGet("{playerId}")]
        public async Task<IndividualPlayerRecord> Get(string playerId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var url = ".json?orderBy=\"player_id\"&equalTo=\"" + playerId + "\"";
            var responseTask = httpClient.GetAsync(url);
            responseTask.Wait();

            var result = await responseTask;
            IndividualPlayerRecord finalResponse = new IndividualPlayerRecord();
            if (result.IsSuccessStatusCode)
            {
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
            return finalResponse;
        }
    }
}