using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnInfo
{
    public class VnInfo
    {
        public int Id { get; set; }
        public uint VnId { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Released { get; set; }
        public string Languages { get; set; }
        public string OriginalLanguages { get; set; }
        public string Platforms { get; set; }
        public string Aliases { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool ImageNsfw { get; set; }
        public double? Popularity { get; set; }
        public uint Rating { get; set; }
        public int VoteCount { get; set; }
        public virtual VnInfoAnime VnInfoAnime { get; set; }
        public virtual VnInfoLinks VnInfoLinks { get; set; }
        public virtual VnInfoRelations VnInfoRelations { get; set; }
        public virtual VnInfoScreens VnInfoScreens { get; set; }
        public virtual VnInfoStaff VnInfoStaff { get; set; }
        public virtual ICollection<VnInfoTags> VnInfoTags { get; set; }
        public virtual ICollection<VnCharacter.VnCharacterInfo> VnCharacters { get; set; }
        public virtual ICollection<VnRelease.VnRelease> VnReleases { get; set; }
        public virtual ICollection<VnInfoScreens> VnInfoScreensCollection { get; set; }
    }
}
