using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TRobles.OA.C.Common.Base;
using TRobles.OA.C.Entities;

namespace TRobles.OA.C.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMapping(modelBuilder.Entity<User>());
        }

        public override int SaveChanges()
        {
            var baseEntity = ChangeTracker.Entries<AuditableBaseEntity>();
            if (baseEntity != null)
            {
                var currentDate = DateTime.UtcNow;
                foreach (var item in baseEntity.Where(w => w.State == EntityState.Added || w.State == EntityState.Modified))
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            item.Entity.CreatedDate = currentDate;
                            break;
                        case EntityState.Modified:
                            item.Entity.UpdatedDate = currentDate;
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TROAC;Trusted_Connection=True;");
        }
    }
}