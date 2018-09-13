using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serview.Models
{
    public class User : IdentityUser
    {
        public ICollection<Rating> Ratings { get; set; }
    }
}
