using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InstrumentReverseProxyApp.models
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Ports { get; set; }

        public IEnumerable<int> GetPorts()
        {
            var list = new List<int>();
            var ports = Ports.Split(';');

            foreach (var p in ports)
            {
                var sucess = int.TryParse(p, out int pp);

                if (sucess)
                    list.Add(pp);
            }

            return list;
        }

        public string GetPortsAsString(int[] ports)
        {
            if (ports.Length == 0)
                return "None";

            var build = new StringBuilder();

            foreach (var p in ports)
            {
                build.Append($"{p};");
            }

            build.Remove(build.Length - 1, 1);

            return build.ToString();
        }

        public void Save(string FileName)
        {
            var fileInfo = new DirectoryInfo(FileName);

            if (!fileInfo.Parent.Exists)
                fileInfo.Parent.Create();

            using (var writer = new System.IO.StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }

        public Device Load(string FileName)
        {
            var fileInfo = new DirectoryInfo(FileName);

            if (!fileInfo.Parent.Exists)
                fileInfo.Parent.Create();

            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(Device));
                return serializer.Deserialize(stream) as Device;
            }
        }
    }
}
