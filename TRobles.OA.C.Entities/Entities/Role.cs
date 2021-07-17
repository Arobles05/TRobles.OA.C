

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRobles.OA.C.Common.Base;

namespace TRobles.OA.C.Entities
{
    [Table(("ROLES"))]
    public class Role //: AuditableBaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
       
        [Column("TRANSACTION_USER")]
        public string  TransactionUser { get; set; }
        
        [Column("TRANSACTION_DATE")]
        public DateTime TransactionDate { get; set; }
        
        public virtual ICollection<User> Users { get; set; }

    }
}
