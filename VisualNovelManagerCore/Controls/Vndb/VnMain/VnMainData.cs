using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;
using VisualNovelManagerCore.Helper.Converters;
using VisualNovelManagerCore.Helper;

namespace VisualNovelManagerCore.Controls.Vndb.VnMain
{
    class VnMainData
    {
        private BitmapImage GetCoverImage(bool? nsfw)
        {
            string pathNoExt = $@"{Globals.DirectoryPath}\Data\vndb\images\cover\{Globals.VnId}";
            string path = $@"{Globals.DirectoryPath}\Data\vndb\images\cover\{Globals.VnId}.jpg";

            try
            {
                if (!File.Exists(path) && !File.Exists(pathNoExt))
                {
                    return EmptyBitmap.EmptyBitmapImage();
                }
                switch (nsfw)
                {
                    case true:
                    {
                        BitmapImage bImage = Globals.NsfwEnabled ? Base64Converter.GetBitmapImageFromBytes(File.ReadAllText(pathNoExt))
                            : new BitmapImage(new Uri($@"{Globals.DirectoryPath}\Data\res\nsfw\cover.jpg"));
                        return bImage;
                    }
                    case false:
                    {
                        BitmapImage bitmap = new BitmapImage();
                        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.StreamSource = stream;
                            bitmap.EndInit();
                        }
                        return bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                return EmptyBitmap.EmptyBitmapImage();
            }

            return EmptyBitmap.EmptyBitmapImage();
        }

        private IEnumerable<string> GetLangauges(string csv)
        {
            string[] list = csv.Split(',');
            return list.Select(lang => File.Exists($@"{Globals.DirectoryPath}\Data\res\icons\country_flags\{lang}.png")
                    ? $@"{Globals.DirectoryPath}\Data\res\icons\country_flags\{lang}.png"
                    : $@"{Globals.DirectoryPath}\Data\res\icons\country_flags\Unknown.png")
                .ToList();
        }

        private IEnumerable<string> GetPlatforms(string csv)
        {
            string[] list = csv.Split(',');
            return list.Select(plat => File.Exists($@"{Globals.DirectoryPath}\Data\res\icons\platforms\{plat}.png")
                    ? $@"{Globals.DirectoryPath}\Data\res\icons\platforms\{plat}.png"
                    : $@"{Globals.DirectoryPath}\Data\res\icons\platforms\Unknown.png")
                .ToList();
        }
        
    }
}
