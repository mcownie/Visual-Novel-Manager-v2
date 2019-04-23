using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnInfo
{
    public class VnInfoLinks
    {
        public int Id { get; set; }
        public uint VnId { get; set; }
        public string Wikipedia { get; set; }
        public string Encubed { get; set; }
        public string Renai { get; set; }
    }
}
