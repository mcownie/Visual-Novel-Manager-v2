using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using VisualNovelManagerCore.Database.Model.VNDB;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;

namespace VisualNovelManagerCore.Database
{
    public class LiteDb
    {
        public void UpdateDb()
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var vnInfo = db.GetCollection<Model.VNDB.VnInfo.VnInfo>("vninfo");
                var vn = new Model.VNDB.VnInfo.VnInfo
                {
                    VnId = 92,
                    Title = "Muv-Luv Alternative",
                    Original = "マブラヴ　オルタネイティヴ",
                    Released = "2006-2-24",
                    //Languages = "en,ja,zh",
                    //OriginalLanguages = "ja",
                    //Platforms = "win,ps3,xb3",
                    Aliases = $"MLA{Environment.NewLine}Muvluv Alternative",
                    //Length = "5",
                    Description = "\"A destiny tossed about, in an insane world---\nA flame of life blazing forth, in a dying world---\nAnd now, one more future that is spun---\n\nThis is the alternative ending unable to be told before:\nA very great, a very tiny, a very precious...\nTale of love and courage.\"\n\nMuv-Luv Alternative continues the story of Shirogane Takeru after the events of the original Muv-Luv. This is a tale of a love so deep it breaks all barriers; about courage in the face of adversity and overcoming hardships. Takeru encounters and conquers insurmountable odds while his entire world is turned upside down around him.\n\n[Edited from [url=http://www.neechin.net/article/43/muv-luv-alternative-spoilerfree]Neechin[/url] and [url=http://randomc.net/2012/06/13/muv-luv-extra-unlimited-alternative-overview/]Random Curiosity[/url]]"
                    //VnInfoLinks = new VnInfoLinks(){Wikipedia = "Muv-Luv#Muv-Luv_Alternative" },
                    //ImageLink = "https://s.vndb.org/cv/77/24277.jpg",
                    //ImageNsfw = false,
                    //VnInfoAnime = null,
                    //VnInfoRelations = null,
                    //VnInfoTags = null,
                    //Popularity = 63,
                    //Rating = 9,
                    //VoteCount = 3309,
                    //VnInfoScreens = null,
                    //VnInfoStaff = null
                };
                var test = new Model.VNDB.VnInfo.VnInfo()
                {
                    Title = "Muv-Luv Alternative",
                    Length = 5
                };
                vnInfo.Update(test);
                vnInfo.EnsureIndex(x => x.Id);
                var results = vnInfo.Find(x => x.Title.Contains("Muv"));
            }
        }

    }
}
