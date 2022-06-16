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
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ETradeContext())
            {
                var result = from claim in context.OperationClaims
                             join userClaim in context.UserOperationClaims
                             on claim.Id equals userClaim.OperationClaimId
                             where userClaim.UserId == user.Id
                             select new OperationClaim { Id = claim.Id, Name = claim.Name };
                return result.ToList();
            }
        }
    }
}
