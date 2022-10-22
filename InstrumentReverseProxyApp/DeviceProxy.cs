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

        private void HomePageTabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            var colour = Color.FromArgb(31, 31, 31, 255);
            TabPage page = HomePageTabs.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(colour), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        void AddProxyButton_Click(object sender, EventArgs e)
        {
            var addProxyUI = new AddProxy(NetworkUtility.GetIPAddresses());
            addProxyUI.ShowDialog(this);
        }

        void RemoveProxyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProxies.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No proxy added");
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

        private void DeviceProxy_Load(object sender, EventArgs e)
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
