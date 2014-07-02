using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  // para usara puertos seriales
using System.Xml;  // trabajar con xml
using System.IO;// trabajar xml
using WindowsInput;// send key
using System.Diagnostics;
namespace ircontrol
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();
        }
        //variables
        string xmlconfigfile;
        bool configfile = false;
        bool running = false;
        bool notfoundcmd = false;
        private void form_main_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            getports();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            getports();
        }
        public void getports() // obtiene los puertos COM utilizables por el arduino disponibles
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                cb_ports.Items.Clear();
                foreach (string port in ports)
                {
                    cb_ports.Items.Add(port);
                    cb_ports.SelectedItem = port;
                    tb_event.Text = tb_event.Text + "\r\n > Port " + port + " in list";
                    tb_event.SelectionStart = tb_event.Text.Length;
                    tb_event.ScrollToCaret();
                }
            }
            catch
            {
                MessageBox.Show("Error COM Port");
                tb_event.Text = tb_event.Text + "\r\n Error COM Port";
                tb_event.SelectionStart = tb_event.Text.Length;
                tb_event.ScrollToCaret();
 
            }
        }
        private void com_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            incmd(com_port.ReadLine());
        }
        private void btn_cnt_Click(object sender, EventArgs e)
        {
            if (running)
            {
                com_port.Close();
                running = false;
                btn_cnt.Text = "Connect";
                tb_event.Text = tb_event.Text + "\r\n CNX Disconected!!!";
                tb_event.SelectionStart = tb_event.Text.Length;
                tb_event.ScrollToCaret();
            }
            else
            {
                if (configfile)
                {
                    try
                    {
                        com_port.PortName = cb_ports.SelectedItem.ToString();
                        com_port.Open();
                        btn_cnt.Text = "Stop";
                        running = true;
                        this.WindowState = FormWindowState.Minimized;
                        tb_event.Text = tb_event.Text + "\r\n CNX Conected!!!";
                        tb_event.SelectionStart = tb_event.Text.Length;
                        tb_event.ScrollToCaret();
                    }
                    catch
                    {
                        MessageBox.Show("CNX error");
                        tb_event.Text = tb_event.Text + "\r\n CNX error";
                        tb_event.SelectionStart = tb_event.Text.Length;
                        tb_event.ScrollToCaret();
                        running = false;
                    }

                }
                else
                {
                    MessageBox.Show("Load XML");
                    tb_event.Text = tb_event.Text + "\r\n Load XML";
                    tb_event.SelectionStart = tb_event.Text.Length;
                    tb_event.ScrollToCaret();
                    btn_openxml.PerformClick();
                    running = false;
                }
            }
        }
        public void incmd( string _incmd)
        {
            tb_event.Text = tb_event.Text + "\r\nCode >" + _incmd + "<";
            tb_event.SelectionStart = tb_event.Text.Length;
            tb_event.ScrollToCaret();
            send_key(_incmd.Trim());
        }
        public void send_key(string code)
        {
            notfoundcmd = true;
            if (configfile)
            {
               try
                {
                    XmlDocument xmlconfigdocument = new XmlDocument();
                    xmlconfigdocument.Load(xmlconfigfile);
                    XmlNodeList fg_ircontrol = xmlconfigdocument.GetElementsByTagName("fg_ircontrol");
                    XmlNodeList lista = ((XmlElement)fg_ircontrol[0]).GetElementsByTagName("code");
                    foreach (XmlElement nodo in lista)
                    {
                        int i = 0;
                        XmlNodeList _description = nodo.GetElementsByTagName("description");
                        XmlNodeList _hexcode = nodo.GetElementsByTagName("hexcode");
                        XmlNodeList _sendkeycmd = nodo.GetElementsByTagName("sendkeycmd");
                        if (code == _hexcode[i].InnerText)
                            {
                                    virtualkeysend(_sendkeycmd[i].InnerText.Trim()); 
                                    tb_event.Text = tb_event.Text + "\r\nSend >" + _description[i].InnerText;
                                    tb_event.SelectionStart = tb_event.Text.Length;
                                    tb_event.ScrollToCaret();
                                    notfoundcmd = false;
                            }
                        i++;
                     }
                }
                catch
                {
                    MessageBox.Show("Error in XML file,Check it!");
                    tb_event.Text = tb_event.Text + "\r\nError in XML file,Check it!";
                    tb_event.SelectionStart = tb_event.Text.Length;
                    tb_event.ScrollToCaret();
                }
                if (notfoundcmd)
                {
                    tb_event.Text = tb_event.Text + "\r\n Not found CMD in XML file,Check it!";
                    tb_event.SelectionStart = tb_event.Text.Length;
                    tb_event.ScrollToCaret();
                }
            }
            else
            {
                MessageBox.Show("Load XML");
                tb_event.Text = tb_event.Text + "\r\nLoad XML";
                tb_event.SelectionStart = tb_event.Text.Length;
                tb_event.ScrollToCaret();
                btn_openxml.PerformClick();
            }
        }

        private void trayicon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            trayicon.Visible = false;
        }

        private void form_main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayicon.Visible = true;
                this.Visible = false;
                trayicon.ShowBalloonTip(8);
            }   
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            trayicon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_openxml_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd_xmlconfig.ShowDialog();
            if (result == DialogResult.OK)
            {
                xmlconfigfile = ofd_xmlconfig.FileName;
                configfile = true;
                tb_event.Text = tb_event.Text + "\r\nXML >"+ xmlconfigfile;
                
            }
            else
            {
                configfile = false;
                tb_event.Text = tb_event.Text + "\r\nAny XML loaded";
            }
            tb_event.SelectionStart = tb_event.Text.Length;
            tb_event.ScrollToCaret();
        }
        public void virtualkeysend(string codigo)
        {
            switch (codigo)
            {
                case "CLOSE": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4); break;
                case "ACCEPT": InputSimulator.SimulateKeyPress(VirtualKeyCode.ACCEPT); break;
                case "ADD": InputSimulator.SimulateKeyPress(VirtualKeyCode.ADD); break;
                case "APPS": InputSimulator.SimulateKeyPress(VirtualKeyCode.APPS); break;
                case "ATTN": InputSimulator.SimulateKeyPress(VirtualKeyCode.ATTN); break;
                case "BACK": InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK); break;
                case "BROWSER_BACK": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_BACK); break;
                case "BROWSER_FAVORITES": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_FAVORITES); break;
                case "BROWSER_FORWARD": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_FORWARD); break;
                case "BROWSER_HOME": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_HOME); break;
                case "BROWSER_REFRESH": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_REFRESH); break;
                case "BROWSER_SEARCH": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_SEARCH); break;
                case "BROWSER_STOP": InputSimulator.SimulateKeyPress(VirtualKeyCode.BROWSER_STOP); break;
                case "CANCEL": InputSimulator.SimulateKeyPress(VirtualKeyCode.CANCEL); break;
                case "CAPITAL": InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL); break;
                case "CLEAR": InputSimulator.SimulateKeyPress(VirtualKeyCode.CLEAR); break;
                case "CONTROL": InputSimulator.SimulateKeyPress(VirtualKeyCode.CONTROL); break;
                case "CONVERT": InputSimulator.SimulateKeyPress(VirtualKeyCode.CONVERT); break;
                case "CRSEL": InputSimulator.SimulateKeyPress(VirtualKeyCode.CRSEL); break;
                case "DECIMAL": InputSimulator.SimulateKeyPress(VirtualKeyCode.DECIMAL); break;
                case "DELETE": InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE); break;
                case "DIVIDE": InputSimulator.SimulateKeyPress(VirtualKeyCode.DIVIDE); break;
                case "DOWN": InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN); break;
                case "END": InputSimulator.SimulateKeyPress(VirtualKeyCode.END); break;
                case "EREOF": InputSimulator.SimulateKeyPress(VirtualKeyCode.EREOF); break;
                case "ESCAPE": InputSimulator.SimulateKeyPress(VirtualKeyCode.ESCAPE); break;
                case "EXECUTE": InputSimulator.SimulateKeyPress(VirtualKeyCode.EXECUTE); break;
                case "EXSEL": InputSimulator.SimulateKeyPress(VirtualKeyCode.EXSEL); break;
                case "F1": InputSimulator.SimulateKeyPress(VirtualKeyCode.F1); break;
                case "F10": InputSimulator.SimulateKeyPress(VirtualKeyCode.F10); break;
                case "F11": InputSimulator.SimulateKeyPress(VirtualKeyCode.F11); break;
                case "F12": InputSimulator.SimulateKeyPress(VirtualKeyCode.F12); break;
                case "F13": InputSimulator.SimulateKeyPress(VirtualKeyCode.F13); break;
                case "F14": InputSimulator.SimulateKeyPress(VirtualKeyCode.F14); break;
                case "F15": InputSimulator.SimulateKeyPress(VirtualKeyCode.F15); break;
                case "F16": InputSimulator.SimulateKeyPress(VirtualKeyCode.F16); break;
                case "F17": InputSimulator.SimulateKeyPress(VirtualKeyCode.F17); break;
                case "F18": InputSimulator.SimulateKeyPress(VirtualKeyCode.F18); break;
                case "F19": InputSimulator.SimulateKeyPress(VirtualKeyCode.F19); break;
                case "F2": InputSimulator.SimulateKeyPress(VirtualKeyCode.F2); break;
                case "F20": InputSimulator.SimulateKeyPress(VirtualKeyCode.F20); break;
                case "F21": InputSimulator.SimulateKeyPress(VirtualKeyCode.F21); break;
                case "F22": InputSimulator.SimulateKeyPress(VirtualKeyCode.F22); break;
                case "F23": InputSimulator.SimulateKeyPress(VirtualKeyCode.F23); break;
                case "F24": InputSimulator.SimulateKeyPress(VirtualKeyCode.F24); break;
                case "F3": InputSimulator.SimulateKeyPress(VirtualKeyCode.F3); break;
                case "F4": InputSimulator.SimulateKeyPress(VirtualKeyCode.F4); break;
                case "F5": InputSimulator.SimulateKeyPress(VirtualKeyCode.F5); break;
                case "F6": InputSimulator.SimulateKeyPress(VirtualKeyCode.F6); break;
                case "F7": InputSimulator.SimulateKeyPress(VirtualKeyCode.F7); break;
                case "F8": InputSimulator.SimulateKeyPress(VirtualKeyCode.F8); break;
                case "F9": InputSimulator.SimulateKeyPress(VirtualKeyCode.F9); break;
                case "FINAL": InputSimulator.SimulateKeyPress(VirtualKeyCode.FINAL); break;
                case "HANGEUL": InputSimulator.SimulateKeyPress(VirtualKeyCode.HANGEUL); break;
                case "HANGUL": InputSimulator.SimulateKeyPress(VirtualKeyCode.HANGUL); break;
                case "HANJA": InputSimulator.SimulateKeyPress(VirtualKeyCode.HANJA); break;
                case "HELP": InputSimulator.SimulateKeyPress(VirtualKeyCode.HELP); break;
                case "HOME": InputSimulator.SimulateKeyPress(VirtualKeyCode.HOME); break;
                case "INSERT": InputSimulator.SimulateKeyPress(VirtualKeyCode.INSERT); break;
                case "JUNJA": InputSimulator.SimulateKeyPress(VirtualKeyCode.JUNJA); break;
                case "KANA": InputSimulator.SimulateKeyPress(VirtualKeyCode.KANA); break;
                case "KANJI": InputSimulator.SimulateKeyPress(VirtualKeyCode.KANJI); break;
                case "LAUNCH_APP1": InputSimulator.SimulateKeyPress(VirtualKeyCode.LAUNCH_APP1); break;
                case "LAUNCH_APP2": InputSimulator.SimulateKeyPress(VirtualKeyCode.LAUNCH_APP2); break;
                case "LAUNCH_MAIL": InputSimulator.SimulateKeyPress(VirtualKeyCode.LAUNCH_MAIL); break;
                case "LAUNCH_MEDIA_SELECT": InputSimulator.SimulateKeyPress(VirtualKeyCode.LAUNCH_MEDIA_SELECT); break;
                case "LBUTTON": InputSimulator.SimulateKeyPress(VirtualKeyCode.LBUTTON); break;
                case "LCONTROL": InputSimulator.SimulateKeyPress(VirtualKeyCode.LCONTROL); break;
                case "LEFT": InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT); break;
                case "LMENU": InputSimulator.SimulateKeyPress(VirtualKeyCode.LMENU); break;
                case "LSHIFT": InputSimulator.SimulateKeyPress(VirtualKeyCode.LSHIFT); break;
                case "LWIN": InputSimulator.SimulateKeyPress(VirtualKeyCode.LWIN); break;
                case "MBUTTON": InputSimulator.SimulateKeyPress(VirtualKeyCode.MBUTTON); break;
                case "MEDIA_NEXT_TRACK": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK); break;
                case "MEDIA_PLAY_PAUSE": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE); break;
                case "MEDIA_PREV_TRACK": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK); break;
                case "MEDIA_STOP": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_STOP); break;
                case "MENU": InputSimulator.SimulateKeyPress(VirtualKeyCode.MENU); break;
                case "MODECHANGE": InputSimulator.SimulateKeyPress(VirtualKeyCode.MODECHANGE); break;
                case "MULTIPLY": InputSimulator.SimulateKeyPress(VirtualKeyCode.MULTIPLY); break;
                case "NEXT": InputSimulator.SimulateKeyPress(VirtualKeyCode.NEXT); break;
                case "NONAME": InputSimulator.SimulateKeyPress(VirtualKeyCode.NONAME); break;
                case "NONCONVERT": InputSimulator.SimulateKeyPress(VirtualKeyCode.NONCONVERT); break;
                case "NUMLOCK": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMLOCK); break;
                case "NUMPAD0": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD0); break;
                case "NUMPAD1": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD1); break;
                case "NUMPAD2": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD2); break;
                case "NUMPAD3": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD3); break;
                case "NUMPAD4": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD4); break;
                case "NUMPAD5": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD5); break;
                case "NUMPAD6": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD6); break;
                case "NUMPAD7": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD7); break;
                case "NUMPAD8": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD8); break;
                case "NUMPAD9": InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMPAD9); break;
                case "OEM_1": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_1); break;
                case "OEM_102": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_102); break;
                case "OEM_2": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_2); break;
                case "OEM_3": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_3); break;
                case "OEM_4": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_4); break;
                case "OEM_5": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_5); break;
                case "OEM_6": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_6); break;
                case "OEM_7": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_7); break;
                case "OEM_8": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_8); break;
                case "OEM_CLEAR": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_CLEAR); break;
                case "OEM_COMMA": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_COMMA); break;
                case "OEM_MINUS": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_MINUS); break;
                case "OEM_PERIOD": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_PERIOD); break;
                case "OEM_PLUS": InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_PLUS); break;
                case "PA1": InputSimulator.SimulateKeyPress(VirtualKeyCode.PA1); break;
                case "PACKET": InputSimulator.SimulateKeyPress(VirtualKeyCode.PACKET); break;
                case "PAUSE": InputSimulator.SimulateKeyPress(VirtualKeyCode.PAUSE); break;
                case "PLAY": InputSimulator.SimulateKeyPress(VirtualKeyCode.PLAY); break;
                case "PRINT": InputSimulator.SimulateKeyPress(VirtualKeyCode.PRINT); break;
                case "PRIOR": InputSimulator.SimulateKeyPress(VirtualKeyCode.PRIOR); break;
                case "PROCESSKEY": InputSimulator.SimulateKeyPress(VirtualKeyCode.PROCESSKEY); break;
                case "RBUTTON": InputSimulator.SimulateKeyPress(VirtualKeyCode.RBUTTON); break;
                case "RCONTROL": InputSimulator.SimulateKeyPress(VirtualKeyCode.RCONTROL); break;
                case "RETURN": InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); break;
                case "RIGHT": InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT); break;
                case "RMENU": InputSimulator.SimulateKeyPress(VirtualKeyCode.RMENU); break;
                case "RSHIFT": InputSimulator.SimulateKeyPress(VirtualKeyCode.RSHIFT); break;
                case "RWIN": InputSimulator.SimulateKeyPress(VirtualKeyCode.RWIN); break;
                case "SCROLL": InputSimulator.SimulateKeyPress(VirtualKeyCode.SCROLL); break;
                case "SELECT": InputSimulator.SimulateKeyPress(VirtualKeyCode.SELECT); break;
                case "SEPARATOR": InputSimulator.SimulateKeyPress(VirtualKeyCode.SEPARATOR); break;
                case "SHIFT": InputSimulator.SimulateKeyPress(VirtualKeyCode.SHIFT); break;
                case "SLEEP": InputSimulator.SimulateKeyPress(VirtualKeyCode.SLEEP); break;
                case "SNAPSHOT": InputSimulator.SimulateKeyPress(VirtualKeyCode.SNAPSHOT); break;
                case "SPACE": InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE); break;
                case "SUBTRACT": InputSimulator.SimulateKeyPress(VirtualKeyCode.SUBTRACT); break;
                case "TAB": InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB); break;
                case "UP": InputSimulator.SimulateKeyPress(VirtualKeyCode.UP); break;
                case "VK_0": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_0); break;
                case "VK_1": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1); break;
                case "VK_2": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_2); break;
                case "VK_3": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_3); break;
                case "VK_4": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_4); break;
                case "VK_5": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5); break;
                case "VK_6": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_6); break;
                case "VK_7": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_7); break;
                case "VK_8": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_8); break;
                case "VK_9": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_9); break;
                case "VK_A": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A); break;
                case "VK_B": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B); break;
                case "VK_C": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C); break;
                case "VK_D": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D); break;
                case "VK_E": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E); break;
                case "VK_F": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F); break;
                case "VK_G": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G); break;
                case "VK_H": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H); break;
                case "VK_I": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I); break;
                case "VK_J": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J); break;
                case "VK_K": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K); break;
                case "VK_L": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L); break;
                case "VK_M": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M); break;
                case "VK_N": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N); break;
                case "VK_O": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O); break;
                case "VK_P": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P); break;
                case "VK_Q": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q); break;
                case "VK_R": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R); break;
                case "VK_S": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S); break;
                case "VK_T": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T); break;
                case "VK_U": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U); break;
                case "VK_V": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V); break;
                case "VK_W": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W); break;
                case "VK_X": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X); break;
                case "VK_Y": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y); break;
                case "VK_Z": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z); break;
                case "VOLUME_DOWN": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN); break;
                case "VOLUME_MUTE": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE); break;
                case "VOLUME_UP": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP); break;
                case "XBUTTON1": InputSimulator.SimulateKeyPress(VirtualKeyCode.XBUTTON1); break;
                case "XBUTTON2": InputSimulator.SimulateKeyPress(VirtualKeyCode.XBUTTON2); break;
                case "ZOOM": InputSimulator.SimulateKeyPress(VirtualKeyCode.ZOOM); break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.fermongroup.com/arduino");
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.fermongroup.com/arduino");
        }
    }
}
