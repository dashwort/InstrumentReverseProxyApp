using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentReverseProxyApp
{
    public partial class AddDeviceUI : Form
    {
        public AddDeviceUI(string path)
        {
            InitializeComponent();
            DeviceDirectory = new DirectoryInfo(path);

            Device = new Device();
            Device.Id = Guid.NewGuid().ToString();
        }

        public AddDeviceUI(string path, IEnumerable<int> ports)
        {
            InitializeComponent();
            DeviceDirectory = new DirectoryInfo(path);

            Device = new Device();

            Device.Id = Guid.NewGuid().ToString();
            Device.Ports = Device.GetPortsAsString(ports.ToArray());

            ApplyDevice();
        }

        void ApplyDevice()
        {
            NameInput.Text = Device.Name;
            ManufacturerInput.Text = Device.Manufacturer;
            PortsInput.Text = Device.Ports;
        }

        public Device Device { get; set; }
        public DirectoryInfo DeviceDirectory { get; set; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var filePath = Path.Combine(DeviceDirectory.FullName, $"{Device.Id}.device");

            Device.Save(filePath);

            if (File.Exists(filePath))
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameInput_TextChanged(object sender, EventArgs e)
        {
            Device.Name = NameInput.Text;
        }

        private void ManufacturerInput_TextChanged(object sender, EventArgs e)
        {
            Device.Manufacturer = ManufacturerInput.Text;
        }

        private void PortsInput_TextChanged(object sender, EventArgs e)
        {
            Device.Ports = PortsInput.Text;
        }
    }
}
