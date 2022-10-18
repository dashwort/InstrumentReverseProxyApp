using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentReverseProxyApp.models
{
    public class ProxyEntry
    {
        public ProxyEntry(List<string> input)
        {
            LocalAddress = input[0];
            LocalPort = input[1];
            RemoteAddress = input[2];
            RemotePort = input[3];
        }

        public ProxyEntry()
        {

        }

        public string LocalAddress { get; set; }
        public string RemoteAddress { get; set; }
        public string LocalPort { get; set; }
        public string RemotePort { get; set; }
    }
}
