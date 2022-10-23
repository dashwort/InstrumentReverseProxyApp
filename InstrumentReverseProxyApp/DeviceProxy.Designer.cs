namespace InstrumentReverseProxyApp
{
    partial class DeviceProxy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceProxy));
            this.HomePageTabs = new System.Windows.Forms.TabControl();
            this.AddProxy = new System.Windows.Forms.TabPage();
            this.TabLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ProxyAddTable = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentProxies = new System.Windows.Forms.DataGridView();
            this.AddProxyButton = new System.Windows.Forms.Button();
            this.RemoveProxyButton = new System.Windows.Forms.Button();
            this.RefreshStatusButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.AddInstrument = new System.Windows.Forms.TabPage();
            this.devicesView1 = new InstrumentReverseProxyApp.DevicesView();
            this.HomePageTabs.SuspendLayout();
            this.AddProxy.SuspendLayout();
            this.TabLayout.SuspendLayout();
            this.ProxyAddTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProxies)).BeginInit();
            this.AddInstrument.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomePageTabs
            // 
            this.HomePageTabs.Controls.Add(this.AddProxy);
            this.HomePageTabs.Controls.Add(this.AddInstrument);
            this.HomePageTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePageTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomePageTabs.Location = new System.Drawing.Point(0, 0);
            this.HomePageTabs.Name = "HomePageTabs";
            this.HomePageTabs.SelectedIndex = 0;
            this.HomePageTabs.Size = new System.Drawing.Size(1067, 569);
            this.HomePageTabs.TabIndex = 0;
            // 
            // AddProxy
            // 
            this.AddProxy.Controls.Add(this.TabLayout);
            this.AddProxy.Controls.Add(this.button4);
            this.AddProxy.Location = new System.Drawing.Point(4, 29);
            this.AddProxy.Name = "AddProxy";
            this.AddProxy.Padding = new System.Windows.Forms.Padding(3);
            this.AddProxy.Size = new System.Drawing.Size(1059, 536);
            this.AddProxy.TabIndex = 0;
            this.AddProxy.Text = "Add Proxy";
            this.AddProxy.UseVisualStyleBackColor = true;
            // 
            // TabLayout
            // 
            this.TabLayout.ColumnCount = 2;
            this.TabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabLayout.Controls.Add(this.ProxyAddTable, 0, 0);
            this.TabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabLayout.Location = new System.Drawing.Point(3, 3);
            this.TabLayout.Name = "TabLayout";
            this.TabLayout.RowCount = 2;
            this.TabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabLayout.Size = new System.Drawing.Size(1053, 530);
            this.TabLayout.TabIndex = 3;
            // 
            // ProxyAddTable
            // 
            this.ProxyAddTable.ColumnCount = 3;
            this.TabLayout.SetColumnSpan(this.ProxyAddTable, 2);
            this.ProxyAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.ProxyAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ProxyAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ProxyAddTable.Controls.Add(this.CurrentProxies, 0, 0);
            this.ProxyAddTable.Controls.Add(this.AddProxyButton, 0, 1);
            this.ProxyAddTable.Controls.Add(this.RemoveProxyButton, 1, 1);
            this.ProxyAddTable.Controls.Add(this.RefreshStatusButton, 2, 1);
            this.ProxyAddTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyAddTable.Location = new System.Drawing.Point(3, 3);
            this.ProxyAddTable.Name = "ProxyAddTable";
            this.ProxyAddTable.RowCount = 2;
            this.TabLayout.SetRowSpan(this.ProxyAddTable, 2);
            this.ProxyAddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProxyAddTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ProxyAddTable.Size = new System.Drawing.Size(1047, 524);
            this.ProxyAddTable.TabIndex = 1;
            // 
            // CurrentProxies
            // 
            this.CurrentProxies.AllowUserToAddRows = false;
            this.CurrentProxies.AllowUserToDeleteRows = false;
            this.CurrentProxies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProxyAddTable.SetColumnSpan(this.CurrentProxies, 3);
            this.CurrentProxies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentProxies.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CurrentProxies.Location = new System.Drawing.Point(3, 3);
            this.CurrentProxies.MultiSelect = false;
            this.CurrentProxies.Name = "CurrentProxies";
            this.CurrentProxies.ReadOnly = true;
            this.CurrentProxies.RowHeadersWidth = 51;
            this.CurrentProxies.RowTemplate.Height = 24;
            this.CurrentProxies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CurrentProxies.Size = new System.Drawing.Size(1041, 413);
            this.CurrentProxies.TabIndex = 0;
            this.CurrentProxies.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CurrentProxies_RowsAdded);
            // 
            // AddProxyButton
            // 
            this.AddProxyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddProxyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProxyButton.Location = new System.Drawing.Point(3, 422);
            this.AddProxyButton.MaximumSize = new System.Drawing.Size(0, 100);
            this.AddProxyButton.Name = "AddProxyButton";
            this.AddProxyButton.Size = new System.Drawing.Size(342, 99);
            this.AddProxyButton.TabIndex = 1;
            this.AddProxyButton.Text = "Add Proxy";
            this.AddProxyButton.UseVisualStyleBackColor = true;
            this.AddProxyButton.Click += new System.EventHandler(this.AddProxyButton_Click);
            // 
            // RemoveProxyButton
            // 
            this.RemoveProxyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveProxyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveProxyButton.Location = new System.Drawing.Point(351, 422);
            this.RemoveProxyButton.MaximumSize = new System.Drawing.Size(0, 100);
            this.RemoveProxyButton.Name = "RemoveProxyButton";
            this.RemoveProxyButton.Size = new System.Drawing.Size(343, 99);
            this.RemoveProxyButton.TabIndex = 2;
            this.RemoveProxyButton.Text = "Remove Proxy";
            this.RemoveProxyButton.UseVisualStyleBackColor = true;
            this.RemoveProxyButton.Click += new System.EventHandler(this.RemoveProxyButton_Click);
            // 
            // RefreshStatusButton
            // 
            this.RefreshStatusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RefreshStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshStatusButton.Location = new System.Drawing.Point(700, 422);
            this.RefreshStatusButton.MaximumSize = new System.Drawing.Size(0, 100);
            this.RefreshStatusButton.Name = "RefreshStatusButton";
            this.RefreshStatusButton.Size = new System.Drawing.Size(344, 99);
            this.RefreshStatusButton.TabIndex = 3;
            this.RefreshStatusButton.Text = "Refresh Status";
            this.RefreshStatusButton.UseVisualStyleBackColor = true;
            this.RefreshStatusButton.Click += new System.EventHandler(this.RefreshStatusButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(479, 434);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(8, 8);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // AddInstrument
            // 
            this.AddInstrument.Controls.Add(this.devicesView1);
            this.AddInstrument.Location = new System.Drawing.Point(4, 29);
            this.AddInstrument.Name = "AddInstrument";
            this.AddInstrument.Padding = new System.Windows.Forms.Padding(3);
            this.AddInstrument.Size = new System.Drawing.Size(1059, 536);
            this.AddInstrument.TabIndex = 1;
            this.AddInstrument.Text = "Add Instrument";
            this.AddInstrument.UseVisualStyleBackColor = true;
            // 
            // devicesView1
            // 
            this.devicesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesView1.Location = new System.Drawing.Point(3, 3);
            this.devicesView1.Name = "devicesView1";
            this.devicesView1.Size = new System.Drawing.Size(1053, 530);
            this.devicesView1.TabIndex = 0;
            // 
            // DeviceProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 569);
            this.Controls.Add(this.HomePageTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1085, 616);
            this.Name = "DeviceProxy";
            this.Text = "Daves Reverse Proxy App";
            this.HomePageTabs.ResumeLayout(false);
            this.AddProxy.ResumeLayout(false);
            this.TabLayout.ResumeLayout(false);
            this.ProxyAddTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentProxies)).EndInit();
            this.AddInstrument.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl HomePageTabs;
        private System.Windows.Forms.TabPage AddProxy;
        private System.Windows.Forms.TabPage AddInstrument;
        private DevicesView devicesView1;
        private System.Windows.Forms.TableLayoutPanel TabLayout;
        private System.Windows.Forms.TableLayoutPanel ProxyAddTable;
        private System.Windows.Forms.DataGridView CurrentProxies;
        private System.Windows.Forms.Button AddProxyButton;
        private System.Windows.Forms.Button RemoveProxyButton;
        private System.Windows.Forms.Button RefreshStatusButton;
        private System.Windows.Forms.Button button4;
    }
}

