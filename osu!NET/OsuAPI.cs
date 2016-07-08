using Newtonsoft.Json;
using osu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu
{
    public class OsuAPI
    {
        OsuCredentials credentials;

        public OsuAPI(string key)
        {
            credentials = new OsuCredentials(key);
        }

        /// <summary>
        /// Get a user based on the user's name.
        /// </summary>
        /// <param name="name">user's name</param>
        /// <returns></returns>
        public OsuPlayer GetUser(string name, GameMode mode = GameMode.OSU)
        {
            string data = DownloadData("api/get_user?&k=" + credentials.GetKey() + "&u=" + name + "&m=" + (int)mode);
            if (data != "")
            {
                List<OsuPlayer> d = JsonConvert.DeserializeObject<List<OsuPlayer>>(data);
                return d[0];
            }
            return new OsuPlayer();
        }

        /// <summary>
        /// Get a user based on the user's id.
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns></returns>
        public OsuPlayer GetUser(long id, GameMode mode = GameMode.OSU)
        {
            string data = DownloadData("api/get_user?&k=" + credentials.GetKey() + "&u=" + id+ "&m=" + (int)mode);
            if (data != "")
            {
                List<OsuPlayer> d = JsonConvert.DeserializeObject<List<OsuPlayer>>(data);
                return d[0];
            }
            return new OsuPlayer();
        }

        private string DownloadData(string url)
        {
            WebClient c = new WebClient();

            byte[] b;

            b = c.DownloadData("https://osu.ppy.sh/" + url);
            if (b != null)
            {
                string result = Encoding.UTF8.GetString(b);
                return result;
            }
            return "";
        }
    }

    public enum GameMode
    {
        OSU, TAIKO, CATCHTHEBEAT, MANIA
    }
}
