using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace FindColor
{
    public partial class FindColor : Form
    {
        public FindColor()
        {
            InitializeComponent();
            //
            LoadResources();
            //
            tmrGetColor.Interval = 100;
            tmrFindingColor.Interval = 5000;
            tmrGetColor.Tick += new EventHandler(tmrGetColor_Tick);
            tmrFindingColor.Tick += new EventHandler(tmrFindingColor_Tick);
            //
            btnColorDialog.Click += new EventHandler(btnColorDialog_Click);
            btnGetColor.Click += new EventHandler(btnGetColor_Click);
            btnFindingColor.Click += new EventHandler(btnFindingColor_Click);
            btnSelectSound.Click += new EventHandler(btnSelectSound_Click);
            btnPlaySound.Click += new EventHandler(btnPlaySound_Click);
            //
            btnColorDialog.KeyDown += new KeyEventHandler(action_KeyDown);
            btnGetColor.KeyDown += new KeyEventHandler(action_KeyDown);
            btnFindingColor.KeyDown += new KeyEventHandler(action_KeyDown);
            txtHexColor.KeyDown += new KeyEventHandler(action_KeyDown);
            btnSelectSound.KeyDown += new KeyEventHandler(action_KeyDown);
            btnPlaySound.KeyDown += new KeyEventHandler(action_KeyDown);
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

        Common.IniFile IniSetting = new Common.IniFile("Settings.ini");
        Common.Settings Setting = new Common.Settings();
        //Play Sound
        bool checkPlaySound = true;
        System.Media.SoundPlayer SoundPlayer = new System.Media.SoundPlayer();
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        private void btnColorDialog_Click(object sender, EventArgs e)
        {
            ShowColorDialog();
        }
        private void btnGetColor_Click(object sender, EventArgs e)
        {
            if (tmrGetColor.Enabled)
                StopGetColor();
            else
                StartGetColor();
        }
        private void btnFindingColor_Click(object sender, EventArgs e)
        {
            if (tmrFindingColor.Enabled)
                StopFindingColor();
            else
                StartFindingColor();
        }
        private void btnSelectSound_Click(object sender, EventArgs e)
        {
            SelectSound();
        }
        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (checkPlaySound)
                StartPlaySound(Setting.Sound);
            else
                StopPlaySound();
        }
        private void action_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F4)
            {
                ShowColorDialog();
            }
            else if (e.KeyCode == Keys.F5)
            {
                StopFindingColor();
                if (tmrGetColor.Enabled)
                    StopGetColor();
                else
                    StartGetColor();
            }
            if (e.KeyCode == Keys.F6)
            {
                SelectSound();
                StopPlaySound();
            }
            if (e.KeyCode == Keys.F7)
            {
                if (checkPlaySound)
                    StartPlaySound(Setting.Sound);
                else
                    StopPlaySound();
            }
            else if (e.KeyCode == Keys.F8)
            {
                StopGetColor();
                if (tmrFindingColor.Enabled)
                    StopFindingColor();
                else
                    StartFindingColor();
            }
        }
        private void ShowColorDialog()
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                txtHexColor.Text = Common.Images.RGBToHex(color);
                imgHexColor.BackColor = color;
                IniSetting.Write("Color", txtHexColor.Text);
                SetDefaultSetting();
            }
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
            IniSetting.Write("Color", txtHexColor.Text);
            SetDefaultSetting();
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
        private void StartFindingColor()
        {
            StopPlaySound();
            if (string.IsNullOrEmpty(txtHexColor.Text))
            {
                lblHelp.Text = "Set Hex color first, please!";
                txtHexColor.Focus();
                return;
            }
            lblHelp.Text = "Finding...";
            txtHexColor.Enabled = false;
            btnColorDialog.Enabled = false;
            btnGetColor.Enabled = false;
            btnSelectSound.Enabled = false;
            btnPlaySound.Enabled = false;
            tmrFindingColor.Start();
            tmrFindingColor.Enabled = true;
            WindowState = FormWindowState.Minimized;
        }
        private void StopFindingColor()
        {
            lblHelp.Text = "";
            txtHexColor.Enabled = true;
            btnColorDialog.Enabled = true;
            btnGetColor.Enabled = true;
            btnSelectSound.Enabled = true;
            btnPlaySound.Enabled = true;
            tmrFindingColor.Stop();
            tmrFindingColor.Enabled = false;
            StopPlaySound();
        }
        private void tmrFindingColor_Tick(object sender, EventArgs e)
        {
            //Point[] points = FindColor(HexToRGB("#2D2D30"));
            Point[] points = Common.Images.FindColor(txtHexColor.Text.Trim('#'));
            if (points.Length > 0)
            {
                StartPlaySound(Setting.Sound);
                //SetCursorPos(points[0].X, points[0].Y);
                //mouse_event(MOUSEEVENTF_LEFTDOWN, points[0].X, points[0].Y, 0, 0);

                //foreach (var i in points)
                //{
                //    SetCursorPos(i.X, i.Y);
                //    mouse_event(MOUSEEVENTF_LEFTDOWN, i.X, i.Y, 0, 0);
                //}
            }
        }
        private void SelectSound()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "audio files (*.wav;*.mp3)|*.wav;*.mp3";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = false;
            StopPlaySound();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog.FileName;
                    IniSetting.Write("Sound", file);
                    lblSound.Text = file;
                    SetDefaultSetting();
                }
                catch (Exception ex)
                {
                    lblHelp.Text = ex.Message;
                }
            }
        }
        private void StartPlaySound(string SoundSource)
        {
            checkPlaySound = false;
            if (System.IO.File.Exists(SoundSource))
            {
                var ext = System.IO.Path.GetExtension(SoundSource).ToLower();
                if (ext == ".wav")
                {
                    SoundPlayer.SoundLocation = SoundSource;
                    SoundPlayer.Play();
                }
                else if (ext == ".mp3")
                {
                    wplayer.URL = SoundSource;
                    wplayer.controls.play();
                }
            }
            else
            {
                SoundPlayer.Stream = Properties.Resources.AlertSound;
                SoundPlayer.Play();
            }
        }
        private void StopPlaySound()
        {
            checkPlaySound = true;
            SoundPlayer.Stop();
            wplayer.controls.stop();
        }
        private void LoadResources()
        {
            //
            this.StartPosition = FormStartPosition.CenterScreen;
            //btnColorDialog
            btnColorDialog.BackColor = Color.DodgerBlue;
            btnColorDialog.FlatAppearance.BorderSize = 0;
            btnColorDialog.FlatStyle = FlatStyle.Flat;
            btnColorDialog.ForeColor = Color.White;
            btnColorDialog.UseVisualStyleBackColor = false;
            //btnGetColor
            btnGetColor.BackColor = Color.DodgerBlue;
            btnGetColor.FlatAppearance.BorderSize = 0;
            btnGetColor.FlatStyle = FlatStyle.Flat;
            btnGetColor.ForeColor = Color.White;
            btnGetColor.UseVisualStyleBackColor = false;
            //btnFindingColor
            btnFindingColor.BackColor = Color.DodgerBlue;
            btnFindingColor.FlatAppearance.BorderSize = 0;
            btnFindingColor.FlatStyle = FlatStyle.Flat;
            btnFindingColor.ForeColor = Color.White;
            btnFindingColor.UseVisualStyleBackColor = false;
            //btnSelectSound
            btnSelectSound.BackColor = Color.DodgerBlue;
            btnSelectSound.FlatAppearance.BorderSize = 0;
            btnSelectSound.FlatStyle = FlatStyle.Flat;
            btnSelectSound.ForeColor = Color.White;
            btnSelectSound.UseVisualStyleBackColor = false;
            //btnPlaySound
            btnPlaySound.BackColor = Color.DodgerBlue;
            btnPlaySound.FlatAppearance.BorderSize = 0;
            btnPlaySound.FlatStyle = FlatStyle.Flat;
            btnPlaySound.ForeColor = Color.White;
            btnPlaySound.UseVisualStyleBackColor = false;
            //
            if (System.IO.File.Exists(IniSetting.Path))
            {
                if (!System.IO.File.Exists(IniSetting.Read("Sound")))
                    IniSetting.Write("Sound", "AlertSound.wav");
                SetDefaultSetting();
            }
            else
            {
                var st = new Common.Settings()
                {
                    Color = "000000",
                    Sound = "AlertSound.wav"
                };
                IniSetting.Write("Color", st.Color);
                IniSetting.Write("Sound", st.Sound);
                SetDefaultSetting();
            }
            //MessageBox.Show("Not Settings File!");
        }
        private void SetDefaultSetting()
        {
            Setting.Color = IniSetting.Read("Color");
            Setting.Sound = IniSetting.Read("Sound");
            //
            txtHexColor.Text = Setting.Color;
            lblSound.Text = Setting.Sound;
            imgHexColor.BackColor = Common.Images.HexToRGB(Setting.Color);
        }
    }
}
