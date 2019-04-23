using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnInfo
{
    public class VnInfoRelations
    {
        public int Id { get; set; }
        public uint VnId { get; set; }
        public int? RelationId { get; set; }
        public string Relation { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Official { get; set; }
    }
}
