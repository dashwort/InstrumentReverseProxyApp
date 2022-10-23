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
            var addProxyUI = new AddProxy(NetworkUtility.GetIPAddresses());
            addProxyUI.ShowDialog(this);

            if (addProxyUI.DialogResult == DialogResult.OK)
            {
                ProxyManager.AddProxySettings(addProxyUI.ProxyEntries);
                ProxyManager_ProxyStarted(sender, e);
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
            var currentRow = CurrentProxies.Rows[e.RowIndex];
            var statusIndex = CurrentProxies.Columns["Status"].Index;

            var cellValue = (string)currentRow.Cells[statusIndex].Value;

            if (cellValue == "Verified")
            {
                currentRow.Cells[statusIndex].Style.BackColor = Color.Green;
            }
            else
            {
                currentRow.Cells[statusIndex].Style.BackColor = Color.Orange;
            }


        }
    }
}
