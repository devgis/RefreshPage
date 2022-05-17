using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ShowMessage
{
    public partial class MainForm : Form
    {
        private static MainForm instance = null;
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm();

                }
                return instance;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> listUrls = new List<string>();
            foreach (string s in dicUrl.Keys)
            {
                listUrls.Add(s);
            }
            foreach (string url in listUrls)
            {
                //MessageForm.Instance.ShowInfo(new MessageInfo() {  content="但是都很放松地",Title="csdfsd",Url="www.baidu.com"});
                //请求网页内容
                string sresult = string.Empty;
                try
                {
                    sresult = GetWebContent(url);
                }
                catch
                { }
                //反序列化
                if (!string.IsNullOrEmpty(sresult))
                {
                    MessageInfo info = JSONHelper.deserialization<MessageInfo>(sresult);
                    if (dicUrl[url] != null && !dicUrl[url].Equals(info))
                    {
                        dicUrl[url] = info;
                        //System.Threading.Thread.Sleep(3000);
                        new MessageForm().ShowInfo(info);
                        //MessageForm.Instance.ShowInfo(info);
                    }
                }
                //判断
            }
        }

        Dictionary<string, MessageInfo> dicUrl = new Dictionary<string, MessageInfo>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string configPath = System.IO.Path.Combine(Application.StartupPath, "app.cfg");
            string[] urls = File.ReadAllLines(configPath, Encoding.Default);
            foreach (string s in urls)
            {
                if (!dicUrl.ContainsKey(s))
                {
                    dicUrl.Add(s, new MessageInfo());
                }
            }
            this.Refresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private static string GetWebContent(string URL)
        {

            WebRequest req = WebRequest.Create(URL);

            req.Method = "GET";   //指定提交的Method，可以为POST和GET，一定要大写  

            WebResponse res = req.GetResponse();

            //System.Text.Encoding resEncoding = System.Text.Encoding.GetEncoding("utf8");//接收的编码   "gb2312"

            StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.Default); //resEncoding

            string content = reader.ReadToEnd();     //接收的Html  

            reader.Close();

            res.Close();

            return content;

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
