using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnRelease
{
    public class VnReleaseMedia
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public string Medium { get; set; }
        public uint? Quantity { get; set; }
    }
}
