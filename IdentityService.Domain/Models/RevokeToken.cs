using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Models
{
    public class RevokeToken: Base.Entity
    {
        public RevokeToken() : base()
        {
        }

        [System.ComponentModel.DataAnnotations.Required]
        public string Token { get; set; }
    }
}
