using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaPlayerValueApp.Models;
using Newtonsoft.Json;

namespace NbaPlayerValueApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        [HttpGet]
        public async Task<List<YearRecord>> Get()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var responseTask = httpClient.GetAsync(".json");
            responseTask.Wait();

            List<YearRecord> response = await GetFinalResponse(responseTask);

            return response;

     
        }

        [HttpGet("{playerId}")]
        public async Task<List<YearRecord>> Get(string playerId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://nba-tester.firebaseio.com/");
            var url = ".json?orderBy=\"player_id\"&equalTo=\"" + playerId + "\"";
            var responseTask = httpClient.GetAsync(url);
            responseTask.Wait();

            List<YearRecord> response = await GetFinalResponse(responseTask);

                return response;
        }

        private async Task<List<YearRecord>> GetFinalResponse(Task<HttpResponseMessage> responseTask) 
        {
            var result = await responseTask;
            List<YearRecord> finalResponse = new List<YearRecord>();
            if (result.IsSuccessStatusCode)
            {

                string responseBody = await result.Content.ReadAsStringAsync();
                Dictionary<string, YearRecord> initialResponse = JsonConvert.DeserializeObject<Dictionary<string, YearRecord>>(responseBody);
                foreach (KeyValuePair<string, YearRecord> entry in initialResponse)
                {
                    finalResponse.Add(entry.Value);
                }
            }
            else //web api sent error response 
            {

            }

            return finalResponse;

        }
    }
}