using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NbaPlayerValueApp.Models
{
    public class IndividualPlayerRecord {


        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("careerValue")]
        public double careerValue { get; set; }
        [JsonProperty("peakMultiplier")]
        public double peakMultiplier { get; set; }
        [JsonProperty("bestSevenPlayoff")]
        public double bestSevenPlayoff { get; set; }
        // [JsonProperty("regularSeason")]
        // public Dictionary<int?, PlayerRegularSeasonRecord>  regularSeason { get; set; }
    }
    
    public class PlayerRegularSeasonRecord {

        [JsonProperty("regularSeasonValue")]
        public double regularSeasonValue { get; set; }
        [JsonProperty("team")]
        public string team { get; set; }
    }
}
