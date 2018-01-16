using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindColor.Common
{
    public class Images
    {
        public static string RGBToHex(Color color)
        {
            string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            //string hex = string.Format("0x{0:8x}", color);
            return hex;
        }
        public static Color HexToRGB(string ColorHex = "#FFFFFF00")
        {
            int argb = Int32.Parse(ColorHex.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
        public static Bitmap GetScreenShot()
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
        public static ImageCodecInfo GetEncoder(ImageFormat format)
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
        public static Point[] FindColor(string HexColor)
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
