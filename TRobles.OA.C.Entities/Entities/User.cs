using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRobles.OA.C.Common.Base;

namespace TRobles.OA.C.Entities
{
    [Table(("USERS"))]
    public class User //: AuditableBaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ROLEID")]
        public int RoleId { get; set; }
        
        [Column("FIRST_NAME")]
        public string  FirstName { get; set; }
        
        [Column("LAST_NAME")]
        public string LastName { get; set; }
        
        [Column("CEDULA")]
        public int Cedula  { get; set; }
        
        [Column("USER_NAME")]
        public string UserName { get; set; }
        
        [Column("PASSWORD")]
        public string  Password { get; set; }
        
        [Column("BIRTH_DATE")]
        public DateTime Birthdate { get; set; }
        
        [Column("TRANSACTION_USER")]
        public string  TransactionUser { get; set; }
        
        [Column("TRANSACTION_DATE")]
        public DateTime TransactionDate { get; set; }
        
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

    }
}
