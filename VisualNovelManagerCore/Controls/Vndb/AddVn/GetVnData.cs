using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManagerCore.Helper.Vndb;
using VndbSharp.Models;
using VndbSharp.Models.Character;
using VndbSharp.Models.Release;
using VndbSharp.Models.VisualNovel;
using VndbSharp.Filters;
using VndbSharp;


namespace VisualNovelManagerCore.Controls.Vndb.AddVn
{
    class GetVnData
    {
        private async Task GetData(uint _vnid)
        {
            try
            {
                using (VndbSharp.Vndb client = new VndbSharp.Vndb(true))
                {
                    bool hasMore = true;
                    RequestOptions ro = new RequestOptions { Count = 25 };
                    int pageCount = 1;
                    int characterCount = 0;
                    int releasesCount = 0;

                    VndbResponse<VisualNovel> visualNovels = await client.GetVisualNovelAsync(VndbFilters.Id.Equals(_vnid), VndbFlags.FullVisualNovel);
                    if (visualNovels == null)
                    {
                        HandleError.HandleErrors(client.GetLastError(), 0);
                        return;
                    }

                    List<Character> characterList = new List<Character>();
                    while (hasMore)
                    {
                        ro.Page = pageCount;
                        VndbResponse<Character> characters = await client.GetCharacterAsync(VndbFilters.VisualNovel.Equals(_vnid), VndbFlags.FullCharacter, ro);
                        if (characters != null)
                        {
                            hasMore = characters.HasMore;
                            characterList.AddRange(characters.Items);
                            characterCount = characterCount + characters.Count;
                            pageCount++;
                        }
                        if (characters != null) continue;
                        HandleError.HandleErrors(client.GetLastError(), 0);
                        return;
                    }

                    hasMore = true;
                    pageCount = 1;

                    List<Release> releaseList = new List<Release>();
                    while (hasMore)
                    {
                        ro.Page = pageCount;
                        VndbResponse<Release> releases = await client.GetReleaseAsync(VndbFilters.VisualNovel.Equals(_vnid), VndbFlags.FullRelease, ro);
                        if (releases == null)
                        {
                            HandleError.HandleErrors(client.GetLastError(), 0);
                            break;
                        }
                        hasMore = releases.HasMore;
                        releaseList.AddRange(releases.Items);
                        releasesCount = releasesCount + releases.Count;
                        pageCount++;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
