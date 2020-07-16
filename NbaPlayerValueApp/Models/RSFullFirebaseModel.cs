using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NbaPlayerValueApp.Models
{
  public class RSFullFirebaseModel {

   [JsonProperty("age")]
   public int? age { get; set; }
   [JsonProperty("bpm")]
   public double? bpm { get; set; }
   [JsonProperty("games")]
   public int? games { get; set; }
   [JsonProperty("id")]
   public string id { get; set; }
   [JsonProperty("league")]
   public string league { get; set; }
   [JsonProperty("mpg")]
   public double? mpg { get; set; }
   [JsonProperty("name")]
   public string name { get; set; }
   [JsonProperty("player_id")]
   public string? player_id { get; set; }
   [JsonProperty("position")]
   public string? position { get; set; }
   [JsonProperty("score")]
   public double? score { get; set; }
   [JsonProperty("team_abbreviation")]
   public string? team_abbreviation { get; set; }
   [JsonProperty("team_full_name")]
   public string? team_full_name { get; set; }
   [JsonProperty("team_record")]
   public string? team_record { get; set; }
   [JsonProperty("team_result")]
   public string? team_result { get; set; }
   [JsonProperty("vorp")]
   public double? vorp { get; set; }
   [JsonProperty("win_shares")]
   public double? win_shares { get; set; }
   [JsonProperty("win_shares_48")]
   public double? win_shares_48 { get; set; }
   [JsonProperty("year")]
   public int year { get; set; }

  }   
}