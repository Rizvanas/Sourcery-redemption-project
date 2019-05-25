using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;

namespace My_IKS.Data.DTO.Responses
{
    public class UserIntroResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public IEnumerable<string> SkillTitles { get; set; }
        public IEnumerable<string> GoalTitles { get; set; }
    }
}
