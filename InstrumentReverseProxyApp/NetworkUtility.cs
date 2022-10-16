using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace InstrumentReverseProxyApp
{
    internal class NetworkUtility
    {
        public NetworkUtility()
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += ScanPorts;

            AddressChanged += HandleAddressChanged;
        }

        #region fields
        public EventHandler ListenerStarted;
        public EventHandler ListenerStopped;
        public EventHandler AddressChanged;
        public EventHandler PortsFound;

        System.Timers.Timer _timer;

        List<int> _ports = new List<int>();
        IPAddress _ipAddress = new IPAddress(0);
        #endregion

        #region properties
        public bool ScanRunning { get; set; }
        public IPAddress Address 
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                if (_ipAddress == value)
                    return;

                _ipAddress = value;
                AddressChanged?.Invoke(_ipAddress, EventArgs.Empty);
            }
        }

        public IEnumerable<IPAddress> Addresses
        {
            get
            {
                return GetIPAddresses();
            }
        }

        public IEnumerable<int> Ports
        {
            get
            {
                return _ports.Distinct();
            }
        }
        #endregion

        #region events

        void ScanPorts(object sender, ElapsedEventArgs e)
        {
            if (ScanRunning)
                return;

            if (Address is null)
                return;

            ScanRunning = true;

            var ports = GetPortsInUse(Address);

            foreach (var port in ports)
            {
                if (!_ports.Contains(port))
                {
                    _ports.Add(port);
                    PortsFound?.Invoke(this, e);
                }
            }

            ScanRunning = false;
        }

        void HandleAddressChanged(object sender, EventArgs e)
        {
            _ports.Clear();
        }

        #endregion

        #region methods

        public void Start()
        { 
            ListenerStarted?.Invoke(this, EventArgs.Empty);
            _timer.Start();
        }

        public void Stop()
        {
            ListenerStopped?.Invoke(this, EventArgs.Empty);
            _timer.Stop();
        }

        IEnumerable<IPAddress> GetIPAddresses()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .Where(ip => !ip.ToString().StartsWith("169"));
        }

        public IEnumerable<int> GetPortsInUse(IPAddress ip)
        {
            var ipAddresses = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();

            var ports = new List<int>();

            foreach (var tcp in ipAddresses.GetActiveTcpConnections())
            {
               var localhost = "127.0.0.1";

               if (tcp.RemoteEndPoint.Address.ToString() == localhost)
                   continue;

               if (tcp.RemoteEndPoint.Address.ToString() == ip.ToString())
               {
                   ports.Add(tcp.RemoteEndPoint.Port);
               }
            }

            return ports;
        }

        public bool ValidateIPv4(string ipString, out IPAddress ip)
        {
            ip = new IPAddress(0);
            if (ipString.Count(c => c == '.') != 3) return false;
            return IPAddress.TryParse(ipString, out ip);
        }
        #endregion

    }
}
