using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;
using My_IKS.Data.Repositories;

namespace My_IKS.Persistance.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(IKSContext context)
            : base(context)
        { }
        private readonly IKSContext context;

        public IKSContext _IKSContext
        {
            get { return _context as IKSContext; }
        }

        public IEnumerable<Skill> GetUserSkills(int userId)
        {
            return _IKSContext.UserSkills
                .Where(us => us.UserId == userId)
                .Select(us => new Skill
                {
                    SkillId = us.Skill.SkillId,
                    Title = us.Skill.Title,
                    Level = us.SkillLevel
                });
        }
    }
}
