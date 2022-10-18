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

                if (success)
                    Console.WriteLine($"Added proxy dictionary entry. " +
                        $"LocalAddress: {entry.LocalAddress}, LocalPort: {entry.LocalPort}");
                else
                    Console.WriteLine($"Failed to add proxy dictionary entry. " +
                        $"LocalAddress: {entry.LocalAddress}, LocalPort: {entry.LocalPort}");
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

        public Process GetCmdProcess (string arguments)
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

        public bool AddProxySettings(ProxyEntry p)
        {
            bool success = false;

            if (p is null)
                return false;

            try
            {
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
                process.StartInfo.Verb = "runas";
                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();

                GetProxySettings();

                if (ProxyEntries.ContainsKey($"{p.LocalAddress}:{p.LocalPort}"))
                    success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during proxy capture: {ex.Message}");
            }

            return success;
        }

        #region getProxyHelperMethods
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
