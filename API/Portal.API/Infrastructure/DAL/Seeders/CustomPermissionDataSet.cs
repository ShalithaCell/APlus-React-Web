using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.API.Domain.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure.DAL.Seeders
{
    /// <summary>
    /// Seed the default data
    /// </summary>
    public class CustomPermissionDataSet : IEntityTypeConfiguration<CustomPermission>
    {
        public void Configure(EntityTypeBuilder<CustomPermission> builder)
        {
            builder.HasData
                (
                    new CustomPermission
                    {
                        ID = 1,
                        IsActive = true,
                        Permission = "Report",
                        PermissionCode = "RE",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 2,
                        IsActive = true,
                        Permission = "Sales",
                        PermissionCode = "SE",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 3,
                        IsActive = true,
                        Permission = "Inventory View",
                        PermissionCode = "IV",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 4,
                        IsActive = true,
                        Permission = "Inventory Add",
                        PermissionCode = "IA",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 5,
                        IsActive = true,
                        Permission = "Inventory Update",
                        PermissionCode = "IU",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 6,
                        IsActive = true,
                        Permission = "Inventory Delete",
                        PermissionCode = "ID",
                        RegistedDate = DateTime.Now
                    },
                    new CustomPermission
                    {
                        ID = 7,
                        IsActive = true,
                        Permission = "Customer Handling",
                        PermissionCode = "CH",
                        RegistedDate = DateTime.Now
                    }
                );

        }
    }
}
