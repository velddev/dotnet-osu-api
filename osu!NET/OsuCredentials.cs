using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu
{
    public class OsuCredentials
    {
        string key;

        public OsuCredentials(string key)
        {
            this.key = key;
        }

        public string GetKey()
        {
            return key;
        }
    }
}
