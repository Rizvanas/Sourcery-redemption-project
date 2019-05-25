using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.DTO.Responses
{
    public class NonActiveUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsBLocked { get; set; }
        public DateTime LastActiveTime { get; set; }
    }
}
