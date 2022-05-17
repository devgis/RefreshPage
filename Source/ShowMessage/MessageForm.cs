using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
namespace ShowMessage
{
    public partial class MessageForm : Form
    {
        private static MessageForm instance = null;
        public static MessageForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageForm();

                }
                return instance;
            }
        }

        public void ShowInfo(MessageInfo info)
        {
            lbTitle.Text = info.title;
            lbContent.Text = info.content;
            lbContent.Tag = info.url;
            this.Show();
        }

        System.Drawing.Bitmap b;
        Bitmap T;
        byte[] t;
        byte[] s;
        System.Threading.Thread show;
        public MessageForm()
        {

            InitializeComponent();
            Point p = new Point(500, 1024);
            lbContent.Click += new EventHandler(lbContent_Click);
            this.Location = p;
            t = new byte[4];
            t[0] = 5;
        }

        void lbContent_Click(object sender, EventArgs e)
        {
            if(lbContent.Tag!=null&&!string.IsNullOrEmpty(lbContent.Tag.ToString()))
            {
                 System.Diagnostics.Process.Start(lbContent.Tag.ToString());
            }
        }


        //´°ÌåÒÆ¶¯µÄ
        //private const int WM_NCHITTEST = 0x84;
        //private const int HTCLIENT = 0x1;
        //private const int HTCAPTION = 0x2;

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case WM_NCHITTEST:
        //            base.WndProc(ref m);
        //            if ((int)m.Result == HTCLIENT)
        //                m.Result = (IntPtr)HTCAPTION;
        //            return;
        //    }
        //    base.WndProc(ref m);
        //}
        private void axSvDTK1_DisConnected(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(t[0].ToString());
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            show = new System.Threading.Thread(ShowForm);
            show.IsBackground = true;
            show.Start();
           Rectangle E= Screen.PrimaryScreen.Bounds;
           Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width- 260, Screen.PrimaryScreen.WorkingArea.Height - 160);
            this.Location = p;
        }
        private void ShowForm()
        {
            double t = 0.1;
            while (true)
            {

                if (this.InvokeRequired)
                {
                    SetForm d = delegate(double value)
                    {

                        this.Opacity = value;
                    };
                    this.Invoke(d, new object[1] { t });
                }
                else
                {
                    this.Opacity = t;
                }
                t += 0.1;
                System.Threading.Thread.Sleep(150);
                if (this.Opacity == 1.0)
                {
                    break;
                }
            }
        }
        delegate void SetForm(double value);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //int i = e.X; 164 49
            if (e.X == 164 && e.Y == 49)
            {
                toolTip1.Show("sss", this, 164, 49);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            toolTip1.Show("sss", this, 164, 49);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //contextMenuStrip1.Show(new Control(), 50, 50);
            MainForm.Instance.WindowState = FormWindowState.Normal;
        }

        private void MessageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon1.Dispose();
            this.Dispose();
        }


    }
}