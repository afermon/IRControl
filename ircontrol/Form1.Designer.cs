namespace ircontrol
{
    partial class form_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tryicon_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_event = new System.Windows.Forms.TextBox();
            this.btn_cnt = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.com_port = new System.IO.Ports.SerialPort(this.components);
            this.ofd_xmlconfig = new System.Windows.Forms.OpenFileDialog();
            this.btn_openxml = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tryicon_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayicon.BalloonTipText = "App has been minimized just click this icon to open.\r\nVisit http://www.fermongrou" +
    "p.com/arduino";
            this.trayicon.BalloonTipTitle = "FG - IR Control";
            this.trayicon.ContextMenuStrip = this.tryicon_menu;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "FG - IR Control";
            this.trayicon.DoubleClick += new System.EventHandler(this.trayicon_DoubleClick);
            // 
            // tryicon_menu
            // 
            this.tryicon_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tryicon_menu.Name = "tryicon_menu";
            this.tryicon_menu.Size = new System.Drawing.Size(153, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supportToolStripMenuItem.Text = "Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cb_ports
            // 
            this.cb_ports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ports.DisplayMember = "None";
            this.cb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(305, 86);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(121, 21);
            this.cb_ports.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puerto";
            // 
            // tb_event
            // 
            this.tb_event.BackColor = System.Drawing.Color.LimeGreen;
            this.tb_event.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_event.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_event.ForeColor = System.Drawing.Color.White;
            this.tb_event.Location = new System.Drawing.Point(12, 12);
            this.tb_event.Multiline = true;
            this.tb_event.Name = "tb_event";
            this.tb_event.ReadOnly = true;
            this.tb_event.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_event.Size = new System.Drawing.Size(284, 199);
            this.tb_event.TabIndex = 10000;
            this.tb_event.Text = "FG  IR Control\r\nVisit http://www.fermongroup.com\r\nSupporting Open Source Hardware" +
    "\r\nhttp://www.arduino.cc\r\n.";
            this.tb_event.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_cnt
            // 
            this.btn_cnt.Location = new System.Drawing.Point(333, 151);
            this.btn_cnt.Name = "btn_cnt";
            this.btn_cnt.Size = new System.Drawing.Size(75, 23);
            this.btn_cnt.TabIndex = 0;
            this.btn_cnt.Text = "Conect";
            this.btn_cnt.UseVisualStyleBackColor = true;
            this.btn_cnt.Click += new System.EventHandler(this.btn_cnt_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(333, 122);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 10001;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // com_port
            // 
            this.com_port.PortName = "com_port_active";
            this.com_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_port_DataReceived);
            // 
            // ofd_xmlconfig
            // 
            this.ofd_xmlconfig.FileName = "fg_irconfig.xml";
            this.ofd_xmlconfig.Filter = "XML Files (*.xml)|*.xml";
            // 
            // btn_openxml
            // 
            this.btn_openxml.Location = new System.Drawing.Point(323, 193);
            this.btn_openxml.Name = "btn_openxml";
            this.btn_openxml.Size = new System.Drawing.Size(102, 23);
            this.btn_openxml.TabIndex = 10003;
            this.btn_openxml.Text = "Open Config XML";
            this.btn_openxml.UseVisualStyleBackColor = true;
            this.btn_openxml.Click += new System.EventHandler(this.btn_openxml_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(52, 214);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 13);
            this.linkLabel1.TabIndex = 10004;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.fermongroup.com/arduino";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10005;
            this.label2.Text = "IR Control";
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 227);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_openxml);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_cnt);
            this.Controls.Add(this.tb_event);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FG - IR Control";
            this.Load += new System.EventHandler(this.form_main_Load);
            this.Resize += new System.EventHandler(this.form_main_Resize);
            this.tryicon_menu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd_xmlconfig;
        private System.Windows.Forms.Button btn_openxml;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
    }
}

