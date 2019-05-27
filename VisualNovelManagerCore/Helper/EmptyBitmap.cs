using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VisualNovelManagerCore.Helper
{
    internal class EmptyBitmap
    {
        internal static BitmapImage EmptyBitmapImage()
        {
            BitmapSource bitmap = BitmapImage.Create(
                2, 2, 96, 96, PixelFormats.Indexed1, new BitmapPalette(new List<Color> { Colors.Transparent }),
                new byte[] { 0, 0, 0, 0 }, 1);
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(bitmap);
            writer.Flush();
            stream.Position = 0;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();

            stream.Close();
            writer.Close();
            return bitmapImage;
        }
    }
}
