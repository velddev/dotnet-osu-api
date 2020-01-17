namespace Veld.Osu.V1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Veld.Osu.Models;
    using System.Threading.Tasks;
    using Miki.Net.Http;
    using System.Text.Json;
    using Veld.Osu.V1.Models;

    /// <summary>
    /// Legacy implementation of the Osu API
    /// </summary>
    public class OsuApiClientV1 : IOsuApiClient
    {
        private const string BaseUrl = "https://osu.ppy.sh/api/";
        private readonly OsuCredentials credentials;
        private readonly IHttpClient httpClient;

        public OsuApiClientV1(string key)
            : this(key, new HttpClient(BaseUrl))
        {}
        public OsuApiClientV1(string key, IHttpClient client)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            credentials = new OsuCredentials(key);
            httpClient = client;
        }

        /// <inheritdoc/>
        public async Task<IOsuPlayer> GetPlayerAsync(string name, GameMode mode = GameMode.Osu)
        {
            var response = await httpClient.GetAsync(
                $"get_user?k={credentials.Key}&u={name}&m={(int)mode}");
            response.HttpResponseMessage.EnsureSuccessStatusCode();

            await using Stream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(response.Body));

            var playersList = await JsonSerializer.DeserializeAsync<List<OsuV1PlayerResponse>>(inputStream);
            if(playersList.Any())
            {
                return new OsuV1Player(playersList.First());
            }

            throw new InvalidOperationException("User not found");
        }
    }
}