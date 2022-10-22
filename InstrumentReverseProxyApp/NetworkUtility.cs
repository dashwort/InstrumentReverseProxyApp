using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.NetworkInformation;
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
            _pingTimer = new System.Timers.Timer(1000);

            _timer.Elapsed += ScanPorts;
            _pingTimer.Elapsed += PingHost;

            AddressChanged += HandleAddressChanged;
            _pingTimer.Start();
        }

        #region fields
        public EventHandler ListenerStarted;
        public EventHandler ListenerStopped;
        public EventHandler AddressChanged;
        public EventHandler PortsFound;
        public EventHandler CaptureCleared;

        System.Timers.Timer _timer;
        System.Timers.Timer _pingTimer;

        List<int> _ports = new List<int>();
        IPAddress _ipAddress = new IPAddress(0);
        #endregion

        #region properties
        public bool ScanRunning { get; set; }
        public bool PingRunning { get; set; }
        public bool Reachable { get; set; }
        public int Latency { get; set; }
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

        public Timer PingTimer
        {
            get { return _pingTimer; }
        }

        public void ClearPorts()
        {
            _ports.Clear();
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

            try
            {
                var ports = GetPortsInUse(Address);

                foreach (var port in ports)
                {
                    if (!_ports.Contains(port))
                    {
                        _ports.Add(port);
                        PortsFound?.Invoke(this, e);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ScanRunning = false;
        }

        void PingHost(object sender, ElapsedEventArgs e)
        {
            if (PingRunning)
                return;

            if (Address is null)
            {
                Reachable = false;
                Latency = 0;
                return;
            }

            PingRunning = true;

            try
            {
                PingHost(Address.ToString());
            }
            catch (Exception)
            {
                //;
            }

            PingRunning = false;
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

        public static IEnumerable<IPAddress> GetIPAddresses()
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

        public bool PingHost(string ip)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                if (ValidateIPv4(ip, out IPAddress address))
                {
                    if (ip == "0.0.0.0")
                        return false;
                    
                    pinger = new Ping();
                    PingReply reply = pinger.Send(ip);
                    Reachable = reply.Status == IPStatus.Success;
                    Latency = (int)reply.RoundtripTime;
                }
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
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
