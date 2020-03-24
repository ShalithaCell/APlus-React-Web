using Portal.API.Domain.BaseModels;
using Portal.API.Domain.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class PasswordResetToken : BaseEntity
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Token { get; set; }

        public AppUser appUser { get; }
    }
}
