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
    public partial class InstrumentProxy : Form
    {
        public InstrumentProxy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = new ProxyManager();

            var proxy = new ProxyEntry();
            proxy.LocalAddress = "localhost";
            proxy.LocalPort = "3366";

            proxy.RemoteAddress = "192.168.1.224";
            proxy.RemotePort = "3390";

            var success = p.AddProxySettings(proxy);

            if (success)
                MessageBox.Show("Success");
        }
    }
}
