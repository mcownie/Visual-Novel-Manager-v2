using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnUserList
{
    public class VnWishList
    {
        public int Id { get; set; }
        public uint UserId { get; set; }
        public uint VnId { get; set; }
        public string Priority { get; set; }
        public string Added { get; set; }
    }
}
