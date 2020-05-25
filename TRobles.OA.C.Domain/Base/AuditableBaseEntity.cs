using System;
using System.Collections.Generic;
using System.Text;

namespace TRobles.OA.C.Common.Base
{
    public class AuditableBaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid? UpdatedById { get; set; }
    }
}
