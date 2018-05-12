namespace IRControl
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tryicon_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEvent = new System.Windows.Forms.TextBox();
            this.btnCnt = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.fileDialogXmlConfig = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.tryicon_menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayicon.BalloonTipText = "App has been minimized just click this icon to open.";
            this.trayicon.BalloonTipTitle = "Arduino IR Control";
            this.trayicon.ContextMenuStrip = this.tryicon_menu;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "Arduino IR Control";
            this.trayicon.DoubleClick += new System.EventHandler(this.TrayIconDoubleClick);
            // 
            // tryicon_menu
            // 
            this.tryicon_menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tryicon_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tryicon_menu.Name = "tryicon_menu";
            this.tryicon_menu.Size = new System.Drawing.Size(150, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(149, 36);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // cbPorts
            // 
            this.cbPorts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPorts.DisplayMember = "None";
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(93, 9);
            this.cbPorts.Margin = new System.Windows.Forms.Padding(6);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(230, 33);
            this.cbPorts.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puerto";
            // 
            // tbEvent
            // 
            this.tbEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.tbEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEvent.ForeColor = System.Drawing.Color.White;
            this.tbEvent.Location = new System.Drawing.Point(357, 15);
            this.tbEvent.Margin = new System.Windows.Forms.Padding(6);
            this.tbEvent.Multiline = true;
            this.tbEvent.Name = "tbEvent";
            this.tbEvent.ReadOnly = true;
            this.tbEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEvent.Size = new System.Drawing.Size(568, 163);
            this.tbEvent.TabIndex = 10000;
            this.tbEvent.Text = "Arduino IR Control";
            // 
            // btnCnt
            // 
            this.btnCnt.Location = new System.Drawing.Point(173, 54);
            this.btnCnt.Margin = new System.Windows.Forms.Padding(6);
            this.btnCnt.Name = "btnCnt";
            this.btnCnt.Size = new System.Drawing.Size(150, 44);
            this.btnCnt.TabIndex = 0;
            this.btnCnt.Text = "Connect";
            this.btnCnt.UseVisualStyleBackColor = true;
            this.btnCnt.Click += new System.EventHandler(this.BtnCntClick);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(11, 54);
            this.btn_update.Margin = new System.Windows.Forms.Padding(6);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(150, 44);
            this.btn_update.TabIndex = 10001;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.BtnUpdatePortsClick);
            // 
            // comPort
            // 
            this.comPort.PortName = "com_port_active";
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComPortDataReceived);
            // 
            // fileDialogXmlConfig
            // 
            this.fileDialogXmlConfig.FileName = "IRControlConfig.xml";
            this.fileDialogXmlConfig.Filter = "XML Files (*.xml)|*.xml";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenConfig);
            this.panel1.Controls.Add(this.cbPorts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCnt);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 166);
            this.panel1.TabIndex = 10004;
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(11, 110);
            this.btnOpenConfig.Margin = new System.Windows.Forms.Padding(6);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(312, 44);
            this.btnOpenConfig.TabIndex = 10002;
            this.btnOpenConfig.Text = "Open XML Config";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.OpenConfigClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 195);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduino IR Control";
            this.Load += new System.EventHandler(this.FormMainLoad);
            this.Resize += new System.EventHandler(this.FormMainResize);
            this.tryicon_menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEvent;
        private System.Windows.Forms.Button btnCnt;
        private System.Windows.Forms.Button btn_update;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.ContextMenuStrip tryicon_menu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileDialogXmlConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenConfig;
    }
}

