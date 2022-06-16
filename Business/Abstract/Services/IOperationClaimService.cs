using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetAll(Expression<Func<OperationClaim, bool>> filter = null);
    }
}
