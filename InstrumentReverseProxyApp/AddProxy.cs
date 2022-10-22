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
         
            var manualDeviceOption = new Device();
            manualDeviceOption.Name = "Enter Manually";
            manualDeviceOption.Id = "AddProxyManually";

            DeviceSelection.Items.Add(manualDeviceOption);
            DeviceSelection.Items.AddRange(DeviceManager.Devices.ToArray());
            DeviceSelection.DisplayMember = "Name";
            DeviceSelection.SelectedIndex = 0;

            // add IP addresses to UI
            foreach (var address in addresses)
            {
                LocalIPAddresses.Items.Add(address);
            }

            if (LocalIPAddresses.Items.Count > 0)
                LocalIPAddresses.SelectedIndex = 0;
        }

        public bool ManualMode { get; set; }
        public ProxyEntry[] ProxyEntries { get; set; }

        void AddProxy_Load(object sender, EventArgs e)
        {

        }

        void SaveButton_Click(object sender, EventArgs e)
        {

        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void DeviceSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDevice = DeviceSelection.SelectedItem as Device;

            if (selectedDevice == null)
                return;
            
            switch (selectedDevice.Id)
            {
                case "AddProxyManually":
                    LocalPort.Enabled = true;
                    RemoteAddress.Enabled = true;
                    RemotePort.Enabled = true;
                    break;
                    
                default:
                    LocalPort.Enabled = false;
                    RemoteAddress.Enabled = false;
                    RemotePort.Enabled = false;
                    break;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
