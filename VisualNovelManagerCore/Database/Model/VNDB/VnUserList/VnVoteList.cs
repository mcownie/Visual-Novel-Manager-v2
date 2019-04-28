using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnUserList
{
    public class VnVoteList
    {
        public int Id { get; set; }
        public uint UserId { get; set; }
        public uint VnId { get; set; }
        public uint Vote { get; set; }
        public string Added { get; set; }
    }
}
