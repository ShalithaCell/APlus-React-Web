using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Portal.Domain.DatabaseModels;
using Portal.Domain.DatabaseModels.BaseModel;
using Portal.Domain.IdentityModels;
using Portal.Infrastructure.DAL.DatabaseContext.ExtendModule;
using Portal.Infrastructure.DAL.DefaultDataConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure.DAL.DatabaseContext
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<AppUser, AppRole, int>
    {
        private IDbContextTransaction _transaction;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

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
            builder.ApplyConfiguration(new OrganizationDefaultConfiguration());
        }
    }

    public class OperationalStoreOptionsMigrations : IOptions<OperationalStoreOptions>
    {
        public OperationalStoreOptions Value => new OperationalStoreOptions()
        {
            DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
            EnableTokenCleanup = false,
            PersistedGrants = new TableConfiguration("PersistedGrants"),
            TokenCleanupBatchSize = 100,
            TokenCleanupInterval = 3600,
        };
    }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            AppConfiguration app = new AppConfiguration();
            var connectionString = app.ConnectionString;

            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options, new OperationalStoreOptionsMigrations());
        }
    }
}
