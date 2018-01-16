using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //
            LoadResources();
            //
            tmrGetColor.Tick += new System.EventHandler(tmrGetColor_Tick);
            tmrFindingColor.Tick += new System.EventHandler(tmrFindingColor_Tick);
            //
            btnGetColor.Click += new System.EventHandler(btnGetColor_Click);
            btnFindingColor.Click += new System.EventHandler(btnRun_Click);
            lblSound.Click += new System.EventHandler(lblSound_Click);
            btnPlaySound.Click += new System.EventHandler(btnPlaySound_Click);
            //
            btnGetColor.KeyDown += new KeyEventHandler(action_KeyDown);
            btnFindingColor.KeyDown += new KeyEventHandler(action_KeyDown);
            txtHexColor.KeyDown += new KeyEventHandler(action_KeyDown);
            //
            lblHelp.ForeColor = Color.Red;
            lblHelp.Text = "";
        }
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        private void btnGetColor_Click(object sender, EventArgs e)
        {
            StartGetColor();
        }
        private void GetColor()
        {
            tmrGetColor.Interval = 100;
            if (tmrGetColor.Enabled)
                StopGetColor();
            else
                StartGetColor();
        }
        private void StartGetColor()
        {
            tmrGetColor.Start();
            tmrGetColor.Enabled = true;
            lblHelp.Text = "Press F5 to select Color!";
        }
        private void StopGetColor()
        {
            tmrGetColor.Stop();
            tmrGetColor.Enabled = false;
            lblHelp.Text = "";
        }
        private void tmrGetColor_Tick(object sender, EventArgs e)
        {
            List<Point> result = new List<Point>();
            var bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(System.Windows.Forms.Cursor.Position, new Point(0, 0), new Size(1, 1));
            }
            var pixel = bmp.GetPixel(0, 0);
            imgHexColor.BackColor = pixel;
            txtHexColor.Text = Common.Images.RGBToHex(pixel);
            //var p = new Point();
            //p.X = (this.Width / 2) - (label1.Width / 2);
            //p.Y = label1.Top;
            //label1.Location = p;

            //MessageBox.Show(Timer.ToString());
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            FindingColor();
        }
        private void action_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                StopFindingColor();
                GetColor();
            }
            else if (e.KeyCode == Keys.F6)
            {
                StopGetColor();
                FindingColor();
            }
        }
        private void FindingColor()
        {
            tmrFindingColor.Interval = 5000;
            if (tmrFindingColor.Enabled)
                StopFindingColor();
            else
                StartFindingColor();
        }
        private void StartFindingColor()
        {
            if (string.IsNullOrEmpty(txtHexColor.Text))
            {
                lblHelp.Text = "Set Hex color first, please!";
                txtHexColor.Focus();
                return;
            }
            lblHelp.Text = "Finding....";
            btnGetColor.Enabled = false;
            tmrFindingColor.Start();
            tmrFindingColor.Enabled = true;
        }
        private void StopFindingColor()
        {
            btnGetColor.Enabled = true;
            tmrFindingColor.Stop();
            tmrFindingColor.Enabled = false;
        }
        private void tmrFindingColor_Tick(object sender, EventArgs e)
        {
            //Point[] points = FindColor(HexToRGB("#2D2D30"));
            Point[] points = Common.Images.FindColor(txtHexColor.Text.Trim('#'));
            if (points.Length > 0)
            {

                SetCursorPos(points[0].X, points[0].Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, points[0].X, points[0].Y, 0, 0);

                //foreach (var i in points)
                //{
                //    SetCursorPos(i.X, i.Y);
                //    mouse_event(MOUSEEVENTF_LEFTDOWN, i.X, i.Y, 0, 0);
                //}
            }
            else
                MessageBox.Show("No Color!");
        }
        private void lblSound_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdMain.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    string file = ofdMain.FileName;

                }
                catch (Exception ex)
                {
                    lblHelp.Text = ex.Message;
                }
            }
        }
        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            var sound = Properties.Resources.AlertSound;
            var SoundPlayer = new System.Media.SoundPlayer(sound);
            var checkPlay = false;
            if (checkPlay)
                StopPlaySoundr(SoundPlayer, checkPlay);
            else
                StartPlaySoundr(SoundPlayer, checkPlay);
        }
        private void StartPlaySoundr(System.Media.SoundPlayer SoundPlayer, bool checkPlay)
        {
            checkPlay = true;
            SoundPlayer.Play();
        }
        private void StopPlaySoundr(System.Media.SoundPlayer SoundPlayer, bool checkPlay)
        {
            checkPlay = false;
            SoundPlayer.Stop();
        }
        private void LoadResources()
        {
            var MyIni = new Common.IniFile("Settings.ini");
            if (System.IO.File.Exists(MyIni.ToString()))
            {

            }
            else
            {
                MyIni.Write("tm", "tuanmjnh");
            }
            //MessageBox.Show("Not Settings File!");
        }
        private Dictionary<string, string> SettingDefault()
        {
            var rs = new Dictionary<string, string>();
            rs.Add
        }
    }
}
