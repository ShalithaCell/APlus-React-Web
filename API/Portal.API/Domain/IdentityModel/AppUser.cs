using Microsoft.AspNetCore.Identity;
using Portal.API.Domain.DataBaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.IdentityModel
{
    public class AppUser : IdentityUser<int>
    {
        public int OrganizationID { get; set; }

        [ForeignKey("UserID")]
        public ICollection<PasswordResetToken> passwordResetTokens { get; set; }

    }
}
