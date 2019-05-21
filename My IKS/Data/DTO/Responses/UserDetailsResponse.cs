using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;

namespace My_IKS.Data.DTO.Responses
{
    public class UserDetailsResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserDetail> Details { get; set; }
    }
}
