using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.Repositories;

namespace My_IKS.Data
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
