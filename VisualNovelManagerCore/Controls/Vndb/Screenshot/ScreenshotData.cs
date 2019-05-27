using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;
using VisualNovelManagerCore.Helper;
using VisualNovelManagerCore.Helper.Converters;

namespace VisualNovelManagerCore.Controls.Vndb.Screenshot
{
    public static class ScreenshotData
    {
        private static string basePath= String.Empty;

        private static void SetBasePath()
        {
            basePath = $@"{Globals.DirectoryPath}\Data\vndb\images\screenshots\{Globals.VnId}\";
        }

        private static List<Screenshot> LoadScreenshotList()
        {
            try
            {
                List<Screenshot> screenshotList = new List<Screenshot>();
                var vnScreenshot = Globals.LiteDbInstance.GetCollection<VnInfoScreens>("vninfoscreens");
                foreach (VnInfoScreens screens in vnScreenshot.Find(x => x.VnId== Globals.VnId))
                {
                    screenshotList.Add(new Screenshot
                    {
                        Url = screens.ImageUrl,
                        IsNsfw = Convert.ToBoolean(screens.Nsfw)
                    });
                }
                return screenshotList;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private static BitmapImage LoadLargeScreenshot(int SelectedScreenIndex)
        {
            List<Screenshot> screenshotList = LoadScreenshotList();
            BitmapImage bImage = new BitmapImage();
            if (screenshotList.Count > 0)
            {
                switch (screenshotList[SelectedScreenIndex].IsNsfw)
                {
                    case true:
                        if (Globals.NsfwEnabled == true)
                        {
                            string filename = Path.GetFileNameWithoutExtension(screenshotList[SelectedScreenIndex].Url);
                            string pathNoExt = $@"{basePath}\{filename}";
                            bImage = Base64Converter.GetBitmapImageFromBytes(File.ReadAllText(pathNoExt));
                            break;
                        }
                        else
                        {
                            bImage = new BitmapImage(new Uri($@"{Globals.DirectoryPath}\Data\res\nsfw\screenshot.jpg"));
                            break;
                        }
                    case false:
                        string path = $@"{basePath}\{Path.GetFileName(screenshotList[SelectedScreenIndex].Url)}";
                        bImage = new BitmapImage();
                        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            bImage.BeginInit();
                            bImage.CacheOption = BitmapCacheOption.OnLoad;
                            bImage.StreamSource = stream;
                            bImage.EndInit();
                            bImage.Freeze();
                        }
                        break;
                }
                return bImage;
            }
            else
            {
                return EmptyBitmap.EmptyBitmapImage();
            }            
        }

        private static async Task DownloadScreenshots()
        {
            SetBasePath();
            if (ConnectionTest.VndbTcpSocketTest() == false)
            {
                Console.WriteLine("Could not connect to Vndb API over SSL");
                return;
            }
            try
            {
                List<Screenshot> screenshotList = new List<Screenshot>();
                WebClient client = new WebClient();
                foreach (Screenshot screenshot in screenshotList)
                {
                    if (screenshotList.Count < 1) return;
                    if (!Directory.Exists($@"{basePath}\thumbs"))
                    {
                        Directory.CreateDirectory($@"{basePath}\thumbs");
                    }

                    string pathNoExt = $@"{basePath}\{Path.GetFileNameWithoutExtension(screenshot.Url)}";
                    string pathNoExtThumb = $@"{basePath}\thumbs\{Path.GetFileNameWithoutExtension(screenshot.Url)}";
                    string path = $@"{basePath}\{Path.GetFileName(screenshot.Url)}";
                    string pathThumb = $@"{basePath}\thumbs\{Path.GetFileName(screenshot.Url)}";

                    switch (screenshot.IsNsfw)
                    {
                        case true:
                            if (!File.Exists(pathNoExt))
                            {
                                using (MemoryStream stream = new MemoryStream(await client.DownloadDataTaskAsync(new Uri(screenshot.Url))))
                                {
                                    string base64Img = Base64Converter.ImageToBase64(Image.FromStream(stream), ImageFormat.Jpeg);
                                    File.WriteAllText(pathNoExt, base64Img);
                                }
                            }
                            if (!File.Exists(pathNoExtThumb))
                            {
                                using (MemoryStream stream = new MemoryStream(await client.DownloadDataTaskAsync(new Uri(screenshot.Url))))
                                {
                                    var bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.StreamSource = stream;
                                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                    bitmap.EndInit();
                                    bitmap.Freeze();
                                    Size thumbnailSize = GetThumbnailSize(bitmap);

                                    Image thumb = Image.FromStream(stream).GetThumbnailImage(thumbnailSize.Width, thumbnailSize.Height, () => false, IntPtr.Zero);
                                    if (!File.Exists($@"{basePath}\thumbs\{Path.GetFileNameWithoutExtension(screenshot.Url)}"))
                                    {
                                        File.WriteAllText(pathNoExtThumb, Base64Converter.ImageToBase64(thumb, ImageFormat.Jpeg));
                                    }
                                    thumb.Dispose();
                                }
                            }
                            break;
                        case false:
                            if (!File.Exists(path))
                            {
                                await client.DownloadFileTaskAsync(new Uri(screenshot.Url), path);
                            }
                            if (!File.Exists(pathThumb))
                            {
                                BitmapImage bitmap = new BitmapImage();
                                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    bitmap.BeginInit();
                                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                    bitmap.StreamSource = stream;
                                    bitmap.EndInit();
                                    bitmap.Freeze();
                                }
                                Size thumnailSize = GetThumbnailSize(bitmap);
                                Image thumb = Image.FromFile(path).GetThumbnailImage(thumnailSize.Width, thumnailSize.Height, () => false, IntPtr.Zero);

                                if (!File.Exists($@"{basePath}\thumbs\{Path.GetFileName(screenshot.Url)}"))
                                {
                                    thumb.Save($@"{basePath}\thumbs\{Path.GetFileName(screenshot.Url)}");
                                }
                                thumb.Dispose();
                            }
                            break;
                    }
                }
                client.Dispose();
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static Size GetThumbnailSize(BitmapImage original)
        {
            // Maximum size of any dimension.
            const int maxPixels = 80;

            // Width and height.
            double originalWidth = original.Width;
            double originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }
    }
    public class Screenshot
    {
        public string Url { get; set; }
        public bool IsNsfw { get; set; }
    }
}
