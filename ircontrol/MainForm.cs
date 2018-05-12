using System;
using System.Windows.Forms;
using System.IO.Ports; 
using System.Xml;

namespace IRControl
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMainLoad(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            IrControlManager.GetInstance().SetTbOut(tbEvent);
            OpenConfigClick(null, null);
            BtnUpdatePortsClick(null, null);
        }

        private void BtnUpdatePortsClick(object sender, EventArgs e)
        {
            cbPorts.Items.Clear();
            cbPorts.Enabled = true;

            foreach (var port in IrControlManager.GetInstance().GetPorts())
            {
                cbPorts.Items.Add(port);
                cbPorts.SelectedItem = port;
                btnCnt.Enabled = true;
            }

            if (cbPorts.Items.Count >= 1) return;

            const string def = "No ports detected.";
            cbPorts.Items.Add(def);
            cbPorts.SelectedItem = def;
            cbPorts.Enabled = false;
            btnCnt.Enabled = false;
        }

        private void ComPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            IrControlManager.GetInstance().ProcessCode(comPort.ReadLine());
        }

        private void BtnCntClick(object sender, EventArgs e)
        {/*
            if (_running)
            {
                comPort.Close();
                _running = false;
                btnCnt.Text = "Connect";
                tbEvent.Text = tbEvent.Text + "\r\n CNX Disconected!!!";
                tbEvent.SelectionStart = tbEvent.Text.Length;
                tbEvent.ScrollToCaret();
            }
            else
            {
                if (_configfile)
                {
                    try
                    {
                        comPort.PortName = cbPorts.SelectedItem.ToString();
                        comPort.Open();
                        btnCnt.Text = "Stop";
                        _running = true;
                        this.WindowState = FormWindowState.Minimized;
                        tbEvent.Text = tbEvent.Text + "\r\n CNX Conected!!!";
                        tbEvent.SelectionStart = tbEvent.Text.Length;
                        tbEvent.ScrollToCaret();
                    }
                    catch
                    {
                        MessageBox.Show("CNX error");
                        tbEvent.Text = tbEvent.Text + "\r\n CNX error";
                        tbEvent.SelectionStart = tbEvent.Text.Length;
                        tbEvent.ScrollToCaret();
                        _running = false;
                    }

                }
                else
                {
                    MessageBox.Show("Load XML");
                    tbEvent.Text = tbEvent.Text + "\r\n Load XML";
                    tbEvent.SelectionStart = tbEvent.Text.Length;
                    tbEvent.ScrollToCaret();
                    btn_openxml.PerformClick();
                    _running = false;
                }
            }*/
        }

        private void TrayIconDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            trayicon.Visible = false;
        }

        private void FormMainResize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) return;

            trayicon.Visible = true;
            this.Visible = false;
            trayicon.ShowBalloonTip(8);
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            trayicon.Visible = false;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenConfigClick(object sender, EventArgs e)
        {
            var result = fileDialogXmlConfig.ShowDialog();
            if (result == DialogResult.OK)
                IrControlManager.GetInstance().LoadIrCodes(fileDialogXmlConfig.FileName);
        }
    }
}
