using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
            SetUi();
        }

        void LoadDevices()
        {
            DeviceManager.LoadDevices();
            DeviceDirectoryLabel.Text = "Open Device Library Folder";
            DeviceDirectoryLabel.Visible = true;

            BindingSource bs = new BindingSource();
            bs.DataSource = DeviceManager.Devices.ToList();
            DevicesDataView.AutoGenerateColumns = true;
            DevicesDataView.DataSource = bs;
            DevicesDataView.Columns["Id"].Visible = false;
        }

        void SetUi()
        {
            ClearCaptureButton.Enabled = false;
            SaveDevice.Enabled = false;
            StartCapture.Enabled = true;
            PortsFoundLabel.Text = String.Empty;
        }

        NetworkUtility _netUtility = new NetworkUtility();

        void SetDataSources()
        {
            _netUtility.ListenerStarted += StartedListening;
            _netUtility.ListenerStopped += StoppedListening;
            _netUtility.PortsFound += PortsFound;
            _netUtility.PingTimer.Elapsed += PingTimerElapsed;
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
                        ClearCaptureButton.Enabled = true;
                    }));

                    return;
                }

                this.Invoke(new Action(() => {
                    PortsFoundLabel.Text = String.Empty;
                    SaveDevice.Enabled = false;
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() => {
                    PortsFoundLabel.Text = "Error with capture";
                    SaveDevice.Enabled = false;
                    ClearCaptureButton.Enabled = false;
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

        void PingTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_netUtility.Reachable)
                {
                    this.Invoke(new Action(() => {
                        PingReplyTime.Text = $"Ping latency: {_netUtility.Latency}ms";
                    }));

                    return;
                }

                this.Invoke(new Action(() => {
                    PingReplyTime.Text = $"Trying to ping host: {_netUtility.Address}";
                    return;
                }));
            }
            catch (Exception)
            {
                // 
            }
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
                    PingReplyTime.Visible = true;
                    return;
                }

                ListenAddressInput.BackColor = Color.LightCoral;
                PingReplyTime.Visible = false;
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

        void PortsFoundLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var ports = new Device();
                var pString = ports.GetPortsAsString(_netUtility.Ports.ToArray());
                var message = $"Ports Found: {pString}";
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
        }

        void ClearCaptureButton_Click(object sender, EventArgs e)
        {
            try
            {
                _netUtility.Stop();
                _netUtility.ClearPorts();
                SetUi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        void DeviceDirectoryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(DeviceManager.DevicesDirectory.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
