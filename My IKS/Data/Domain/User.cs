using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.Domain
{
    public class User : IdentityUser<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public DateTime NextSLD { get; set; }
        public int RequestsAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public List<UserSkill> UserSkills { get; set; }
        public List<Goal> Goals { get; set; }
    }
}
