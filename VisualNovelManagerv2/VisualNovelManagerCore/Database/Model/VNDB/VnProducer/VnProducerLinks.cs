using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnProducer
{
    public class VnProducerLinks
    {
        public int Id { get; set; }
        public int? ProducerId { get; set; }
        public string Homepage { get; set; }
        public string Wikipedia { get; set; }
    }
}
