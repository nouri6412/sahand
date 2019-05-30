using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Sahand : Form
    {
        List<string> lik = new List<string>();
        private readonly BackgroundWorker worker_load = new BackgroundWorker();  
        DateTime d1;
        DateTime d2;
        double time = 0;
        bool azad = false;
        string state = "";
        string server = "192.168.1.1";
        string req = "";
        bool lockk=true;
        bool wait = false;
        Form2 frm = new Form2();
        bool show = false;
        public Sahand()
        {
            InitializeComponent();
             d1 = DateTime.Now;
             d2 = DateTime.Now;
             worker_load.DoWork += worker_DoWork_load;
             worker_load.RunWorkerCompleted += worker_RunWorkerCompleted_load;
             foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
             {
                 lik.Add(myProc.ProcessName);
             }
        }
        int index = 0;
        private void worker_DoWork_load(object sender, DoWorkEventArgs e)
        {
            if (wait)
            {
            return;
           }
            wait = true;
            try
            {
                string com_name = System.Windows.Forms.SystemInformation.ComputerName;
                IPHostEntry ipHostInfo = Dns.GetHostEntry("sahand");
                IPAddress ip = ipHostInfo.AddressList.Where(n => n.AddressFamily == AddressFamily.InterNetwork).First();
                server = ip.ToString();

                string str = request("http://sahand:8181" + "?comname=" + com_name + req);
                wait = false;
                if (str == "0")
                {

                }
                else
                {
                    Dictionary<string, string> ls = GetParams(str);
                    var item1 = ls.FirstOrDefault(r => r.Key == "flag");
                    var item2 = ls.FirstOrDefault(r => r.Key == "time");
                    var item3 = ls.FirstOrDefault(r => r.Key == "timeg");
                    var item4 = ls.FirstOrDefault(r => r.Key == "past");
                    if (item1.Value == "1")
                    {//start
                        int timm = int.Parse(item2.Value);
                        start(timm);
                        LBGabli.Text = "ندارد";
                    }
                    else if (item1.Value == "2")
                    {//sleep
                        DoOperation("Sleep");
                    }
                    else if (item1.Value == "3")
                    {//Restart
                        DoOperation("Restart");
                    }
                    else if (item1.Value == "4")
                    {//Shut Down
                        DoOperation("Shut Down");
                    }
                    else if (item1.Value == "5")
                    {//lock
                        lockk = true;
                    }
                    else if (item1.Value == "6")
                    {//unlock
                        lockk = false;
                    }
                    else if (item1.Value == "7")
                    {//restart 
                        LBGabli.Text = item3.Value;
                        int timm = int.Parse(item2.Value);
                        start(timm);
                    }
                    else if (item1.Value == "8")
                    {//restart 
                        LBGabli.Text = item3.Value;
                        d1 = DateTime.Now;
                        d2 = DateTime.Now.AddMinutes(int.Parse(item4.Value) * -1);
                        int timm = int.Parse(item2.Value);
                        start(timm, true);
                    }
                }
            }
            catch { }
            wait = false;
        }
        private void DoOperation(string oparation)
        {
            
            string filename = string.Empty;
            string arguments = string.Empty;

            switch (oparation)
            {
                case "Shut Down":
                    filename = "shutdown.exe";
                    arguments = "-s";
                    break;

                case "Restart":

                    filename = "shutdown.exe";
                    arguments = "-r";
                    break;

                case "Logoff":

                    filename = "shutdown.exe";
                    arguments = "-l";
                    break;

                case "Lock":

                    filename = "Rundll32.exe";
                    arguments = "User32.dll, LockWorkStation";
                    break;
                case "Hibernation":

                    filename = @"%windir%\system32\rundll32.exe";
                    arguments = "PowrProf.dll, SetSuspendState";
                    break;
                case "Sleep":
                      filename = @"%windir%\system32\rundll32.exe";
                    arguments = "PowrProf.dll, SetSuspendState";
                    break;
                    //filename = "Rundll32.exe";
                    //arguments = "powrprof.dll, SetSuspendState 0,1,0";
                    //break;
            }

            ProcessStartInfo startinfo = new ProcessStartInfo(filename, arguments);
            Process.Start(startinfo);
            timer1.Stop();
            this.Close();
        }
        private void worker_RunWorkerCompleted_load(object sender, RunWorkerCompletedEventArgs e)
        {
            wait = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }
        string request(string url)
        {
            string str = "0";
            try
            {
               
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadToEnd();
                }
            }
            catch {
              
            }
            wait = false;
            return str;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        //[DllImport("user32.dll")]
        //static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        /// <summary>
        /// Shows the desktop.
        /// </summary>
        /// 
        //public static void ShowDesktop()
        //{

        //    //keybd_event(0x5B, 0, 0, 0);
        //    //keybd_event(0x4D, 0, 0, 0);
        //    //keybd_event(0x5B, 0, 0x2, 0);

        //}
        private void ShowDesktop()
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
               var it= lik.FirstOrDefault(r=>r==myProc.ProcessName);
                if(it==null)
                {
                    myProc.Kill();
                }
            }
           // SendKeys.Send("^({ESC}D)"); //<-- Semantic error, Should simulate: WIN+D

        }
     void start(int _time=0,bool send=false)
        {
            lockk = false;
            time = _time;
         if (time==0)
         {
             azad = true;
         }
         else
         {
             azad = false;
         }
         if(send==false)
         {
                         state = "";
            d1 = DateTime.Now;
            d2 = DateTime.Now;
         }
        }
     Dictionary<string, string> GetParams(string str)
     {
         int questionMarkIndex = str.IndexOf('?');
         if (questionMarkIndex != -1)
         {
             string paramsString = str.Substring(questionMarkIndex + 1);
             string[] keyValues = paramsString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
             Dictionary<string, string> result = new Dictionary<string, string>();

             foreach (string keyValue in keyValues)
             {
                 string[] splitKeyValue = keyValue.Split(new char[] { '=' });
                 if (splitKeyValue.Length == 2 && !string.IsNullOrWhiteSpace(splitKeyValue[0]))
                 {
                     string unencodedKey = Uri.UnescapeDataString(splitKeyValue[0]);
                     string unencodedValue = Uri.UnescapeDataString(splitKeyValue[1]);
                     result[unencodedKey] = unencodedValue;
                 }
             }

             return result;
         }
         else return new Dictionary<string, string>();
     }
        private void timer1_Tick(object sender, EventArgs e)
        {
           d1= d1.AddSeconds(2);
            TimeSpan t = d1 - d2;
            double past =Math.Round(t.TotalMinutes,0);
            LBpast.Text = past.ToString();
            bool fali = false;
            if(azad==false)
            {
                if ((time - past)<=0&&lockk==false)
                {
                    ShowDesktop();
                    try
                    {
                        frm.TopMost = true;
                        if (show == false)
                        {
                            fali = true;
                            show = true;
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                   
                }
                LBremind.Text = (time - past).ToString();
            }
            else
            {
                LBremind.Text = "آزاد";
            }
            if(lockk==true)
            {
               
                ShowDesktop();
                try
                {
                    frm.TopMost = true;
                    if (show == false)
                    {
                        
                        show = true;
                        frm.ShowDialog();
                    }
                }
                catch { }
               
            }
            else if(fali==false)
            {
                if(show==true)
                {
                 show = false;
                frm.Close();
                }
               
            }
            LBstate.Text = state;
    if(wait==false)
    {
        if(worker_load.IsBusy==false)
        {
            worker_load.RunWorkerAsync();
        }
        
    }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }
        void get_ip()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry("yamahdi-pc");
                IPAddress ip = ipHostInfo.AddressList.Where(n => n.AddressFamily == AddressFamily.InterNetwork).First();
                server = ip.ToString();
            }
            catch { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("Sahand", @"D:\sahand\Client.exe");
          //  get_ip();
        }

        private void Sahand_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void Sahand_MouseDown(object sender, MouseEventArgs e)
        {
     
        }

        private void Sahand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                index++;
            }
            if (index == 5)
            {
                this.Close();
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}