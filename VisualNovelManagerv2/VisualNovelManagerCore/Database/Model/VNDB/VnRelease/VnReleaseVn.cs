using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnRelease
{
    public class VnReleaseVn
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public uint? VnId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
