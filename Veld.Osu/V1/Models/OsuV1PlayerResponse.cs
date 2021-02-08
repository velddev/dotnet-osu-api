namespace Veld.Osu.V1.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using Veld.Osu.Models;

    /// <summary>
    /// Response model class for legacy v1 api. see <see cref="IOsuPlayer"/> for field documentation.
    /// </summary>
    [DataContract]
    internal class OsuV1PlayerResponse
    {
        [JsonPropertyName("user_id")]
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("username")]
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [JsonPropertyName("join_date")]
        [DataMember(Name = "join_date")]
        public string DateJoined { get; set; }

        [JsonPropertyName("count300")]
        [DataMember(Name = "count300")]
        public string Count300 { get; set; }

        [JsonPropertyName("count100")]
        [DataMember(Name = "count100")]
        public string Count100 { get; set; }

        [JsonPropertyName("count50")]
        [DataMember(Name = "count50")]
        public string Count50 { get; set; }

        [JsonPropertyName("playcount")]
        [DataMember(Name = "playcount")]
        public string PlayCount { get; set; }

        [JsonPropertyName("ranked_score")]
        [DataMember(Name = "ranked_score")]
        public string ScoreRanked { get; set; }

        [JsonPropertyName("total_score")]
        [DataMember(Name = "total_score")]
        public string ScoreTotal { get; set; }

        [JsonPropertyName("pp_rank")]
        [DataMember(Name = "pp_rank")]
        public string RankGlobal { get; set; }

        [JsonPropertyName("level")]
        [DataMember(Name = "level")]
        public string Level { get; set; }

        [JsonPropertyName("pp_raw")]
        [DataMember(Name = "pp_raw")]
        public string PerformancePoints { get; set; }

        [JsonPropertyName("accuracy")]
        [DataMember(Name = "accuracy")]
        public string Accuracy { get; set; }

        [JsonPropertyName("count_rank_ssh")]
        [DataMember(Name = "count_rank_ssh")]
        public string CountRankSsh { get; set; }

        [JsonPropertyName("count_rank_ss")]
        [DataMember(Name = "count_rank_ss")]
        public string CountRankSs { get; set; }

        [JsonPropertyName("count_rank_sh")]
        [DataMember(Name = "count_rank_sh")]
        public string CountRankSh { get; set; }

        [JsonPropertyName("count_rank_s")]
        [DataMember(Name = "count_rank_s")]
        public string CountRankS { get; set; }

        [JsonPropertyName("count_rank_a")]
        [DataMember(Name = "count_rank_a")]
        public string CountRankA { get; set; }

        [JsonPropertyName("country")]
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [JsonPropertyName("pp_country_rank")]
        [DataMember(Name = "pp_country_rank")]
        public string RankCountry { get; set; }

        [JsonPropertyName("total_seconds_played")]
        [DataMember(Name = "total_seconds_played")]
        public string TotalSecondsPlayed { get; set; }

        [JsonPropertyName("events")]
        [DataMember(Name = "events")]
        public List<PlayerEvents> Events { get; set; }
    }

    [DataContract]
    internal class PlayerEvents
    {
        [JsonPropertyName("count_rank_a")]
        [DataMember(Name = "count_rank_a")]
        public string DisplayHtml { get; set; }

        [JsonPropertyName("beatmap_id")]
        [DataMember(Name = "beatmap_id")]
        public string BeatmapId { get; set; }

        [JsonPropertyName("beatmapset_id")]
        [DataMember(Name = "beatmapset_id")]
        public string BeatmapSetId { get; set; }

        [JsonPropertyName("date")]
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [JsonPropertyName("epicfactor")]
        [DataMember(Name = "date")]
        public string EpicFactor { get; set; }
    }
}
