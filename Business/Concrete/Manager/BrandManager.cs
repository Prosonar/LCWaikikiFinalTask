using Business.Abstract.Services;
using Core.Utilities.ExceptionHandle;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetBrands(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
