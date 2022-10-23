namespace InstrumentReverseProxyApp
{
    partial class AddProxy
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
            this.label2 = new System.Windows.Forms.Label();
            this.LocalPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DeviceSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LocalIPAddresses = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RemotePort = new System.Windows.Forms.TextBox();
            this.SpecifyManualPorts = new System.Windows.Forms.CheckBox();
            this.DeviceIPInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ManualPortsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocalPort
            // 
            this.LocalPort.Enabled = false;
            this.LocalPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalPort.Location = new System.Drawing.Point(141, 191);
            this.LocalPort.Name = "LocalPort";
            this.LocalPort.Size = new System.Drawing.Size(349, 27);
            this.LocalPort.TabIndex = 4;
            this.LocalPort.TextChanged += new System.EventHandler(this.LocalPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listen IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(24, 305);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(201, 49);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(289, 305);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(201, 49);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DeviceSelection
            // 
            this.DeviceSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceSelection.FormattingEnabled = true;
            this.DeviceSelection.Location = new System.Drawing.Point(141, 112);
            this.DeviceSelection.Name = "DeviceSelection";
            this.DeviceSelection.Size = new System.Drawing.Size(349, 28);
            this.DeviceSelection.TabIndex = 8;
            this.DeviceSelection.SelectedIndexChanged += new System.EventHandler(this.DeviceSelection_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Device Ports";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocalIPAddresses
            // 
            this.LocalIPAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalIPAddresses.FormattingEnabled = true;
            this.LocalIPAddresses.Location = new System.Drawing.Point(143, 27);
            this.LocalIPAddresses.Name = "LocalIPAddresses";
            this.LocalIPAddresses.Size = new System.Drawing.Size(345, 28);
            this.LocalIPAddresses.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Remote Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemotePort
            // 
            this.RemotePort.Enabled = false;
            this.RemotePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemotePort.Location = new System.Drawing.Point(141, 229);
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(349, 27);
            this.RemotePort.TabIndex = 7;
            this.RemotePort.TextChanged += new System.EventHandler(this.RemotePort_TextChanged);
            // 
            // SpecifyManualPorts
            // 
            this.SpecifyManualPorts.AutoSize = true;
            this.SpecifyManualPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpecifyManualPorts.Location = new System.Drawing.Point(23, 158);
            this.SpecifyManualPorts.Name = "SpecifyManualPorts";
            this.SpecifyManualPorts.Size = new System.Drawing.Size(187, 24);
            this.SpecifyManualPorts.TabIndex = 10;
            this.SpecifyManualPorts.Text = "Enter Ports Manually";
            this.SpecifyManualPorts.UseVisualStyleBackColor = true;
            this.SpecifyManualPorts.CheckedChanged += new System.EventHandler(this.SpecifyManualPorts_CheckedChanged);
            // 
            // DeviceIPInput
            // 
            this.DeviceIPInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceIPInput.Location = new System.Drawing.Point(141, 71);
            this.DeviceIPInput.Name = "DeviceIPInput";
            this.DeviceIPInput.Size = new System.Drawing.Size(349, 27);
            this.DeviceIPInput.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Device IP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManualPortsLabel
            // 
            this.ManualPortsLabel.AutoSize = true;
            this.ManualPortsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualPortsLabel.Location = new System.Drawing.Point(140, 270);
            this.ManualPortsLabel.Name = "ManualPortsLabel";
            this.ManualPortsLabel.Size = new System.Drawing.Size(179, 16);
            this.ManualPortsLabel.TabIndex = 13;
            this.ManualPortsLabel.Text = "Separate ports using comma";
            this.ManualPortsLabel.Visible = false;
            // 
            // AddProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 367);
            this.Controls.Add(this.ManualPortsLabel);
            this.Controls.Add(this.DeviceIPInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpecifyManualPorts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LocalPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemotePort);
            this.Controls.Add(this.DeviceSelection);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.LocalIPAddresses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddProxy";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Proxy UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox DeviceSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LocalPort;
        private System.Windows.Forms.ComboBox LocalIPAddresses;
        private System.Windows.Forms.TextBox RemotePort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SpecifyManualPorts;
        private System.Windows.Forms.TextBox DeviceIPInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ManualPortsLabel;
    }
}