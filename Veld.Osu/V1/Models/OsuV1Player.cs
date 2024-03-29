﻿namespace Veld.Osu.V1.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Veld.Osu.Models;

  internal class OsuV1Player : IOsuPlayer
  {
    /// <inheritdoc />
    public long UserId { get; }

    /// <inheritdoc />
    public string Username { get; }

    /// <inheritdoc />
    public DateTime DateJoined { get; }

    /// <inheritdoc />
    public long Count300 { get; }

    /// <inheritdoc />
    public long Count100 { get; }

    /// <inheritdoc />
    public long Count50 { get; }

    /// <inheritdoc />
    public int PlayCount { get; }

    /// <inheritdoc />
    public long ScoreRanked { get; }

    /// <inheritdoc />
    public long ScoreTotal { get; }

    /// <inheritdoc />
    public int RankGlobal { get; }

    /// <inheritdoc />
    public double Level { get; }

    /// <inheritdoc />
    public double PerformancePoints { get; }

    /// <inheritdoc />
    public double Accuracy { get; }

    /// <inheritdoc />
    public int CountRankSs { get; }

    /// <inheritdoc />
    public int CountRankS { get; }

    /// <inheritdoc />
    public int CountRankA { get; }

    /// <inheritdoc />
    public string Country { get; }

    /// <inheritdoc />
    public int RankCountry { get; }

    /// <inheritdoc />
    public TimeSpan TimePlayed { get; }

    /// <inheritdoc />
    public IReadOnlyList<IPlayerEvents> Events { get; }

    internal class InternalPlayerEvents : IPlayerEvents
    {
      /// <inheritdoc />
      public string DisplayHtml { get; set; }

      /// <inheritdoc />
      public int? BeatmapId { get; set; }

      /// <inheritdoc />
      public int? BeatmapSetId { get; set; }

      /// <inheritdoc />
      public DateTime Date { get; set; }

      /// <inheritdoc />
      public int EpicFactor { get; set; }
    }

    internal OsuV1Player(OsuV1PlayerResponse response)
    {
      if (response == null)
      {
        throw new ArgumentNullException(nameof(response));
      }

      UserId = long.Parse(response.UserId);
      Username = response.Username;
      DateJoined = DateTime.Parse(response.DateJoined);
      Count300 = long.Parse(response.Count300);
      Count100 = long.Parse(response.Count100);
      Count50 = long.Parse(response.Count50);
      PlayCount = int.Parse(response.PlayCount);
      ScoreRanked = long.Parse(response.ScoreRanked);
      ScoreTotal = long.Parse(response.ScoreTotal);
      RankGlobal = int.Parse(response.RankGlobal);
      Level = double.Parse(response.Level);
      PerformancePoints = double.Parse(response.PerformancePoints);
      Accuracy = double.Parse(response.Accuracy);
      CountRankSs = int.Parse(response.CountRankSs);
      CountRankS = int.Parse(response.CountRankS);
      CountRankA = int.Parse(response.CountRankA);
      Country = response.Country;
      TimePlayed = TimeSpan.FromSeconds(long.Parse(response.TotalSecondsPlayed));
      RankCountry = int.Parse(response.RankCountry);
      Events = response.Events.Select(x => new InternalPlayerEvents
      {
        DisplayHtml = x.DisplayHtml,
        Date = DateTime.Parse(x.Date),
        BeatmapSetId = x.BeatmapSetId != null ? int.Parse(x.BeatmapSetId) : null,
        BeatmapId = x.BeatmapId != null ? int.Parse(x.BeatmapId) : null,
        EpicFactor = int.Parse(x.EpicFactor)
      }).Cast<IPlayerEvents>()
          .ToList();
    }
  }
}
