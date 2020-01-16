namespace Veld.Osu.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Player
    {
        /// <summary>
        /// Player's unique identifier, used to distinguish players from one-another.
        /// </summary>
        [DataMember(Name = "user_id")]
        public string UserId { get; }

        [DataMember(Name = "username")]
        public string Username { get; }
        
        public string count300 = "0";
        
        public string count100 = "0";
        
        public string count50 = "0";
        
        public string playcount = "0";
        
        public string ranked_score = "0";
        
        public string total_score = "0";
        
        public string pp_rank = "0";
        
        public string level = "0";
        
        public string pp_raw = "0";
        
        public string accuracy = "0";
        
        public string count_rank_ss = "0";
        
        public string count_rank_s= "0";
        
        public string count_rank_a= "0";
        
        public string country = "US";
        
        public string pp_country_rank= "0";
        
        public List<string> events = new List<string>();
    }
}
