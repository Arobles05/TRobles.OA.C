using System;
using TRobles.OA.C.Common.Base;

namespace TRobles.OA.C.Entities
{
    public class User : AuditableBaseEntity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
