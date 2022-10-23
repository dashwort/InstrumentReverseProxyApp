using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentReverseProxyApp
{
    public partial class AddProxy : Form
    {
        public AddProxy(IEnumerable<IPAddress> addresses)
        {
            InitializeComponent();

            // add devices to UI
            DeviceManager.LoadDevices();
                     
            var devices = DeviceManager.Devices.ToArray();
            
            if (devices.Length == 0)
            {
                var manualDeviceOption = new Device();
                manualDeviceOption.Name = "No Configured Devices";
                manualDeviceOption.Id = "AddProxyManually";
                DeviceSelection.Items.Add(manualDeviceOption);
            }

            DeviceSelection.Items.AddRange(devices);
            DeviceSelection.DisplayMember = "Name";
            DeviceSelection.SelectedIndex = 0;

            LocalIPAddresses.Items.AddRange(addresses.ToArray());

            if (LocalIPAddresses.Items.Count > 0)
                LocalIPAddresses.SelectedIndex = 0;

            OnLoad();
        }

        public List<ProxyEntry> ProxyEntries { get; set; }

        void OnLoad()
        {
            LocalPort.Enabled = SpecifyManualPorts.Checked;
            RemotePort.Enabled = SpecifyManualPorts.Checked;
            DeviceSelection.Enabled = !SpecifyManualPorts.Checked;
            ManualPortsLabel.Visible = SpecifyManualPorts.Checked;
        }

        #region buttonsClicked
        void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!NetworkUtility.ValidateIPv4(DeviceIPInput.Text, out IPAddress ip))
                {
                    MessageBox.Show("IP Address is Invalid or Empty");
                    return;
                }

                if (!ValidatePortInput())
                {
                    MessageBox.Show("Invalid Port Input");
                    return;
                }

                GetPortsAsInt(LocalPort.Text, out List<int> localPorts);
                GetPortsAsInt(RemotePort.Text, out List<int> remotePorts);

                if (localPorts.Count != remotePorts.Count)
                {
                    MessageBox.Show("Local and Remote Port Counts Do Not Match");
                    return;
                }

                ProxyEntries = GetProxyEntries(localPorts, remotePorts);

                if (ProxyEntries.Count == 0)
                {
                    MessageBox.Show($"no entries were saved");
                    return;
                }
                    
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region selectedChanged
        void LocalPort_TextChanged(object sender, EventArgs e)
        {
            ValidatePortInput();
        }

        void RemotePort_TextChanged(object sender, EventArgs e)
        {
            ValidatePortInput();
        }

        void DeviceSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = DeviceSelection.SelectedItem as Device;

            if (selectedDevice == null)
                return;

            switch (selectedDevice.Id)
            {
                case "AddProxyManually":
                    break;

                default:
                    LocalPort.Text = selectedDevice.Ports;
                    RemotePort.Text = selectedDevice.Ports;
                    break;
            }
        }

        void SpecifyManualPorts_CheckedChanged(object sender, EventArgs e)
        {
            OnLoad();
        }


        #endregion

        #region methods
        bool ValidatePortInput()
        {
            try
            {
                if (LocalPort.Text.Length == 0 || RemotePort.Text.Length == 0)
                {
                    ManualPortsLabel.Text = "Ports must be equal, separate multiple ports using comma";
                    return false;
                }

                bool parseLocalSuccess = GetPortsAsInt(LocalPort.Text, out List<int> localPorts);
                bool parseRemoteSuccess = GetPortsAsInt(RemotePort.Text, out List<int> remotePorts);

                if (!parseLocalSuccess || !parseRemoteSuccess)
                {
                    ManualPortsLabel.Text = "Ports must be integers";
                    ManualPortsLabel.ForeColor = Color.Red;
                    return false;
                }

                if (localPorts.Count != remotePorts.Count)
                {
                    ManualPortsLabel.Text = "Local and Remote ports must be the same length";
                    ManualPortsLabel.ForeColor = Color.Red;
                    return false;
                }

                if (localPorts.Any(x => x < 0 || x > 65535) ||
                    remotePorts.Any(x => x < 0 || x > 65535))
                {
                    ManualPortsLabel.Text = "Ports must be between 0 and 65535";
                    ManualPortsLabel.ForeColor = Color.Red;
                    return false;
                }

                ManualPortsLabel.Text = "Separate multiple ports using comma";
                ManualPortsLabel.ForeColor = Color.Black;
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        List<ProxyEntry> GetProxyEntries(List<int> localPorts, List<int> remotePorts)
        {
            List<ProxyEntry> proxies = new List<ProxyEntry>();

            for (int i = 0; i < localPorts.Count; i++)
            {
                var proxy = new ProxyEntry();

                proxy.LocalAddress = LocalIPAddresses.SelectedItem.ToString();
                proxy.RemoteAddress = DeviceIPInput.Text;

                proxy.LocalPort = localPorts[i].ToString();
                proxy.RemotePort = remotePorts[i].ToString();

                proxies.Add(proxy);
            }

            return proxies;
        }

        bool GetPortsAsInt(string input, out List<int> ports)
        {
            var splitInput = input.Split(',');
            ports = new List<int>();

            try
            {
                foreach (var port in splitInput)
                {
                    if (!int.TryParse(port, out int localPortAsInt))
                    {
                        return false;
                    }

                    ports.Add(localPortAsInt);
                }
            }
            catch (Exception ex)
            {
                //
            }

            return true;
        }
        #endregion
    }
}
