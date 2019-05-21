using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Domain;

namespace My_IKS.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersAsync(Filter filter);
    }
}
