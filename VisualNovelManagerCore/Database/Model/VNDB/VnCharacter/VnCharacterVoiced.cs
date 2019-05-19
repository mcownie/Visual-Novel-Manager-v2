using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnCharacter
{
    public class VnCharacterVoiced
    {
        public int Id { get; set; }
        public uint StaffId { get; set; }
        public uint StaffAliasId { get; set; }
        public uint VnId { get; set; }
        public string Note { get; set; }
    }
}
