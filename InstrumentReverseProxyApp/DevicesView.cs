using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentReverseProxyApp
{
    public partial class DevicesView : UserControl
    {
        public DevicesView()
        {
            InitializeComponent();
            SetDataSources();
            LoadDevices();
        }

        NetworkUtility _netUtility = new NetworkUtility();

        void SetDataSources()
        {
            _netUtility.ListenerStarted += StartedListening;
            _netUtility.ListenerStopped += StoppedListening;
            _netUtility.PortsFound += PortsFound;
        }

        void PortsFound(object sender, EventArgs e)
        {
            try
            {
                var ports = _netUtility.Ports.ToList();

                if (ports.Any())
                {
                    this.Invoke(new Action(() => {
                        PortsFoundLabel.Text = $"{ports.Count} Ports Found";
                        SaveDevice.Enabled = true;
                    }));
                }
                else
                {
                    this.Invoke(new Action(() => {
                        PortsFoundLabel.Text = String.Empty;
                        SaveDevice.Enabled = false;
                    }));
                }
            }
            catch (Exception)
            {
                this.Invoke(new Action(() => {
                    PortsFoundLabel.Text = "Error with capture";
                    SaveDevice.Enabled = false;
                }));
            }
        }

        void StoppedListening(object sender, EventArgs e)
        {
            StopCapture.Enabled = false;
            StartCapture.Enabled = true;
            ListenAddressInput.Enabled = true;
        }

        void StartedListening(object sender, EventArgs e)
        {
            StartCapture.Enabled = false;
            StopCapture.Enabled = true;
            ListenAddressInput.Enabled = false;
        }

        void ListenAddressInput_TextChanged(object sender, EventArgs e)
        {
            bool success;

            try
            {
                if (string.IsNullOrEmpty(ListenAddressInput.Text))
                {
                    ListenAddressInput.BackColor = Color.White;
                    return;
                }


                success = _netUtility.ValidateIPv4(ListenAddressInput.Text, out IPAddress ip);

                if (success)
                {
                    _netUtility.Address = ip;
                    ListenAddressInput.BackColor = Color.White;
                    StartCapture.Enabled = true;
                    return;
                }

                ListenAddressInput.BackColor = Color.LightCoral;
                StartCapture.Enabled = false;
            }
            catch (Exception)
            {
                ListenAddressInput.BackColor = Color.LightCoral;
            }
        }

        void StartCapture_Click(object sender, EventArgs e)
        {
            _netUtility.Start();
            ListenAddressInput.Enabled = false;
        }

        void StopCapture_Click(object sender, EventArgs e)
        {
            _netUtility.Stop();
        }

        private void SaveDevice_Click(object sender, EventArgs e)
        {
            // todo add single reference
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs");
            var deviceSaveUI = new AddDeviceUI(path, _netUtility.Ports);

            deviceSaveUI.ShowDialog(this);
        }

        private void PortsFoundLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ports = new Device();
            var pString = ports.GetPortsAsString(_netUtility.Ports.ToArray());
            var message = $"Ports Found: {pString}";
            MessageBox.Show(message);
        }

        private void LoadDevices()
        {
            var devicesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs");

            DevicesDirectory = new DirectoryInfo(devicesDirectory);

            if (!DevicesDirectory.Exists)
                return;

            Devices = new List<Device>();

            var files = DevicesDirectory.GetFiles("*.device");

            foreach (var file in files)
            {
                var d = new Device();
                Devices.Add(d.Load(file.FullName));
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = Devices;
            DevicesDataView.AutoGenerateColumns = false;
            DevicesDataView.DataSource = bs;
        }

        public DirectoryInfo DevicesDirectory { get; set; }
        public List<Device> Devices { get; set; }

        private void PortsFoundLabel_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
