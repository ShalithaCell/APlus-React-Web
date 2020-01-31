using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.DAL.DefaultDataConfiguration
{
    /// <summary>
    /// Enter the Default data to Organization when DB is creating.
    /// </summary>
    public class OrganizationDefaultConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasData
                (
                    new Organization
                    {
                        ID = 1,
                        Address1 = "Kuliyapitiya",
                        Address2 = "Kuliyapitiya",
                        Address3 = "Kuliyapitiya",
                        Country = "Srilanka",
                        Hearaboutus = "NVIVID",
                        IsActive = true,
                        OrganizationName = "NVIVID Technologies",
                        RegistedDate = DateTime.Now,
                        State = "Kurunegala",
                        ZipPostalCode = "60200"
                    }
                );
        }
    }
}
