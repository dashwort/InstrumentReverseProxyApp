using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace InstrumentReverseProxyApp
{
    public static class DeviceManager
    {
        public static DirectoryInfo DevicesDirectory = 
            new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lib"));


        static DeviceManager()
        {
            if (!DevicesDirectory.Exists)
                DevicesDirectory.Create();
        }

        public static IEnumerable<Device> Devices 
        { 
            get 
            { 
                return _devices; 
            }
        }

        static List<Device> _devices = new List<Device>();

        public static void LoadDevices()
        {
            if (!DevicesDirectory.Exists)
                return;

            _devices = new List<Device>();

            var files = DevicesDirectory.GetFiles("*.device");

            foreach (var file in files)
            {
                var d = new Device();
                _devices.Add(d.Load(file.FullName));
            }
        }

        public static void OpenDeviceFolder()
        {
            System.Diagnostics.Process.Start(DevicesDirectory.FullName);
        }
    }
}
