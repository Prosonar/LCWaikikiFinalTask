using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract.Services
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetCategories(Expression<Func<Category, bool>> filter = null);
        IDataResult<Category> GetById(int categoryId);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
