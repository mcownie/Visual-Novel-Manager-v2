using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnInfo
{
    public class VnInfoScreens
    {
        public int Id { get; set; }
        public uint? VnId { get; set; }
        public string ImageUrl { get; set; }
        public string ReleaseId { get; set; }
        public string Nsfw { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
}
