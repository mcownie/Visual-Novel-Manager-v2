using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB
{
    public class VnInfo
    {
        public int Id { get; set; }
        public int VnId { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Released { get; set; }
        public string[] Languages { get; set; }
        public string[] OriginalLanguages { get; set; }
        public string[] Platforms { get; set; }
        public string Aliases { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public object Links { get; set; }
        public string Image { get; set; }
        public bool ImageNsfw { get; set; }
        public object[] Anime { get; set; }
        public object[] Relations { get; set; }
        public Array[] Tags { get; set; }
        public byte Popularity { get; set; }
        public byte Rating { get; set; }
        public int Votecount { get; set; }
        public object[] Screens { get; set; }
        public object[] Staff { get; set; }
    }
}
