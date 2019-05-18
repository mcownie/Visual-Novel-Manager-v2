using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VisualNovelManagerCore.Helper
{
    public static class CreateIconHelper
    {
        private static BitmapSource CreateIcon(string path)
        {
            try
            {
                if (path == null)
                {
                    return BitmapSource.Create(1, 1, 96, 96, PixelFormats.Bgra32, null, new byte[] { 0, 0, 0, 0 }, 4);
                }
                Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(path);
                if (sysicon == null)
                    return BitmapSource.Create(1, 1, 96, 96, PixelFormats.Bgra32, null, new byte[] { 0, 0, 0, 0 }, 4);
                BitmapSource bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                    sysicon.Handle, System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                sysicon.Dispose();
                return bmpSrc;
            }
            catch (Exception ex)
            {                
                throw;
            }

        }
    }
}
