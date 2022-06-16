using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityOperations
{
    public class EfColorDal : EfEntityRepositoryBase<Color, ETradeContext>,IColorDal
    {
    }
}
