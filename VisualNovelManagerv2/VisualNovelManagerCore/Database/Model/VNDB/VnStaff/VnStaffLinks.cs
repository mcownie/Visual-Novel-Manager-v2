using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnStaff
{
    public class VnStaffLinks
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public string Homepage { get; set; }
        public string Wikipedia { get; set; }
        public string Twitter { get; set; }
        public string AniDb { get; set; }
    }
}
