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
            btnGetColor.KeyDown += new KeyEventHandler(btnGetColor_KeyShort);
        }
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        private void button1_Click(object sender, EventArgs e)
        {
            //Point[] points = FindColor(HexToRGB("#2D2D30"));
            Point[] points = FindColor(txtHexColor.Text.Trim('#'));
            if (points.Length > 0)
            {
                foreach (var i in points)
                {
                    SetCursorPos(i.X, i.Y);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, i.X, i.Y, 0, 0);
                    System.Threading.Thread.Sleep(5000);
                }
            }
            else
                MessageBox.Show("No Color!");
        }
        private void btnGetColor_Click(object sender, EventArgs e)
        {
            GetColor();
        }
        private void btnGetColor_KeyShort(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                GetColor();
        }
        private void GetColor()
        {
            Timer.Interval = 100;
            lblHelpSelectColor.ForeColor = Color.Red;
            if (Timer.Enabled)
            {
                Timer.Stop();
                Timer.Enabled = false;
                lblHelpSelectColor.Text = "";
            }
            else
            {
                Timer.Start();
                Timer.Enabled = true;
                lblHelpSelectColor.Text = "Press F5 to select Color!";
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            List<Point> result = new List<Point>();
            var bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(System.Windows.Forms.Cursor.Position, new Point(0, 0), new Size(1, 1));
            }
            var pixel = bmp.GetPixel(0, 0);
            imgHexColor.BackColor = pixel;
            txtHexColor.Text = RGBToHex(pixel);
            //var p = new Point();
            //p.X = (this.Width / 2) - (label1.Width / 2);
            //p.Y = label1.Top;
            //label1.Location = p;

            //MessageBox.Show(Timer.ToString());
        }
        private static string RGBToHex(Color color)
        {
            string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            //string hex = string.Format("0x{0:8x}", color);
            return hex;
        }
        private static Color HexToRGB(string ColorHex = "#FFFFFF00")
        {
            int argb = Int32.Parse(ColorHex.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
        private static Bitmap GetScreenShot()
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            {
                using (Graphics gfx = Graphics.FromImage(result))
                {
                    gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
            }
            return result;
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private static Point[] FindColor(string HexColor)
        {
            List<Point> result = new List<Point>();
            using (Bitmap bmp = GetScreenShot())
            {
                ////Image i = (Image)bmp;
                //var jpgEncoder = GetEncoder(ImageFormat.Bmp);

                //// Create an Encoder object based on the GUID  
                //// for the Quality parameter category.  
                //var myEncoder = System.Drawing.Imaging.Encoder.Quality;
                //var myEncoderParameters = new EncoderParameters(1);
                //var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                //myEncoderParameters.Param[0] = myEncoderParameter;

                //bmp.Save("test.jpg", jpgEncoder, myEncoderParameters);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        if (HexColor == RGBToHex(bmp.GetPixel(x, y)))
                            result.Add(new Point(x, y));
                    }
                }
            }
            return result.ToArray();
        }
        //private static Point[] FindColor(Color color)
        //{
        //    int searchValue = color.ToArgb();
        //    List<Point> result = new List<Point>();
        //    var s = new List<string>();
        //    using (Bitmap bmp = GetScreenShot())
        //    {
        //        //Image i = (Image)bmp;
        //        var jpgEncoder = GetEncoder(ImageFormat.Bmp);

        //        // Create an Encoder object based on the GUID  
        //        // for the Quality parameter category.  
        //        var myEncoder = System.Drawing.Imaging.Encoder.Quality;
        //        var myEncoderParameters = new EncoderParameters(1);
        //        var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
        //        myEncoderParameters.Param[0] = myEncoderParameter;

        //        bmp.Save("test.jpg", jpgEncoder, myEncoderParameters);
        //        for (int x = 0; x < bmp.Width; x++)
        //        {
        //            for (int y = 0; y < bmp.Height; y++)
        //            {
        //                var tmp = RGBToHex(bmp.GetPixel(x, y));
        //                s.Add(tmp);
        //                if (searchValue.Equals(bmp.GetPixel(x, y).ToArgb()))
        //                    result.Add(new Point(x, y));
        //            }
        //        }
        //    }
        //    return result.ToArray();
        //}
        public static Image GrayScale(Image Img)
        {
            var imageStream = new System.IO.MemoryStream();
            using (Bitmap bmp = new Bitmap(Img))
            {
                int rgb;
                Color c;

                for (int y = 0; y < bmp.Height; y++)
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        c = bmp.GetPixel(x, y);
                        rgb = (int)((c.R + c.G + c.B) / 3);
                        bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                    }
                bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return Image.FromStream(imageStream);
        }
    }
}
