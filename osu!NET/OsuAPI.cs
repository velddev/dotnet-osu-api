using Newtonsoft.Json;
using osu.objects;
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
        public User GetUser(string name)
        {
            string data = DownloadData("api/get_user?&k=" + credentials.GetKey() + "&u=" + name);
            if (data != "")
            {
                List<User> d = JsonConvert.DeserializeObject<List<User>>(data);
                return d[0];
            }
            return new User();
        }

        /// <summary>
        /// Get a user based on the user's id.
        /// </summary>
        /// <param name="id">user's id</param>
        /// <returns></returns>
        public User GetUser(long id)
        {
            string data = DownloadData("api/get_user?&k=" + credentials.GetKey() + "&u=" + id);
            if (data != "")
            {
                List<User> d = JsonConvert.DeserializeObject<List<User>>(data);
                return d[0];
            }
            return new User();
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
}
