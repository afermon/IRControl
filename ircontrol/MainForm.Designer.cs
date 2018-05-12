namespace ircontrol
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
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_event = new System.Windows.Forms.TextBox();
            this.btn_cnt = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.com_port = new System.IO.Ports.SerialPort(this.components);
            this.ofd_xmlconfig = new System.Windows.Forms.OpenFileDialog();
            this.btn_openxml = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // cb_ports
            // 
            this.cb_ports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ports.DisplayMember = "None";
            this.cb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(93, 9);
            this.cb_ports.Margin = new System.Windows.Forms.Padding(6);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(230, 33);
            this.cb_ports.TabIndex = 2;
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
            // tb_event
            // 
            this.tb_event.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.tb_event.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_event.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_event.ForeColor = System.Drawing.Color.White;
            this.tb_event.Location = new System.Drawing.Point(357, 15);
            this.tb_event.Margin = new System.Windows.Forms.Padding(6);
            this.tb_event.Multiline = true;
            this.tb_event.Name = "tb_event";
            this.tb_event.ReadOnly = true;
            this.tb_event.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_event.Size = new System.Drawing.Size(568, 163);
            this.tb_event.TabIndex = 10000;
            // 
            // btn_cnt
            // 
            this.btn_cnt.Location = new System.Drawing.Point(173, 54);
            this.btn_cnt.Margin = new System.Windows.Forms.Padding(6);
            this.btn_cnt.Name = "btn_cnt";
            this.btn_cnt.Size = new System.Drawing.Size(150, 44);
            this.btn_cnt.TabIndex = 0;
            this.btn_cnt.Text = "Connect";
            this.btn_cnt.UseVisualStyleBackColor = true;
            this.btn_cnt.Click += new System.EventHandler(this.BtnCntClick);
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
            this.btn_update.Click += new System.EventHandler(this.BtnUpdateClick);
            // 
            // com_port
            // 
            this.com_port.PortName = "com_port_active";
            this.com_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComPortDataReceived);
            // 
            // ofd_xmlconfig
            // 
            this.ofd_xmlconfig.FileName = "fg_irconfig.xml";
            this.ofd_xmlconfig.Filter = "XML Files (*.xml)|*.xml";
            // 
            // btn_openxml
            // 
            this.btn_openxml.Location = new System.Drawing.Point(11, 110);
            this.btn_openxml.Margin = new System.Windows.Forms.Padding(6);
            this.btn_openxml.Name = "btn_openxml";
            this.btn_openxml.Size = new System.Drawing.Size(312, 44);
            this.btn_openxml.TabIndex = 10003;
            this.btn_openxml.Text = "Open Config XML";
            this.btn_openxml.UseVisualStyleBackColor = true;
            this.btn_openxml.Click += new System.EventHandler(this.BtnOpenxmlClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_ports);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_openxml);
            this.panel1.Controls.Add(this.btn_cnt);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 166);
            this.panel1.TabIndex = 10004;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 195);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_event);
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
        private System.Windows.Forms.ComboBox cb_ports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_event;
        private System.Windows.Forms.Button btn_cnt;
        private System.Windows.Forms.Button btn_update;
        private System.IO.Ports.SerialPort com_port;
        private System.Windows.Forms.ContextMenuStrip tryicon_menu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd_xmlconfig;
        private System.Windows.Forms.Button btn_openxml;
        private System.Windows.Forms.Panel panel1;
    }
}

