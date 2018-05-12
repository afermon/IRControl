using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;
using WindowsInput;
using WindowsInput.Native;

namespace IRControl
{
    public class IrControlManager
    {
        private static IrControlManager _instance;
        private static readonly Dictionary<string, IrCode> IrCodes = new Dictionary<string, IrCode>();
        private bool _configfile = false;
        private bool _running = false;
        private TextBox _tbOut;

        public static IrControlManager GetInstance()
        {
            return _instance ?? (_instance = new IrControlManager());
        }

        public string[] GetPorts()
        {
            string[] ports = null;
            try
            {
                ports = SerialPort.GetPortNames();
                AddLog(ports.Length + " serial ports detected.");
            }
            catch
            {
                ports = null;
            }

            return ports;
        }
        public void SetTbOut(TextBox tbOut)
        {
            _tbOut = tbOut;
        }

        public void ProcessCode(string hexCode)
        {
            if (IrCodes.ContainsKey(hexCode))
                VirtualKeySend(IrCodes[hexCode].Command);
        }

        public void LoadIrCodes(string irControlConfig)
        {
            IrCodes.Clear();

            if (irControlConfig == null) return;

            var xmlSerializer = new XmlSerializer(typeof(List<IrCode>));

            List<IrCode> lstIrCodes;

            using (var fileStream = new FileStream(irControlConfig, FileMode.Open))
                lstIrCodes = (List<IrCode>)xmlSerializer.Deserialize(fileStream);

            foreach (var irCode in lstIrCodes)
                IrCodes.Add(irCode.HexCode, irCode);

            AddLog(IrCodes.Count + " Codes loaded.");
        }

        public void VirtualKeySend(string command)
        {
            var inputSimulator = new InputSimulator();

            switch (command)
            {
                case "CLOSE": inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4); break;
                case "ACCEPT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ACCEPT); break;
                case "ADD": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ADD); break;
                case "APPS": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.APPS); break;
                case "ATTN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ATTN); break;
                case "BACK": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BACK); break;
                case "BROWSER_BACK": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_BACK); break;
                case "BROWSER_FAVORITES": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_FAVORITES); break;
                case "BROWSER_FORWARD": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_FORWARD); break;
                case "BROWSER_HOME": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_HOME); break;
                case "BROWSER_REFRESH": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_REFRESH); break;
                case "BROWSER_SEARCH": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_SEARCH); break;
                case "BROWSER_STOP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_STOP); break;
                case "CANCEL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CANCEL); break;
                case "CAPITAL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CAPITAL); break;
                case "CLEAR": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CLEAR); break;
                case "CONTROL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CONTROL); break;
                case "CONVERT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CONVERT); break;
                case "CRSEL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.CRSEL); break;
                case "DECIMAL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DECIMAL); break;
                case "DELETE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE); break;
                case "DIVIDE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DIVIDE); break;
                case "DOWN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DOWN); break;
                case "END": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.END); break;
                case "EREOF": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.EREOF); break;
                case "ESCAPE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE); break;
                case "EXECUTE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.EXECUTE); break;
                case "EXSEL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.EXSEL); break;
                case "F1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F1); break;
                case "F10": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F10); break;
                case "F11": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F11); break;
                case "F12": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F12); break;
                case "F13": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F13); break;
                case "F14": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F14); break;
                case "F15": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F15); break;
                case "F16": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F16); break;
                case "F17": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F17); break;
                case "F18": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F18); break;
                case "F19": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F19); break;
                case "F2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F2); break;
                case "F20": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F20); break;
                case "F21": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F21); break;
                case "F22": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F22); break;
                case "F23": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F23); break;
                case "F24": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F24); break;
                case "F3": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F3); break;
                case "F4": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F4); break;
                case "F5": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F5); break;
                case "F6": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F6); break;
                case "F7": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F7); break;
                case "F8": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F8); break;
                case "F9": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.F9); break;
                case "FINAL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.FINAL); break;
                case "HANGEUL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.HANGEUL); break;
                case "HANGUL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.HANGUL); break;
                case "HANJA": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.HANJA); break;
                case "HELP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.HELP); break;
                case "HOME": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.HOME); break;
                case "INSERT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.INSERT); break;
                case "JUNJA": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.JUNJA); break;
                case "KANA": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.KANA); break;
                case "KANJI": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.KANJI); break;
                case "LAUNCH_APP1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LAUNCH_APP1); break;
                case "LAUNCH_APP2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LAUNCH_APP2); break;
                case "LAUNCH_MAIL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LAUNCH_MAIL); break;
                case "LAUNCH_MEDIA_SELECT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LAUNCH_MEDIA_SELECT); break;
                case "LBUTTON": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LBUTTON); break;
                case "LCONTROL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LCONTROL); break;
                case "LEFT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LEFT); break;
                case "LMENU": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LMENU); break;
                case "LSHIFT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LSHIFT); break;
                case "LWIN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.LWIN); break;
                case "MBUTTON": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MBUTTON); break;
                case "MEDIA_NEXT_TRACK": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK); break;
                case "MEDIA_PLAY_PAUSE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE); break;
                case "MEDIA_PREV_TRACK": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PREV_TRACK); break;
                case "MEDIA_STOP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MEDIA_STOP); break;
                case "MENU": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MENU); break;
                case "MODECHANGE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MODECHANGE); break;
                case "MULTIPLY": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.MULTIPLY); break;
                case "NEXT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NEXT); break;
                case "NONAME": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NONAME); break;
                case "NONCONVERT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NONCONVERT); break;
                case "NUMLOCK": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMLOCK); break;
                case "NUMPAD0": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD0); break;
                case "NUMPAD1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD1); break;
                case "NUMPAD2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD2); break;
                case "NUMPAD3": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD3); break;
                case "NUMPAD4": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD4); break;
                case "NUMPAD5": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD5); break;
                case "NUMPAD6": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD6); break;
                case "NUMPAD7": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD7); break;
                case "NUMPAD8": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD8); break;
                case "NUMPAD9": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.NUMPAD9); break;
                case "OEM_1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_1); break;
                case "OEM_102": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_102); break;
                case "OEM_2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_2); break;
                case "OEM_3": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_3); break;
                case "OEM_4": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_4); break;
                case "OEM_5": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_5); break;
                case "OEM_6": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_6); break;
                case "OEM_7": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_7); break;
                case "OEM_8": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_8); break;
                case "OEM_CLEAR": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_CLEAR); break;
                case "OEM_COMMA": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_COMMA); break;
                case "OEM_MINUS": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_MINUS); break;
                case "OEM_PERIOD": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_PERIOD); break;
                case "OEM_PLUS": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.OEM_PLUS); break;
                case "PA1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PA1); break;
                case "PACKET": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PACKET); break;
                case "PAUSE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PAUSE); break;
                case "PLAY": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PLAY); break;
                case "PRINT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PRINT); break;
                case "PRIOR": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PRIOR); break;
                case "PROCESSKEY": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.PROCESSKEY); break;
                case "RBUTTON": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RBUTTON); break;
                case "RCONTROL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RCONTROL); break;
                case "RETURN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN); break;
                case "RIGHT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RIGHT); break;
                case "RMENU": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RMENU); break;
                case "RSHIFT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RSHIFT); break;
                case "RWIN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RWIN); break;
                case "SCROLL": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SCROLL); break;
                case "SELECT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SELECT); break;
                case "SEPARATOR": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SEPARATOR); break;
                case "SHIFT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SHIFT); break;
                case "SLEEP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SLEEP); break;
                case "SNAPSHOT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SNAPSHOT); break;
                case "SPACE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SPACE); break;
                case "SUBTRACT": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SUBTRACT); break;
                case "TAB": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.TAB); break;
                case "UP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.UP); break;
                case "VK_0": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_0); break;
                case "VK_1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1); break;
                case "VK_2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_2); break;
                case "VK_3": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_3); break;
                case "VK_4": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_4); break;
                case "VK_5": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_5); break;
                case "VK_6": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_6); break;
                case "VK_7": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_7); break;
                case "VK_8": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_8); break;
                case "VK_9": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_9); break;
                case "VK_A": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_A); break;
                case "VK_B": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_B); break;
                case "VK_C": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_C); break;
                case "VK_D": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_D); break;
                case "VK_E": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_E); break;
                case "VK_F": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_F); break;
                case "VK_G": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_G); break;
                case "VK_H": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_H); break;
                case "VK_I": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_I); break;
                case "VK_J": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_J); break;
                case "VK_K": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_K); break;
                case "VK_L": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_L); break;
                case "VK_M": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_M); break;
                case "VK_N": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_N); break;
                case "VK_O": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_O); break;
                case "VK_P": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_P); break;
                case "VK_Q": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_Q); break;
                case "VK_R": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_R); break;
                case "VK_S": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_S); break;
                case "VK_T": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_T); break;
                case "VK_U": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_U); break;
                case "VK_V": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_V); break;
                case "VK_W": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_W); break;
                case "VK_X": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_X); break;
                case "VK_Y": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_Y); break;
                case "VK_Z": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_Z); break;
                case "VOLUME_DOWN": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_DOWN); break;
                case "VOLUME_MUTE": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE); break;
                case "VOLUME_UP": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP); break;
                case "XBUTTON1": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.XBUTTON1); break;
                case "XBUTTON2": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.XBUTTON2); break;
                case "ZOOM": inputSimulator.Keyboard.KeyPress(VirtualKeyCode.ZOOM); break;
                default: break;
            }
        }

        public void AddLog(string log)
        {
            _tbOut?.AppendText("\r\n" + log);
        }
    }
}
