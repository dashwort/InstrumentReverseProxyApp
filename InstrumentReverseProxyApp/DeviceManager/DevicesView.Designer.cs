namespace InstrumentReverseProxyApp
{
    partial class DevicesView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.DevicesDataView = new System.Windows.Forms.DataGridView();
            this.ButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ClearCaptureButton = new System.Windows.Forms.Button();
            this.SaveDevice = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ListenAddress = new System.Windows.Forms.Label();
            this.ListenAddressInput = new System.Windows.Forms.TextBox();
            this.PortsFoundLabel = new System.Windows.Forms.LinkLabel();
            this.StopCapture = new System.Windows.Forms.Button();
            this.StartCapture = new System.Windows.Forms.Button();
            this.DeviceDirectoryLabel = new System.Windows.Forms.LinkLabel();
            this.PingReplyTime = new System.Windows.Forms.Label();
            this.Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataView)).BeginInit();
            this.ButtonLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.ColumnCount = 4;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.Controls.Add(this.DevicesDataView, 1, 1);
            this.Layout.Controls.Add(this.ButtonLayoutPanel, 2, 1);
            this.Layout.Controls.Add(this.DeviceDirectoryLabel, 1, 3);
            this.Layout.Controls.Add(this.PingReplyTime, 2, 3);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 4;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Layout.Size = new System.Drawing.Size(918, 430);
            this.Layout.TabIndex = 0;
            // 
            // DevicesDataView
            // 
            this.DevicesDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesDataView.Location = new System.Drawing.Point(23, 23);
            this.DevicesDataView.Name = "DevicesDataView";
            this.DevicesDataView.RowHeadersWidth = 51;
            this.Layout.SetRowSpan(this.DevicesDataView, 2);
            this.DevicesDataView.RowTemplate.Height = 24;
            this.DevicesDataView.Size = new System.Drawing.Size(433, 384);
            this.DevicesDataView.TabIndex = 0;
            // 
            // ButtonLayoutPanel
            // 
            this.ButtonLayoutPanel.ColumnCount = 1;
            this.ButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayoutPanel.Controls.Add(this.ClearCaptureButton, 0, 4);
            this.ButtonLayoutPanel.Controls.Add(this.SaveDevice, 0, 3);
            this.ButtonLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.ButtonLayoutPanel.Controls.Add(this.StopCapture, 0, 2);
            this.ButtonLayoutPanel.Controls.Add(this.StartCapture, 0, 1);
            this.ButtonLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayoutPanel.Location = new System.Drawing.Point(462, 23);
            this.ButtonLayoutPanel.Name = "ButtonLayoutPanel";
            this.ButtonLayoutPanel.RowCount = 5;
            this.Layout.SetRowSpan(this.ButtonLayoutPanel, 2);
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonLayoutPanel.Size = new System.Drawing.Size(433, 384);
            this.ButtonLayoutPanel.TabIndex = 1;
            // 
            // ClearCaptureButton
            // 
            this.ClearCaptureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearCaptureButton.Enabled = false;
            this.ClearCaptureButton.Location = new System.Drawing.Point(3, 316);
            this.ClearCaptureButton.Name = "ClearCaptureButton";
            this.ClearCaptureButton.Size = new System.Drawing.Size(427, 65);
            this.ClearCaptureButton.TabIndex = 13;
            this.ClearCaptureButton.Text = "Clear Capture\r\n";
            this.ClearCaptureButton.UseVisualStyleBackColor = true;
            this.ClearCaptureButton.Click += new System.EventHandler(this.ClearCaptureButton_Click);
            // 
            // SaveDevice
            // 
            this.SaveDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveDevice.Enabled = false;
            this.SaveDevice.Location = new System.Drawing.Point(3, 247);
            this.SaveDevice.Name = "SaveDevice";
            this.SaveDevice.Size = new System.Drawing.Size(427, 63);
            this.SaveDevice.TabIndex = 12;
            this.SaveDevice.Text = "Save Device";
            this.SaveDevice.UseVisualStyleBackColor = true;
            this.SaveDevice.Click += new System.EventHandler(this.SaveDevice_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.ListenAddress, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ListenAddressInput, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.PortsFoundLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(427, 100);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // ListenAddress
            // 
            this.ListenAddress.AutoSize = true;
            this.ListenAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenAddress.Location = new System.Drawing.Point(3, 0);
            this.ListenAddress.Name = "ListenAddress";
            this.ListenAddress.Size = new System.Drawing.Size(36, 25);
            this.ListenAddress.TabIndex = 10;
            this.ListenAddress.Text = "IP:";
            // 
            // ListenAddressInput
            // 
            this.ListenAddressInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListenAddressInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenAddressInput.Location = new System.Drawing.Point(45, 3);
            this.ListenAddressInput.Name = "ListenAddressInput";
            this.ListenAddressInput.Size = new System.Drawing.Size(379, 30);
            this.ListenAddressInput.TabIndex = 9;
            this.ListenAddressInput.TextChanged += new System.EventHandler(this.ListenAddressInput_TextChanged);
            // 
            // PortsFoundLabel
            // 
            this.PortsFoundLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.PortsFoundLabel, 2);
            this.PortsFoundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortsFoundLabel.Location = new System.Drawing.Point(3, 80);
            this.PortsFoundLabel.Name = "PortsFoundLabel";
            this.PortsFoundLabel.Size = new System.Drawing.Size(421, 20);
            this.PortsFoundLabel.TabIndex = 11;
            this.PortsFoundLabel.TabStop = true;
            this.PortsFoundLabel.Text = "portsFound";
            this.PortsFoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PortsFoundLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PortsFoundLabel_LinkClicked);
            // 
            // StopCapture
            // 
            this.StopCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopCapture.Enabled = false;
            this.StopCapture.Location = new System.Drawing.Point(3, 178);
            this.StopCapture.Name = "StopCapture";
            this.StopCapture.Size = new System.Drawing.Size(427, 63);
            this.StopCapture.TabIndex = 8;
            this.StopCapture.Text = "Stop Capture";
            this.StopCapture.UseVisualStyleBackColor = true;
            this.StopCapture.Click += new System.EventHandler(this.StopCapture_Click);
            // 
            // StartCapture
            // 
            this.StartCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartCapture.Enabled = false;
            this.StartCapture.Location = new System.Drawing.Point(3, 109);
            this.StartCapture.Name = "StartCapture";
            this.StartCapture.Size = new System.Drawing.Size(427, 63);
            this.StartCapture.TabIndex = 7;
            this.StartCapture.Text = "Start Capture";
            this.StartCapture.UseVisualStyleBackColor = true;
            this.StartCapture.Click += new System.EventHandler(this.StartCapture_Click);
            // 
            // DeviceDirectoryLabel
            // 
            this.DeviceDirectoryLabel.AutoSize = true;
            this.DeviceDirectoryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceDirectoryLabel.Location = new System.Drawing.Point(23, 410);
            this.DeviceDirectoryLabel.Name = "DeviceDirectoryLabel";
            this.DeviceDirectoryLabel.Size = new System.Drawing.Size(433, 20);
            this.DeviceDirectoryLabel.TabIndex = 2;
            this.DeviceDirectoryLabel.TabStop = true;
            this.DeviceDirectoryLabel.Text = "DeviceDirectoryLabel";
            this.DeviceDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeviceDirectoryLabel.Visible = false;
            this.DeviceDirectoryLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeviceDirectoryLabel_LinkClicked);
            // 
            // PingReplyTime
            // 
            this.PingReplyTime.AutoSize = true;
            this.PingReplyTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PingReplyTime.Location = new System.Drawing.Point(462, 410);
            this.PingReplyTime.Name = "PingReplyTime";
            this.PingReplyTime.Size = new System.Drawing.Size(433, 20);
            this.PingReplyTime.TabIndex = 3;
            this.PingReplyTime.Text = "Waiting to ping host...";
            this.PingReplyTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PingReplyTime.Visible = false;
            // 
            // DevicesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Layout);
            this.Name = "DevicesView";
            this.Size = new System.Drawing.Size(918, 430);
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataView)).EndInit();
            this.ButtonLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.DataGridView DevicesDataView;
        private System.Windows.Forms.TableLayoutPanel ButtonLayoutPanel;
        private System.Windows.Forms.Button StopCapture;
        private System.Windows.Forms.Button StartCapture;
        private System.Windows.Forms.Button SaveDevice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label ListenAddress;
        private System.Windows.Forms.TextBox ListenAddressInput;
        private System.Windows.Forms.LinkLabel PortsFoundLabel;
        private System.Windows.Forms.Button ClearCaptureButton;
        private System.Windows.Forms.LinkLabel DeviceDirectoryLabel;
        private System.Windows.Forms.Label PingReplyTime;
    }
}
