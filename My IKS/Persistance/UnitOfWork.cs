using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data;
using My_IKS.Data.Repositories;
using My_IKS.Persistance.Repositories;

namespace My_IKS.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IKSContext _context;

        public UnitOfWork(IKSContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
