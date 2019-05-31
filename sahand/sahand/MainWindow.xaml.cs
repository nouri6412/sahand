using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sahand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class list_item
    {
        public static List<item> list = new List<item>();
    }
    public partial class MainWindow : Window
    {
        List<item> list = new List<item>();
        HttpServer httpServer;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            load();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            dispatcherTimer.Start();
            httpServer = new MyHttpServer(8181);
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
        }
        void load()
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.Open(@"sahand.temp", System.IO.FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    List<item> salesman1 = (List<item>)bformatter.Deserialize(stream);
                    list_item.list.Clear();
                    foreach (var it in salesman1)
                    {
                        list_item.list.Add(it);
                    }
                    item it1 = new item()
                    {
                        nams = "ps4",
                        pay = "",
                        start = new DateTime(),
                        time = 0,
                        tozih = "",
                        online = DateTime.Now
                    };
                    list_item.list.Add(it1);
                }
            }
            catch { }
        }
        public byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            foreach(var it in list_item.list.OrderBy(r=>r.nams))
            {
                Button but=new Button();
                foreach (StackPanel st in asli.Children.OfType<StackPanel>())
                    {
                            foreach (Button st1 in st.Children)
                            {
                                if (st1.Uid == it.nams)
                                {
                                    but = st1;
                                }
                            }
                    }
                if (but.Uid.Length == 0)
                {
                    event_on(it.nams);
                }
                var ij = list_item.list.FirstOrDefault(r => r.nams == it.nams);
                if (ij != null)
                {
                    TimeSpan t = DateTime.Now - ij.online;
                    double past = Math.Round(t.TotalSeconds, 0);
                    TimeSpan t1 = DateTime.Now - ij.start;
                    int past1 =int.Parse( Math.Round(t1.TotalMinutes, 0).ToString());
                    ij.past = past1;
                                            but.Uid = ij.nams;
                                            int aa = ij.time - past1;
                    if(aa<0)
                    {
                        aa = 0;
                    }
                                            but.Name ="A"+ ij.time.ToString() + "__" + past1.ToString() + "__" + aa.ToString() + "_" + ij.pay;
                                           
                                            but.Style = (Style)FindResource("adi");
                    if (past > 5)
                    {
                        if(but.Uid!="ps4")
                        {
    but.Style = (Style)FindResource("khamush");
                        }
                    
                    }
                    else
                    {
                        
                        if(it.lockk==true)
                        {
                            but.Style = (Style)FindResource("gofl");
                        }
                        else
                        {
                               if(ij.time==0)
                            {
                                but.Style = (Style)FindResource("azad");
                            }
                               else if (past1 >= ij.time)
                            {
                                but.Style = (Style)FindResource("tamam");
                            }                       
                            else
                            {
                                but.Style = (Style)FindResource("adi");
                            }  
                        }                   
                    }
                }

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                        Button but = new Button();
            but.Style = (Style)FindResource("adi");
            but.Uid = "ps4";
            row3.Children.Add(but);
        }
        public void event_on(string str)
        {
            Button but = new Button();
            but.Style = (Style)FindResource("adi");
            but.Uid = str;
            int iii = list_item.list.Count/7;
            int ii = 0;
            StackPanel st=new StackPanel();
            int tt = 0;
           //  if (str.Contains("08") || str.Contains("09") || str.Contains("10") || str.Contains("11") || str.Contains("12") || str.Contains("13") || str.Contains("14"))
           // {
           //     row1.Children.Add(but);
           // }
           //else if(str.Contains("01")||str.Contains("02")||str.Contains("03")||str.Contains("04")||str.Contains("05")||str.Contains("06")||str.Contains("07"))
           // {
           //     row2.Children.Add(but);
           // }
            if (str.Contains("06") || str.Contains("07") || str.Contains("08") || str.Contains("09") || str.Contains("10"))
            {
                row1.Children.Add(but);
            }
            else if (str.Contains("01") || str.Contains("02") || str.Contains("03") || str.Contains("04") || str.Contains("05"))
            {
                row2.Children.Add(but);
            }
             else
             {
                 row3.Children.Add(but);
             }
          
        }
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Button but = sender as Button;
            but.Background = Brushes.Khaki;
           if (e.ButtonState == Mouse.RightButton)
            {
                but.ContextMenu = menu1;
                txtstart.Focus();
                txtstart.SelectAll();
            }
        }
        public void kili()
        {
            try
            {
                foreach (Process Proc in Process.GetProcesses())
                    if (Proc.ProcessName.Contains("sahand"))  //Process Excel?
                    {
                        Proc.Kill();
                    }
            }
            catch { }
        }
        void save_all(string str="")
        {
            try
            {
          
                if (System.IO.File.Exists(@"sahand" + str + ".temp"))
                {
                    System.IO.File.Delete(@"sahand" + str + ".temp");
                }
                using (System.IO.Stream stream = System.IO.File.Open(@"sahand"+str+".temp", System.IO.FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, list_item.list);
                }
            }
            catch { }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            save_all();
            if (httpServer!=null)
            {
                httpServer.is_active = false;
                kili();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            save_all("1");
                   MenuItem fmen = sender as MenuItem;
                   try
                   {
                       Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                       var it = list_item.list.FirstOrDefault(r=>r.nams==menut.Uid);
                       it.start = DateTime.Now;
                       it.flag = 1;
                       try
                       {
                           it.time = int.Parse(txtstart.Text);
                           txtrstart.Text = "";
                       }
                       catch { MessageBox.Show("زمان وارد شده اشتباه است"); return; }
                     if(chekstart.IsChecked==true)
                     {
                         it.pay = "P";
                     }
                     else
                     {
                         it.pay = "";
                     }

                   }
                   catch { }
                   save_all();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            save_all("1");
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 7;
                try
                {
                    it.time_ghabli = int.Parse(txtstart.Text);
                    it.time = int.Parse(txtrstart.Text);
                    it.tozih = txtstart.Text;
                }
                catch { MessageBox.Show("زمان وارد شده اشتباه است"); return; }
                if ( chekrestart.IsChecked== true)
                {
                    it.pay = "P";
                }
                else
                {
                    it.pay = "";
                }
            }
            catch { }
            save_all();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            save_all("1");
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.time = 0;
                    txtstart.Text = "آزاد";
                }
                catch { }
                if (chekstart.IsChecked == true)
                {
                    it.pay = "P";
                }
                else
                {
                    it.pay = "";
                }

            }
            catch { }
            save_all();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.flag = 5;
                    it.lockk = true;
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.flag = 6;
                    it.lockk = false;
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.flag = 4;
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.flag = 2;
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                it.start = DateTime.Now;
                it.flag = 1;
                try
                {
                    it.flag = 3;
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                try
                {
                    using (System.IO.Stream stream = System.IO.File.Open(@"sahand1.temp", System.IO.FileMode.Open))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        List<item> salesman1 = (List<item>)bformatter.Deserialize(stream);
                        var iit = salesman1.FirstOrDefault(r=>r.nams==it.nams);
                        if(iit!=null)
                        {
                            it.start = iit.start;
                            txtstart.Text = iit.time.ToString();
                            txtrstart.Text = "";
                            if(iit.pay=="P")
                            {
                                chekstart.IsChecked = true;
                            }
                            it.pay = iit.pay;
                            it.time = iit.time;
                            it.tozih = iit.tozih;
                            it.past = iit.past;
                            it.time_ghabli = iit.time_ghabli;
                            it.flag = 8;
                        }
                    }
                }
                catch { }

            }
            catch { }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            list_item.list.Clear();
            load();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
           foreach(var it in list_item.list)
           {
               it.flag = 4;
           }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            foreach (var it in list_item.list)
            {
                it.flag = 2;
            }
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            foreach (var it in list_item.list)
            {
                it.lockk = true;
                it.flag = 5;
            }
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            foreach (var it in list_item.list)
            {
                it.lockk = false;
                it.flag = 6;
            }
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                list_item.list.Remove(it);
                var par = menut.Parent;
                StackPanel st = (StackPanel)par;
                st.Children.Remove(menut);
            }
            catch { }
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            MenuItem fmen = sender as MenuItem;
            try
            {
                Button menut = ((ContextMenu)fmen.Parent).PlacementTarget as Button;
                var it = list_item.list.FirstOrDefault(r => r.nams == menut.Uid);
                try
                {
                    it.flag = 8;
                }
                catch { }

            }
            catch { }
        }
    }
    [Serializable]
    class item
    {
        public string nams { get; set; }
        public int time { get; set; }
        public DateTime start { get; set; }
        public string  pay { get; set; }
        public string tozih { get; set; }
        public int time_ghabli { get; set; }
        public DateTime online { get; set; }
        public int past { get; set; }
        //public bool start1 { get; set; }//1
        //public bool lockk { get; set; }//2
        //public int shut { get; set; }//3
        //public bool restart { get; set; }//4
        public int flag { get; set; }
        public bool lockk { get; set; }
    }
    class borj
    { 
        public string nams { get; set; }
        public int pul { get; set; }
    }
    public class HttpProcessor
    {
        public TcpClient socket;
        public HttpServer srv;
        private Stream inputStream;
        public StreamWriter outputStream;
        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();
        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB
        public HttpProcessor(TcpClient s, HttpServer srv)
        {
            this.socket = s;
            this.srv = srv;
        }


        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        public void process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET"))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("starting: " + request);
        }

        public void readHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest()
        {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length"))
            {
                content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                if (content_len > MAX_POST_SIZE)
                {
                    throw new Exception(
                        String.Format("POST Content-Length({0}) too big for this simple server",
                          content_len));
                }
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", to_read);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            srv.handlePOSTRequest(this, new StreamReader(ms));

        }

        public void writeSuccess(string content_type = "text/html")
        {
            outputStream.WriteLine("HTTP/1.0 200 OK");
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeFailure()
        {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }
    }

    public abstract class HttpServer
    {

        protected int port;
        TcpListener listener;
      public  bool is_active = true;

        public HttpServer(int port)
        {
            this.port = port;
        }

        public void listen()
        {
            listener = new TcpListener(port);
            listener.Start();
            while (is_active)
            {
                TcpClient s = listener.AcceptTcpClient();
                HttpProcessor processor = new HttpProcessor(s, this);
                Thread thread = new Thread(new ThreadStart(processor.process));
                thread.Start();
                Thread.Sleep(1);
            }
        }

        public abstract void handleGETRequest(HttpProcessor p);
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }

    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(int port)
            : base(port)
        {
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
        public override void handleGETRequest(HttpProcessor p)
        {
            Dictionary<string, string> ls = GetParams(p.http_url);
            var item1 = ls.FirstOrDefault(r => r.Key == "comname");
            string stt = "0";
            try
            {
                var tt = list_item.list.FirstOrDefault(r=>r.nams==item1.Value);
                if(tt==null&&item1.Value!=null)
                {
                    item it = new item() { 
                     nams=item1.Value, pay="", start=new DateTime(), time=0, tozih="", online=DateTime.Now
                    };
                    list_item.list.Add(it);
                }
                else if(tt!=null)
                {
                    tt.online = DateTime.Now;
                    if(tt.flag>0)
                    {
                        string flag = tt.flag.ToString();
                        string time = "0";
                        string time_ghabli = "0";
                        string past = "0";
                        if(tt.flag==1||tt.flag==7||tt.flag==8)
                        {
                            time = tt.time.ToString();                         
                            if(tt.flag!=1)
                            {
                                time_ghabli = tt.time_ghabli.ToString();
                            }
                            if(tt.flag==8)
                            {
                                past = tt.past.ToString();
                            }
                        }
                        stt="pp?flag="+flag+"&time="+time+"&timeg="+time_ghabli+"&past="+past.ToString();
                        tt.flag = 0;
                    }
                }
            }
            catch { }
            p.writeSuccess();
           
            p.outputStream.Write(stt);
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.writeSuccess();
            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);


        }
    }
}
