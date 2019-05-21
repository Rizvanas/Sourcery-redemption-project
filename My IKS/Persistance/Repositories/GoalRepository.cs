using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;
using My_IKS.Data.Repositories;

namespace My_IKS.Persistance.Repositories
{
    public class GoalRepository : Repository<Goal>, IGoalRepository
    {
        public GoalRepository(IKSContext context)
            : base(context)
        { }

        public IKSContext _IKSContext
        {
            get { return _context as IKSContext; }
        }

        public IEnumerable<Goal> GetUserGoals(int userId)
        {
            return _IKSContext.Goals
                .Where(g => g.User.UserId == userId)
                .Select(g => new Goal { GoalId = g.GoalId, Title = g.Title, Description = g.Description });
        }
    }
}
