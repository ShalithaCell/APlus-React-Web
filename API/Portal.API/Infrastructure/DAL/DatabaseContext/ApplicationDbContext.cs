using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.API.Domain.BaseModels;
using Portal.API.Domain.DataBaseModels;
using Portal.API.Domain.IdentityModel;
using Portal.API.Infrastructure.DAL.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure.DAL.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PasswordResetToken> passwordResetTokens { get; set; }
        public DbSet<CustomPermission> customPermissions { get; set; }
        public DbSet<CustomRolePermissionLevelc> customRolePermissionLevels { get; set; }
        public DbSet<CashierData> cashierDatas { get; set; }
        public DbSet<SupplierDetailsTable> supplierDetailsTables { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Set model default values
            foreach (var entityType in builder.Model.GetEntityTypes()
                 .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                builder.Entity(
                        entityType.Name,
                        x =>
                        {
                            x.Property("RegistedDate")
                                .HasDefaultValueSql("GETDATE()");

                            x.Property("IsActive")
                                .HasDefaultValue(true);
                        });
            }

            //table configuration and data seeding
            builder.ApplyConfiguration(new CustomPermissionDataSet());
        }
    }

    

}


