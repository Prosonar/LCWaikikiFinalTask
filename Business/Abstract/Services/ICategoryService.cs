using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract.Services
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetColors(Expression<Func<Category, bool>> filter = null);
        IDataResult<Category> GetById(int colorId);
        IResult Add(Category color);
        IResult Delete(Category color);
        IResult Update(Category color);
    }
}
