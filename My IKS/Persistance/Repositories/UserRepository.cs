using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_IKS.Data.Domain;
using My_IKS.Data.Repositories;

namespace My_IKS.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IKSContext context)
            : base(context)
        { }

        public IKSContext _IKSContext
        {
            get { return _context as IKSContext; }
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Filter filter)
        {
            var query = _IKSContext.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .Include(u => u.Goals).AsQueryable();

      

            return await query.ToListAsync();
        }
    }
}
