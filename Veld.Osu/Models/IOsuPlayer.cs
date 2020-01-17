namespace Veld.Osu.Models
{
    using System;
    using System.Collections.Generic;

    public interface IOsuPlayer
    {
        /// <summary>
        /// Player's unique identifier, used to distinguish players from one-another.
        /// </summary>
        long UserId { get; }

        /// <summary>
        /// Player's username
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Date and time when the user joined.
        /// </summary>
        DateTime DateJoined { get; }

        /// <summary>
        /// Total amount of 300s hit.
        /// </summary>
        long Count300 { get; }

        /// <summary>
        /// Total amount of 100s hit.
        /// </summary>
        long Count100 { get; }

        /// <summary>
        /// Total amount of 50s hit.
        /// </summary>
        long Count50 { get; }

        /// <summary>
        /// Amount of maps played.
        /// </summary>
        int PlayCount { get; }

        /// <summary>
        /// Total score on ranked maps.
        /// </summary>
        long ScoreRanked { get; }

        /// <summary>
        /// Total score on all maps.
        /// </summary>
        long ScoreTotal { get; }

        /// <summary>
        /// Rank compared to all of the current osu! players.
        /// </summary>
        int RankGlobal { get; }

        /// <summary>
        /// Current player level.
        /// </summary>
        double Level { get; }

        /// <summary>
        /// Current player PP.
        /// </summary>
        double PerformancePoints { get; }

        /// <summary>
        /// Current player hit accuracy.
        /// </summary>
        double Accuracy { get; }

        /// <summary>
        /// Recent events for the player.
        /// </summary>
        int CountRankSs { get; }

        /// <summary>
        /// Recent events for the player.
        /// </summary>
        int CountRankS { get; }

        /// <summary>
        /// Recent events for the player.
        /// </summary>
        int CountRankA { get; }

        /// <summary>
        /// ISO-2 country code of which the player is from.
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Rank compared to all osu! players sharing the same <see cref="Country"/>.
        /// </summary>
        int RankCountry { get; }

        /// <summary>
        /// Total time played by player.
        /// </summary>
        TimeSpan TimePlayed { get; }

        /// <summary>
        /// Recent events for the player.
        /// </summary>
        public IReadOnlyList<string> Events { get; }
    }
}
