using Microsoft.AspNetCore.Identity;
using pro_events.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public Function Function { get; set; }
        public string? Description { get; set; }
        public Degree Degree { get; set; }
        public string? ImgURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
