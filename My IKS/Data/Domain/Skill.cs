using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data.Domain
{
    public class Skill : UserDetail
    {
        public int SkillId { get; set; }
        public List<UserSkill> UserSkills { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
    }
}
