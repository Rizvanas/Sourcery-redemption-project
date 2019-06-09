using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.DTO.General
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
        public DateTime NextSLD { get; set; }
    }
}
