using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentReverseProxyApp
{
    internal class ProxyManager
    {
        public ProxyManager()
        {
            StartProxyCapture += StartProxyCaptureM;
            StopProxyCapture += StopProxyCaptureM;

            ProxyEntryFound += CaptureProxy;
            ProxyEntries = new ConcurrentDictionary<string, ProxyEntry>();
        }

        #region properties
        public EventHandler StartProxyCapture;
        public EventHandler StopProxyCapture;
        public EventHandler ProxyEntryFound;
        public EventHandler ProxyManagerError;

        public StringBuilder Output;

        public bool ProxyCaptureStarted { get; set; }
        public bool DelimterReached { get; set; }

        public ConcurrentDictionary<string, ProxyEntry> ProxyEntries { get; set; }
        #endregion

        #region events
        void StartProxyCaptureM(object sender, EventArgs e)
        {
            ProxyCaptureStarted = true;
            DelimterReached = false;
            Output = new StringBuilder();
        }

        void StopProxyCaptureM(object sender, EventArgs e)
        {
            ProxyCaptureStarted = false;
        }

        void CaptureProxy(object sender, EventArgs e)
        {
            try
            {
                var entry = sender as ProxyEntry;
                var success = ProxyEntries.TryAdd($"{entry.LocalAddress}:{entry.LocalPort}", entry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy capture: {ex.Message}");
            }
        }
        #endregion


        public void GetProxySettings()
        {
            if (ProxyCaptureStarted)
                return;

            StartProxyCapture?.Invoke(this, EventArgs.Empty);

            try
            {
                ProxyEntries.Clear();
                var args = @"/c netsh interface portproxy show all";
                var p = GetCmdProcess(args);

                p.OutputDataReceived += ParseGetProxyConsoleOutput;
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy capture: {ex.Message}");
            }

            StopProxyCapture?.Invoke(this, EventArgs.Empty);
        }

        public bool AddProxySettings(ProxyEntry p)
        {
            bool success = false;

            if (p is null)
                return false;

            try
            {
                Console.WriteLine($"Calling add proxy: {p.LocalAddress}:{p.LocalPort}");

                GetProxySettings();

                if (ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                {
                    Console.WriteLine($"Warning proxy was already added, skipping add action");
                    return false;
                }
                    
                var args = @"/c netsh interface portproxy add v4tov4 "
                    + $"listenport={p.LocalPort} listenaddress={p.LocalAddress} "
                    + $"connectport={p.RemotePort} connectaddress={p.RemoteAddress}";

                Console.WriteLine($"Command line args:");
                Console.WriteLine(args);

                var process = GetCmdProcess(args);

                process.OutputDataReceived += ParseGetProxyConsoleOutput;
                process.ErrorDataReceived += ParseGetProxyError;
                process.StartInfo.Verb = "runas";
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();

                GetProxySettings();

                if (ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                    success = true;

                if (!success)
                    Console.WriteLine($"Failed to add proxy {p.LocalAddress}:{p.LocalPort}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy add: {ex.Message}");
            }

            return success;
        }

        public bool AddProxySettings(IEnumerable<ProxyEntry> proxies)
        {
            bool success = false;

            try
            {
                GetProxySettings();

                foreach (var p in proxies)
                {
                    Console.WriteLine($"Calling add proxy: {p.LocalAddress}:{p.LocalPort}");

                    if (ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                    {
                        Console.WriteLine($"Warning proxy was already added, skipping add action");
                        return false;
                    }

                    var args = @"/c netsh interface portproxy add v4tov4 "
                        + $"listenport={p.LocalPort} listenaddress={p.LocalAddress} "
                        + $"connectport={p.RemotePort} connectaddress={p.RemoteAddress}";

                    Console.WriteLine($"Command line args:");
                    Console.WriteLine(args);

                    var process = GetCmdProcess(args);

                    process.OutputDataReceived += ParseGetProxyConsoleOutput;
                    process.ErrorDataReceived += ParseGetProxyError;
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.BeginOutputReadLine();
                    process.WaitForExit();

                    GetProxySettings();

                    if (ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                        success = true;

                    if (!success)
                        Console.WriteLine($"Failed to add proxy {p.LocalAddress}:{p.LocalPort}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy add: {ex.Message}");
            }

            return success;
        }

        public bool DeleteProxySettings(ProxyEntry p)
        {
            bool success = false;

            if (p is null)
                return false;

            try
            {
                Console.WriteLine($"Calling delete proxy: {p.LocalAddress}:{p.LocalPort}");

                GetProxySettings();

                if (!ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                {
                    Console.WriteLine($"Warning proxy was not found, skipping delete action");
                    return false;
                }

                var args = @"/c netsh interface portproxy delete v4tov4 "
                    + $"listenport={p.LocalPort} listenaddress={p.LocalAddress} ";

                Console.WriteLine($"Command line args:");
                Console.WriteLine(args);

                var process = GetCmdProcess(args);

                process.OutputDataReceived += ParseGetProxyConsoleOutput;
                process.StartInfo.Verb = "runas";
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();

                GetProxySettings();

                if (!ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                    success = true;

                if (!success)
                    Console.WriteLine($"Failed to delete proxy {p.LocalAddress}:{p.LocalPort}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy delete: {ex.Message}");
            }

            return success;
        }

        #region getProxyHelperMethods
        public Process GetCmdProcess(string arguments)
        {
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = arguments;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.UseShellExecute = false;
            return p;
        }

        void ParseGetProxyError(object sender, DataReceivedEventArgs e)
        {
            try
            {
                ProxyManagerError?.Invoke(sender, e);
                Console.WriteLine($"Error from running cmd process: {e.Data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during parse proxy error: {ex.Message}");
            }
        }

        void ParseGetProxyConsoleOutput(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Data) || !ProxyCaptureStarted)
                    return;

                if (e.Data.Contains("---"))
                {
                    DelimterReached = true;
                    return;
                }

                if (!DelimterReached)
                    return;

                Console.WriteLine(e.Data);
                ProcessProxyText(e.Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing console out: {ex.Message}");
            }
        }

        void ProcessProxyText(string input)
        {
            var subStrings = new List<string>();

            var parts = input.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                var part = parts[i];

                if (string.IsNullOrEmpty(part))
                    continue;

                subStrings.Add(part);
            }

            ProxyEntryFound?.Invoke(new ProxyEntry(subStrings), EventArgs.Empty);
        }
        #endregion
    }
}
