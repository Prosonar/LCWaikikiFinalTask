using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityOperations
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, ETradeContext>, IUserOperationClaimDal
    {
    }
}
