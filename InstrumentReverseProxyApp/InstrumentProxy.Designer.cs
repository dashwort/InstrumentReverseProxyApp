namespace InstrumentReverseProxyApp
{
    partial class InstrumentProxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentProxy));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddProxy = new System.Windows.Forms.TabPage();
            this.InstrumentIPs = new System.Windows.Forms.ComboBox();
            this.AddInstrument = new System.Windows.Forms.TabPage();
            this.devicesView1 = new InstrumentReverseProxyApp.DevicesView();
            this.tabControl1.SuspendLayout();
            this.AddProxy.SuspendLayout();
            this.AddInstrument.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddProxy);
            this.tabControl1.Controls.Add(this.AddInstrument);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 569);
            this.tabControl1.TabIndex = 0;
            // 
            // AddProxy
            // 
            this.AddProxy.Controls.Add(this.InstrumentIPs);
            this.AddProxy.Location = new System.Drawing.Point(4, 25);
            this.AddProxy.Name = "AddProxy";
            this.AddProxy.Padding = new System.Windows.Forms.Padding(3);
            this.AddProxy.Size = new System.Drawing.Size(1059, 540);
            this.AddProxy.TabIndex = 0;
            this.AddProxy.Text = "Add Proxy";
            this.AddProxy.UseVisualStyleBackColor = true;
            // 
            // InstrumentIPs
            // 
            this.InstrumentIPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstrumentIPs.FormattingEnabled = true;
            this.InstrumentIPs.Location = new System.Drawing.Point(158, 47);
            this.InstrumentIPs.Name = "InstrumentIPs";
            this.InstrumentIPs.Size = new System.Drawing.Size(245, 33);
            this.InstrumentIPs.TabIndex = 0;
            // 
            // AddInstrument
            // 
            this.AddInstrument.Controls.Add(this.devicesView1);
            this.AddInstrument.Location = new System.Drawing.Point(4, 25);
            this.AddInstrument.Name = "AddInstrument";
            this.AddInstrument.Padding = new System.Windows.Forms.Padding(3);
            this.AddInstrument.Size = new System.Drawing.Size(1059, 540);
            this.AddInstrument.TabIndex = 1;
            this.AddInstrument.Text = "Add Instrument";
            this.AddInstrument.UseVisualStyleBackColor = true;
            // 
            // devicesView1
            // 
            this.devicesView1.Devices = null;
            this.devicesView1.DevicesDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("devicesView1.DevicesDirectory")));
            this.devicesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesView1.Location = new System.Drawing.Point(3, 3);
            this.devicesView1.Name = "devicesView1";
            this.devicesView1.Size = new System.Drawing.Size(1053, 534);
            this.devicesView1.TabIndex = 0;
            // 
            // InstrumentProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 569);
            this.Controls.Add(this.tabControl1);
            this.Name = "InstrumentProxy";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.AddProxy.ResumeLayout(false);
            this.AddInstrument.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddProxy;
        private System.Windows.Forms.TabPage AddInstrument;
        private System.Windows.Forms.ComboBox InstrumentIPs;
        private DevicesView devicesView1;
    }
}

