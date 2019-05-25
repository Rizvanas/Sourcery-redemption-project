﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.DTO.Responses
{
    public class UserRequestsResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public IEnumerable<Object> Goals { get; set; }
    }
}
