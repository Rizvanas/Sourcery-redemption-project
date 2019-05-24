using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_IKS.Data.Domain;
using My_IKS.Data.Repositories;
using My_IKS.Extensions;
using My_IKS.Data.Domain.Enumerations;

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

            var orderingColumnsMap = new Dictionary<string, Expression<Func<User, object>>>
            {
                ["name"] = v => v.FirstName + v.LastName,
                ["skills"] = v => v.UserSkills.Select(s => s.Skill.Title),
                ["goals"] = v => v.Goals.Select(g => g.Title),
                ["location"] = v => v.Location,
                ["requests"] = v => v.Goals.Select(g => g.Requests),
                ["activeTime"] = v => v.LastActiveTime
            };

            var searchColumnsMap = new Dictionary<string, Expression<Func<User, bool>>>
            {
                ["name"] = v => ($"{v.FirstName} {v.LastName}".ToLowerInvariant().Trim()).Contains(filter.Keyword.ToLowerInvariant().Trim()),
                ["skills"] = v => v.UserSkills.Select(s => s.Skill.Title.ToLowerInvariant().Trim()).Contains(filter.Keyword.ToLowerInvariant().Trim()),
                ["goals"] = v => v.Goals.Select(g => g.Title.ToLowerInvariant().Trim()).Contains(filter.Keyword.ToLowerInvariant().Trim()),
                ["location"] = v => v.Location.ToLowerInvariant().Trim().Contains(filter.Keyword.ToLowerInvariant().Trim()),
            };

            query = query
                .ApplySearchKeyword(filter, searchColumnsMap)
                .ApplyOrdering(filter, orderingColumnsMap)
                .ApplyPagination(filter);

            return await query.ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _IKSContext.Users
                .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
                .Include(u => u.Goals)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
