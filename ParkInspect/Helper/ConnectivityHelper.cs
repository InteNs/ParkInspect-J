using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Helper
{
    class ConnectivityHelper
    {
        public Boolean IsAlive()
        {
            try
            {
                using (var c = new WebClient())
                {
                    using (var s = c.OpenRead("http://www.google.nl"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
