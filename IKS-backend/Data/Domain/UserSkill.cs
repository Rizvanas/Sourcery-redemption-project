using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.Domain
{
    public class UserSkill
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int SkillLevel { get; set; }
    }
}
