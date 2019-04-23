using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace VisualNovelManagerCore.Converters
{
    public class Base64Converter
    {
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();

                    // Convert byte[] to base 64 string
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public static string BitmapToBase64(BitmapImage bi)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bi));
                encoder.Save(ms);
                byte[] bitmapdata = ms.ToArray();

                return Convert.ToBase64String(bitmapdata);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        public static BitmapImage GetBitmapImageFromBytes(string base64)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64);
                BitmapImage btm;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    btm = new BitmapImage();
                    btm.BeginInit();
                    btm.StreamSource = ms;
                    // Below code for caching is crucial.
                    btm.CacheOption = BitmapCacheOption.OnLoad;
                    btm.EndInit();
                    btm.Freeze();
                }
                return btm;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                throw;
            }

        }
    }
}
