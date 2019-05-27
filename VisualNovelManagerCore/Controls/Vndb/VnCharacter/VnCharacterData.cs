using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VisualNovelManagerCore.Controls.Vndb.VnCharacter
{
    class VnCharacterData
    {
        private async Task DownloadCharacters()
        {
            try
            {
                var vnCharacter = Globals.LiteDbInstance.GetCollection<Database.Model.VNDB.VnCharacter.VnCharacterInfo>("vncharacter");
                List<string> characterList = vnCharacter.Find(x => x.VnId == Globals.VnId).Select(i => i.ImageLink).ToList();
                if (characterList.Count > 0)
                {
                    using (WebClient client = new WebClient())
                    {
                        foreach (string character in characterList)
                        {
                            if (!Directory.Exists($@"{Globals.DirectoryPath}\Data\vndb\images\characters\{Globals.VnId}"))
                            {
                                Directory.CreateDirectory($@"{Globals.DirectoryPath}\Data\vndb\images\characters\{Globals.VnId}");
                            }
                            string path = $@"{Globals.DirectoryPath}\Data\vndb\images\characters\{Globals.VnId}\{Path.GetFileName(character)}";

                            if (!File.Exists(path) && !string.IsNullOrEmpty(character))
                            {
                                await client.DownloadFileTaskAsync(new Uri(character), path);
                            }
                        }
                        client.Dispose();
                    }
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx);
                throw;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                throw;
            }
        }
    }
}
