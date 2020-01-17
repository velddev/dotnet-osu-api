namespace Veld.Osu
{
    using System.Threading.Tasks;
    using Veld.Osu.Models;

    public interface IOsuApiClient
    {
        /// <summary>
        /// Get a user based on the user's name or identifier.
        /// </summary>
        /// <param name="name">User's name or id</param>
        /// <param name="gamemode">Current game mode to get information about</param>
        /// <returns></returns>
        Task<IOsuPlayer> GetPlayerAsync(string name, GameMode gamemode = GameMode.Osu);
    }
}
