using InstrumentReverseProxyApp.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InstrumentReverseProxyApp
{
    public partial class DeviceProxy : Form
    {
        public DeviceProxy()
        {
            InitializeComponent();

            ProxyManager = new ProxyManager();
            ProxyManager.ProxyStarted += ProxyManager_ProxyStarted;

            CurrentProxies.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            CurrentProxies.DefaultCellStyle.SelectionForeColor = Color.Black;

            SetVersion();
        }

        void SetVersion()
        {
            this.Text = "RPA v:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        
        ProxyManager ProxyManager;
        

        void ProxyManager_ProxyStarted(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = ProxyManager.ProxyEntries.Values.ToList();
                    CurrentProxies.DataSource = bs;
                    
                    CurrentProxies.AutoGenerateColumns = true;

                    foreach (DataGridViewColumn col in CurrentProxies.Columns)
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void AddProxyButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addProxyUI = new AddProxy(NetworkUtility.GetIPAddresses());
                addProxyUI.ShowDialog(this);

                if (addProxyUI.DialogResult == DialogResult.OK)
                {
                    ProxyManager.AddProxySettings(addProxyUI.ProxyEntries);

                    if (addProxyUI.AddFirewallRule)
                    {
                        var firewallManager = new FirewallManager();

                        foreach (var proxy in addProxyUI.ProxyEntries)
                        {
                            firewallManager.AddRuleFromProxy(proxy);
                        }
                    }
                }

                var blockedPorts = NetworkUtility.CheckForBlockedPorts(addProxyUI.ProxyEntries);
                
                if (blockedPorts.Count > 0)
                {
                    var blockedPortsMessage = new StringBuilder();
                    blockedPortsMessage.AppendLine("The following ports are blocked by your firewall:");
                    blockedPortsMessage.AppendLine();
                    foreach (var port in blockedPorts)
                    {
                        blockedPortsMessage.AppendLine(port.ToString());
                    }
                    blockedPortsMessage.AppendLine();
                    blockedPortsMessage.AppendLine("Please unblock these ports to use the proxy.");
                    MessageBox.Show(this, blockedPortsMessage.ToString(), "Blocked Ports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ProxyManager_ProxyStarted(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during add proxy: {ex.Message}");
            }    
        }

        void RemoveProxyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProxies.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No proxy selected");
                    return;
                }
                
                var selectedRow = CurrentProxies.SelectedRows[0];
                var proxyEntry = selectedRow.DataBoundItem as ProxyEntry;

                ProxyManager.DeleteProxySettings(proxyEntry);

                ProxyManager_ProxyStarted(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RefreshStatusButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CurrentProxies_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                var currentRow = CurrentProxies.Rows[e.RowIndex];
                var properties = new string[] { "ConnectedStatus", "LocalPortAvailiabilty", "RemotePortAvailiabilty" };


                foreach (var prop in properties)
                {
                    var statusIndex = CurrentProxies.Columns[prop].Index;



                    var cellValue = (string)currentRow.Cells[statusIndex].Value;

                    if (!cellValue.ToLower().Contains("not"))
                    {
                        currentRow.Cells[statusIndex].Style.BackColor = Color.Green;
                        continue;
                    }


                    currentRow.Cells[statusIndex].Style.BackColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during row added: {ex.Message}");
            }


        }
    }
}
