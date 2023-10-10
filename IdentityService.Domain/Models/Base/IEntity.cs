using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Models.Base
{
    public interface IEntity
    {
        System.Guid Id { get; set; }
    }
}
