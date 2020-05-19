using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaPlayerValueApp.Models
{
    public class YearRecord {

   
        public int id { get; set; }
        public int year { get; set; }
        public string league { get; set; }
        public string player_id { get; set; }
        public string name { get; set; }
        public double score { get; set; }
        public string position { get; set; }
        public int? age { get; set; }
        public string team_abbreviation { get; set; }
        public double? win_shares { get; set; }
        public double? win_shares_48 { get; set; }
        public double? vorp { get; set; }
        public double? bpm { get; set; }
        public int? games { get; set; }
        public double? mpg { get; set; }
        public string team_full_name { get; set; }
        public string team_record { get; set; }
        public string team_result { get; set; }
    }

}
