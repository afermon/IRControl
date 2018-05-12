using System;
using System.Windows.Forms;
using System.IO.Ports;

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
        {
            if (comPort.IsOpen)
            {
                comPort.Close();
                btn_update.Enabled = true;
                cbPorts.Enabled = true;
                btnCnt.Text = "Connect";
            }
            else
            {
                try
                {
                    comPort.PortName = cbPorts.SelectedItem.ToString();
                    comPort.Open();
                    btnCnt.Text = "Stop";
                    btn_update.Enabled = false;
                    cbPorts.Enabled = false;
                    WindowState = FormWindowState.Minimized;
                }
                catch
                {
                    MessageBox.Show("CNX error");
                }
            }
        }

        private void TrayIconDoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            trayicon.Visible = false;
        }

        private void FormMainResize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;

            trayicon.Visible = true;
            Visible = false;
            trayicon.ShowBalloonTip(8);
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
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
