namespace Veld.Osu
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Veld.Osu.Models;
    using System.Threading.Tasks;
    using Miki.Net.Http;
    using System.Text.Json;

    public class OsuApiClient : IOsuApiClient
    {
        private const string BaseUrl = "https://osu.ppy.sh/api/";
        private readonly OsuCredentials credentials;
        private readonly HttpClient httpClient;

        public OsuApiClient(string key)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            credentials = new OsuCredentials(key);
            httpClient = new HttpClient(BaseUrl);
        }

        /// <summary>
        /// Get a user based on the user's name or identifier.
        /// </summary>
        /// <param name="name">User's name or id</param>
        /// <param name="mode">Current game mode to get information about</param>
        /// <returns></returns>
        public async Task<Player> GetPlayerAsync(string name, GameMode mode = GameMode.Osu)
        {
            var response = await httpClient.GetAsync(
                $"v1/get_user?&k={credentials.Key}&u={name}&m={(int)mode}");
            response.HttpResponseMessage.EnsureSuccessStatusCode();

            await using Stream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(response.Body));

            var playersList = await JsonSerializer.DeserializeAsync<List<Player>>(inputStream);
            if(playersList.Any())
            {
                return playersList.First();
            }

            throw new InvalidOperationException("User not found");
        }
    }

    public interface IOsuApiClient
    {
        Task<Player> GetPlayerAsync(string name, GameMode gamemode = GameMode.Osu);
    }
}