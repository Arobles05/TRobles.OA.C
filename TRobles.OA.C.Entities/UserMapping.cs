using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRobles.OA.C.Entities
{
    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id );
            entityTypeBuilder.Property(t => t.UserName).IsRequired();
            entityTypeBuilder.Property(t => t.Password).IsRequired();
            entityTypeBuilder.HasOne<Role>(r => r.Role);
            
            //entityTypeBuilder.Property(t => t.Email).IsRequired();
        }
    }

    public class RoleMapping
    {
        public RoleMapping(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.HasMany<User>(e => e.Users);
        }
    }
}
