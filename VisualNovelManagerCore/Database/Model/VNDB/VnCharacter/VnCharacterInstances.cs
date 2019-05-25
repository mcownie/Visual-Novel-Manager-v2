using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnCharacter
{
    public class VnCharacterInstances
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public byte Spoiler { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
