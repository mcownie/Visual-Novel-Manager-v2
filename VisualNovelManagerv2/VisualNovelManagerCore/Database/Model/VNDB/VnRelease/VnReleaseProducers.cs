using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnRelease
{
    public class VnReleaseProducers
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public uint ProducerId { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string ProducerType { get; set; }
    }
}
