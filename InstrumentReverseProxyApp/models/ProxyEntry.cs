using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

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
        public string Status 
        {
            get
            {
                return GetStatus();
            } set
            {
                Status = value;
            }
        }

        public string GetStatus()
        {
            if (string.IsNullOrEmpty(LocalAddress) || string.IsNullOrEmpty(LocalPort))
                return "Not Verified";
            
            try
            {
                var ipSuccess = IPAddress.TryParse(LocalAddress, out IPAddress ip);
                var portSuccess = int.TryParse(LocalPort, out int port);

                if (!ipSuccess || !portSuccess)
                    return "Not Verified";
                
                return CheckAvailableServerPort(port) ? "Verified" : "Not Verified";
            }
            catch (Exception)
            {
                return "Not Verified";
            }
        }

        private bool CheckAvailableServerPort(int port)
        {
            bool isAvailable = false;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in tcpConnInfoArray)
            {
                if (endpoint.Port == port)
                {
                    isAvailable = true;
                    break;
                }
            }

            return isAvailable;
        }
    }
}
