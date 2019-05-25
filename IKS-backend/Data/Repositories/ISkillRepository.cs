using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;

namespace My_IKS.Data.Repositories
{
    public interface ISkillRepository : IRepository<Skill>
    {
        IEnumerable<Skill> GetUserSkills(int userId);
    }
}
