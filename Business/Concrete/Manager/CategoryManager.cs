using Business.Abstract.Services;
using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class CategoryManager : ICategoryService
    {
        public IResult Add(Category color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Category color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Category> GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetColors(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category color)
        {
            throw new NotImplementedException();
        }
    }
}
