using Portal.Domain.DatabaseModels.BaseModel;
using Portal.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.DatabaseModels
{
    [Table("Organization")]
    public class Organization : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }

        [Required]
        public int Country { get; set; }

        [Required]
        public int State { get; set; }

        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string Address3 { get; set; }

        [MaxLength(100)]
        public string ZipPostalCode { get; set; }


        public string Hearaboutus { get; set; }

        public ICollection<AppUser> Users { get; set; }
        public ICollection<AppRole> Roles { get; set; }
    }
}
