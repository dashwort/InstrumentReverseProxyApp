using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentReverseProxyApp
{
    internal class ProxyManager
    {
        public ProxyManager()
        {
            StartCapture += StartCaptureM;
            StopCapture += StopCaptureM;
        }

        public EventHandler StartCapture;
        public EventHandler StopCapture;
        public EventHandler ProxyEntryFound;

        public StringBuilder Output;

        public bool CaptureStarted { get; set; }
        public bool DelimterReached { get; set; }

        void StartCaptureM(object sender, EventArgs e)
        {
            CaptureStarted = true;
            DelimterReached = false;
            Output = new StringBuilder();
        }

        void StopCaptureM(object sender, EventArgs e)
        {
            CaptureStarted = false;
        }

        public void GetProxySettings()
        {
            StartCapture?.Invoke(this, EventArgs.Empty);

            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = @"/c netsh interface portproxy show all";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.UseShellExecute = false;
            p.OutputDataReceived += ParseConsoleOutput;
            p.Start();
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            p.WaitForExit();

            StopCapture?.Invoke(this, EventArgs.Empty);

            MessageBox.Show(Output.ToString());
        }

        void ParseConsoleOutput(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data) || !CaptureStarted)
                return;

            if (e.Data.Contains("---"))
            {
                DelimterReached = true;
                return;
            }

            if (!DelimterReached)
                return;

            ProcessProxyText(e.Data);
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
    }
}
